using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using can_hw;
using Peak.Can.Basic;
using TPCANHandle = System.Byte;

namespace SimpleUI
{
    public partial class SimpleTest : Form
    {
        #region Members
        #region Communication
        private TPCANHandle[] m_HandlesArray;
        private TPCANHandle m_PcanHandle;
        private TPCANBaudrate m_BaudRate;
        private pcan_usb pcan = null;
        private ni_usb nican = null;
        #endregion // COmmunication
        private motor[] motors;
        #region Plot

        #endregion
        #region Log
        const string separator = ",";
        private string file_name_log;
        private FileStream file_stream_log;
        private BinaryWriter binary_writer_log;
        private string file_name_can;
        private FileStream file_stream_can;
        private BinaryWriter binary_writer_can;
        private DateTime startLogTime;
        #endregion
        #endregion // Members

        public SimpleTest()
        {
            InitializeComponent();

            var motorCount = Enum.GetNames(typeof(AXLE_ID)).Length - 1;
            this.motors = new motor[motorCount];
            for(int i = 0; i < motorCount; i++) {
                this.motors[i] = new motor((byte)(0x0A+i), (AXLE_ID)i);
            }

            this.pcan = new pcan_usb();
            this.nican = new ni_usb();
            this.m_HandlesArray = new TPCANHandle[]
            {
                PCANBasic.PCAN_USBBUS1,
                PCANBasic.PCAN_USBBUS2,
                PCANBasic.PCAN_USBBUS3,
                PCANBasic.PCAN_USBBUS4,
                PCANBasic.PCAN_USBBUS5,
                PCANBasic.PCAN_USBBUS6,
                PCANBasic.PCAN_USBBUS7,
                PCANBasic.PCAN_USBBUS8,
            };

            /* Vendor combobox */
            this.cbb_vendor.Items.Clear();
            var vendorNames = Enum.GetNames(typeof(SupportedVendor));
            for (int i = 0; i < vendorNames.Length; i++) {
                this.cbb_vendor.Items.Add(vendorNames[i]);
            }
            this.cbb_vendor.SelectedIndex = 1;

            /* Modes of Operation */
            this.cbb_ModeOfOperationOne.Items.Clear();
            this.cbb_ModeOfOperationTwo.Items.Clear();
            this.cbb_ModeOfOperationThree.Items.Clear();
            var modesNames = Enum.GetNames(typeof(MODE_OF_OPERATION));
            for(int i = 0; i < modesNames.Length; i++) {
                this.cbb_ModeOfOperationOne.Items.Add(modesNames[i]);
                this.cbb_ModeOfOperationTwo.Items.Add(modesNames[i]);
                this.cbb_ModeOfOperationThree.Items.Add(modesNames[i]);
            }
            this.cbb_ModeOfOperationOne.SelectedIndex = 1;
            this.cbb_ModeOfOperationTwo.SelectedIndex = 1;
            this.cbb_ModeOfOperationThree.SelectedIndex = 1;

            this.set_obj_states(false);
        }

        #region Methods
        #region Helpers
        private void set_obj_states(bool connected)
        {
            this.cbb_vendor.Enabled = !connected;
            this.cbb_baudrates.Enabled = !connected;
            this.cbb_channel.Enabled = !connected;

            this.btn_HwRefresh.Enabled = !connected;
            this.btn_initialize.Enabled = !connected;
            this.btn_release.Enabled = connected;

            this.groupBox_MotorOne.Enabled = connected;
            this.groupBox_MotorTwo.Enabled = connected;
            this.groupBox_MotorThree.Enabled = connected;
        }

        #endregion

        #region ComboBox Event
        private void cbb_channel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((SupportedVendor)cbb_vendor.SelectedIndex == SupportedVendor.PEAK) {
                string strTemp = cbb_channel.Text;
                strTemp = strTemp.Substring(strTemp.IndexOf('B') + 1, 1);
                strTemp = "0x5" + strTemp;
                this.m_PcanHandle = Convert.ToByte(strTemp, 16);
            }
        }

        private void cbb_baudrates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((SupportedVendor)cbb_vendor.SelectedIndex == SupportedVendor.PEAK) {
                TPCANBaudrate[] baudValue = (TPCANBaudrate[])Enum.GetValues(typeof(TPCANBaudrate));
                this.m_BaudRate = baudValue[cbb_baudrates.SelectedIndex];
            }
        }

        private void cbb_vendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btn_HwRefresh_Click(this, e);
        }

        #endregion // ComboBox Event

        #region Button Event
        #region General
        private void btn_HwRefresh_Click(object sender, EventArgs e)
        {
            cbb_channel.Items.Clear();
            cbb_baudrates.Items.Clear();
            switch ((SupportedVendor)this.cbb_vendor.SelectedIndex) {
                case SupportedVendor.NI_XNET: {
                    cbb_channel.Items.Add("CAN1");
                    cbb_channel.Items.Add("CAN2");
                    cbb_channel.Items.Add("CAN3");
                    cbb_channel.Items.Add("CAN4");
                    cbb_channel.Items.Add("CAN5");
                    cbb_channel.SelectedIndex = 0;

                    cbb_baudrates.Items.Add("250000");
                    cbb_baudrates.SelectedIndex = 0;
                    break;
                }
                case SupportedVendor.PEAK: {
                    UInt32 iBuffer;
                    TPCANStatus stsResult;
                    try {
                        for (int i = 0; i < m_HandlesArray.Length; i++) {
                            // Includes all no-Plug&Play Handles
                            if (( m_HandlesArray[i] >= PCANBasic.PCAN_USBBUS1 ) &&
                                ( m_HandlesArray[i] <= PCANBasic.PCAN_USBBUS8 )) {
                                stsResult = PCANBasic.GetValue(m_HandlesArray[i], TPCANParameter.PCAN_CHANNEL_CONDITION, out iBuffer, sizeof(UInt32));
                                if (( stsResult == TPCANStatus.PCAN_ERROR_OK ) && ( iBuffer == PCANBasic.PCAN_CHANNEL_AVAILABLE )) {
                                    cbb_channel.Items.Add(string.Format("PCAN-USB{0}", m_HandlesArray[i] & 0x0F));
                                }
                            }
                        }
                        cbb_channel.SelectedIndex = cbb_channel.Items.Count - 1;
                    } catch (DllNotFoundException) {
                        MessageBox.Show("Unable to find the library: PCANBasic.dll !", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(-1);
                    }

                    cbb_baudrates.Items.Clear();
                    string[] baudName = Enum.GetNames(typeof(TPCANBaudrate));
                    for (int i = 0; i < baudName.Length; i++) {
                        cbb_baudrates.Items.Add(baudName[i]);
                    }
                    cbb_baudrates.SelectedIndex = 0;

                    break;
                }
                default: {
                    break;
                }
            }
        }

        private void btn_initialize_Click(object sender, EventArgs e)
        {
            try {
                switch ((SupportedVendor)cbb_vendor.SelectedIndex) {
                    case SupportedVendor.NI_XNET: {
                        if (this.nican.Connect(cbb_channel.Text, Convert.ToUInt32(cbb_baudrates.Text))) {
                            for (int i = 0; i < this.motors.Length; i++) {
                                this.motors[i].SetDevice(ref this.nican);
                                this.nican.CanRxMsgEvent += this.motors[i].TpdoHandler;
                                this.motors[i].ResetComm();
                            }
                            this.set_obj_states(true);
                            this.OpenLogStream();
                            this.nican.CanTxHookEvent += this.CanTxLog;
                            this.nican.CanRxMsgEvent += this.CanRxLog;
                        }
                        break;
                    }
                    case SupportedVendor.PEAK: {
                        if (this.pcan.Connect(this.m_PcanHandle, this.m_BaudRate)) {
                            for(int i = 0; i < this.motors.Length; i++) {
                                this.motors[i].SetDevice(ref this.pcan);
                                this.pcan.CanRxMsgEvent += this.motors[i].TpdoHandler;
                                this.motors[i].ResetComm();
                            }
                            this.set_obj_states(true);
                            this.OpenLogStream();
                            this.pcan.CanTxHookEvent += this.CanTxLog;
                            this.pcan.CanRxMsgEvent += this.CanRxLog;
                        }
                        break;
                    }
                    default: {
                        break;
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_release_Click(object sender, EventArgs e)
        {
            this.pcan.Disconnect();
            this.pcan.CanTxHookEvent -= this.CanTxLog;
            this.pcan.CanRxMsgEvent -= this.CanRxLog;
            this.nican.Disconnect();
            this.nican.CanTxHookEvent -= this.CanTxLog;
            this.nican.CanRxMsgEvent -= this.CanRxLog;
            for(int i = 0; i < this.motors.Length; i++) {
                this.pcan.CanRxMsgEvent -= this.motors[i].TpdoHandler;
                this.nican.CanRxMsgEvent -= this.motors[i].TpdoHandler;
            }
            this.set_obj_states(false);
            this.CloseLogStream();
        }

        #endregion // General
        #region Motor One
        private void button_ResetNodeOne_Click(object sender, EventArgs e)
        {
            this.motors[0].ResetNode();
        }

        private void button_ResetCommOne_Click(object sender, EventArgs e)
        {
            this.motors[0].ResetComm();
        }

        private void button_ReadyMotorOne_Click(object sender, EventArgs e)
        {
            this.motors[0].Ready();
        }

        private void button_SwitchOnMotorOne_Click(object sender, EventArgs e)
        {
            this.motors[0].SwitchOn();
        }

        private void button_SwitchOffMotorOne_Click(object sender, EventArgs e)
        {
            this.motors[0].SwitchOff();
        }

        private void button_EnableMotorOne_Click(object sender, EventArgs e)
        {
            this.motors[0].EnableOperation();
        }

        private void button_DisableMotorOne_Click(object sender, EventArgs e)
        {
            this.motors[0].DisableOperation();
        }

        private void button_SetModeOne_Click(object sender, EventArgs e)
        {
            MODE_OF_OPERATION mode = MODE_OF_OPERATION.RESERVED;
            var modeNames = Enum.GetNames(typeof(MODE_OF_OPERATION));
            switch (modeNames[cbb_ModeOfOperationOne.SelectedIndex]) {
                case "PROFILE_VELOCITY": {
                    mode = MODE_OF_OPERATION.PROFILE_VELOCITY;
                    break;
                }
                case "TORQUE_PROFILE": {
                    mode = MODE_OF_OPERATION.TORQUE_PROFILE;
                    break;
                }
                default: {
                    break;
                }
            }
            this.motors[0].SetModeOfOperation(mode);

        }

        private void button_setTargetVelocityOne_Click(object sender, EventArgs e)
        {
            try {
                this.motors[0].SetTargetVelocity(Convert.ToInt32(textBox_targetVelocityOne.Text));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_setTargetTorqueOne_Click(object sender, EventArgs e)
        {
            try {
                double torque = Convert.ToDouble(textBox_targetTorqueOne.Text);
                double torqueBaseline = Math.Abs(Convert.ToDouble(textBox_torquePuOne.Text));
                if(Math.Abs(torque) <= torqueBaseline) {
                    double torquePu = Convert.ToDouble(textBox_targetTorqueOne.Text) / torqueBaseline;
                    this.motors[0].SetTargetTorque(torquePu);
                }
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_clearFaultMotorOne_Click(object sender, EventArgs e)
        {
            this.motors[0].ClearFault();
        }
        #endregion  // Motor One
        #region Motor Two
        private void button_ResetNodeTwo_Click(object sender, EventArgs e)
        {
            this.motors[1].ResetNode();
        }

        private void button_ResetCommTwo_Click(object sender, EventArgs e)
        {
            this.motors[1].ResetComm();
        }

        private void button_ReadyMotorTwo_Click(object sender, EventArgs e)
        {
            this.motors[1].Ready();
        }

        private void button_SwitchOnMotorTwo_Click(object sender, EventArgs e)
        {
            this.motors[1].SwitchOn();
        }

        private void button_SwitchOffMotorTwo_Click(object sender, EventArgs e)
        {
            this.motors[1].SwitchOff();
        }

        private void button_EnableMotorTwo_Click(object sender, EventArgs e)
        {
            this.motors[1].EnableOperation();
        }

        private void button_DisableMotorTwo_Click(object sender, EventArgs e)
        {
            this.motors[1].DisableOperation();
        }

        private void button_SetModeTwo_Click(object sender, EventArgs e)
        {
            MODE_OF_OPERATION mode = MODE_OF_OPERATION.RESERVED;
            var modeNames = Enum.GetNames(typeof(MODE_OF_OPERATION));
            switch (modeNames[cbb_ModeOfOperationTwo.SelectedIndex]) {
                case "PROFILE_VELOCITY": {
                    mode = MODE_OF_OPERATION.PROFILE_VELOCITY;
                    break;
                }
                default: {
                    break;
                }
            }
            this.motors[1].SetModeOfOperation(mode);
        }

        private void button_clearFaultMotorTwo_Click(object sender, EventArgs e)
        {
            this.motors[1].ClearFault();
        }

        private void button_setTargetVelocityTwo_Click(object sender, EventArgs e)
        {
            try {
                this.motors[1].SetTargetVelocity(Convert.ToInt32(textBox_targetVelocityTwo.Text));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion  // Motor Two
        #region Motor Three
        private void button_ResetNodeThree_Click(object sender, EventArgs e)
        {
            this.motors[2].ResetNode();
        }

        private void button_ResetCommThree_Click(object sender, EventArgs e)
        {
            this.motors[2].ResetComm();
        }

        private void button_ReadyMotorThree_Click(object sender, EventArgs e)
        {
            this.motors[2].Ready();
        }

        private void button_SwitchOnMotorThree_Click(object sender, EventArgs e)
        {
            this.motors[2].SwitchOn();
        }

        private void button_SwitchOffMotorThree_Click(object sender, EventArgs e)
        {
            this.motors[2].SwitchOff();
        }

        private void button_EnableMotorThree_Click(object sender, EventArgs e)
        {
            this.motors[2].EnableOperation();
        }

        private void button_DisableMotorThree_Click(object sender, EventArgs e)
        {
            this.motors[2].DisableOperation();
        }

        private void button_SetModeThree_Click(object sender, EventArgs e)
        {
            MODE_OF_OPERATION mode = MODE_OF_OPERATION.RESERVED;
            var modeNames = Enum.GetNames(typeof(MODE_OF_OPERATION));
            switch (modeNames[cbb_ModeOfOperationThree.SelectedIndex]) {
                case "PROFILE_VELOCITY": {
                    mode = MODE_OF_OPERATION.PROFILE_VELOCITY;
                    break;
                }
                default: {
                    break;
                }
            }
            this.motors[2].SetModeOfOperation(mode);
        }

        private void button_clearFaultMotorThree_Click(object sender, EventArgs e)
        {
            this.motors[2].ClearFault();
        }

        private void button_setTargetVelocityThree_Click(object sender, EventArgs e)
        {
            try {
                this.motors[2].SetTargetVelocity(Convert.ToInt32(textBox_targetVelocityThree.Text));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion // Motor Three
        #endregion  // Button Event

        #region Timer Event
        private void timer_update_Tick(object sender, EventArgs e)
        {
            double currentBaselineOne = 0.0f;
            double torqueBaselineOne = 0.0f;
            double currentBaselineTwo = 0.0f;
            double torqueBaselineTwo = 0.0f;
            double currentBaselineThree = 0.0f;
            double torqueBaselineThree = 0.0f;

            try {
                currentBaselineOne = Convert.ToDouble(textBox_currentPuOne.Text);
                torqueBaselineOne = Convert.ToDouble(textBox_torquePuOne.Text);
                currentBaselineTwo = 1.0; /// TODO
                torqueBaselineTwo = 1.0; /// TODO
                currentBaselineThree = 1.0; /// TODO;
                torqueBaselineThree = 1.0; /// TODO

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            this.Plot();

            #region Log
            DateTime timestamp = DateTime.Now;
            float elapsed = (timestamp.Ticks - this.startLogTime.Ticks) / 10000000.0f;
            string logStr = "";
            logStr += timestamp.ToString() + separator;
            logStr += elapsed + separator;
            logStr += this.motors[0].state.ToString() + separator;
            logStr += ( (MODE_OF_OPERATION)this.motors[0].mode ).ToString() + separator;
            logStr += ( this.motors[0].DcLinkCircuitVoltage / 1000.0f ).ToString("0.0") + separator;
            logStr += this.motors[0].PositionActualValue + separator;
            logStr += this.motors[0].VelocityActualValue + separator;
            logStr += ( this.motors[0].CurrentActualValue * currentBaselineOne ).ToString("0.000000") + separator;
            logStr += ( Convert.ToDouble(this.motors[0].TorqueActualValue) * torqueBaselineOne ).ToString("0.000000") + separator;
            logStr += this.motors[0].PhaseVoltageValue.ToString("0.000000") + separator;
            logStr += this.motors[0].temperature.ToString("0.0") + separator;
            logStr += this.motors[0].manufacturerStatusRegister.ToString("X8") + separator;
            logStr += Environment.NewLine;
            if (this.binary_writer_log != null) {
                this.binary_writer_log.Write(Encoding.Default.GetBytes(logStr));
            }
            #endregion

            /*
             * AXLE 1 Update
             */
            switch (this.motors[0].state) {
                case DEVICE_STATE.OPERATION_ENABLE: {
                    switch((MODE_OF_OPERATION)this.motors[0].mode) {
                        case MODE_OF_OPERATION.TORQUE_PROFILE: {
                            groupBox_ProfileTorqueOne.Enabled = true;
                            groupBox_ProfileVelocityOne.Enabled = false;
                            break;
                        }
                        case MODE_OF_OPERATION.PROFILE_VELOCITY: {
                            groupBox_ProfileTorqueOne.Enabled = false;
                            groupBox_ProfileVelocityOne.Enabled = true;
                            break;
                        }
                        default: {
                            groupBox_ProfileVelocityOne.Enabled = false;
                            groupBox_ProfileTorqueOne.Enabled = false;
                            textBox_targetVelocityOne.Text = "0";
                            textBox_targetTorqueOne.Text = "0.0";
                            break;
                        }
                    }
                    break;
                }
                default: {
                    groupBox_ProfileVelocityOne.Enabled = false;
                    groupBox_ProfileTorqueOne.Enabled = false;
                    textBox_targetVelocityOne.Text = "0";
                    textBox_targetTorqueOne.Text = "0.0";
                    break;
                }
            }

            if (this.motors[0].state == DEVICE_STATE.FAULT) {
                button_clearFaultMotorOne.Enabled = true;
            } else {
                button_clearFaultMotorOne.Enabled = false;
            }

            this.label_stateMotorOne.Text = "State: " + this.motors[0].state.ToString();
            this.label_ModeOfOperationOne.Text = "Mode: " + ( (MODE_OF_OPERATION)this.motors[0].mode ).ToString();
            this.label_dcLinkMotorOne.Text = "DC Link: " + ( this.motors[0].DcLinkCircuitVoltage / 1000.0f ).ToString("0.0");
            this.label_actualPositionMotorOne.Text = "Position: " + this.motors[0].PositionActualValue;
            this.label_actualSpeedMotorOne.Text = "Speed: " + this.motors[0].VelocityActualValue;
            this.label_actualCurrentMotorOne.Text = "Current: " + ( this.motors[0].CurrentActualValue * currentBaselineOne ).ToString("0.000");
            this.label_actualTorqueMotorOne.Text = "Torque: " + ( Convert.ToDouble(this.motors[0].TorqueActualValue) * torqueBaselineOne ).ToString("0.000000");
            this.label_phaseVoltMotorOne.Text = "Phase V: " + this.motors[0].PhaseVoltageValue.ToString("0.0000");
            this.label_temperatureMotorOne.Text = "Temp: " + this.motors[0].temperature.ToString("0.0");
            this.label_statusOne.Text = "Status: 0x" + this.motors[0].manufacturerStatusRegister.ToString("X8");
            /*
             * AXLE 2 Update
             */
            if (this.motors[1].state == DEVICE_STATE.OPERATION_ENABLE) {
                groupBox_ProfileVelocityTwo.Enabled = true;
            } else {
                groupBox_ProfileVelocityTwo.Enabled = false;
                textBox_targetVelocityTwo.Text = "0";
            }

            if (this.motors[1].state == DEVICE_STATE.FAULT) {
                button_clearFaultMotorTwo.Enabled = true;
            } else {
                button_clearFaultMotorTwo.Enabled = false;
            }

            this.label_stateMotorTwo.Text = "State: " + this.motors[1].state.ToString();
            this.label_ModeOfOperationTwo.Text = "Mode: " + ( (MODE_OF_OPERATION)this.motors[1].mode ).ToString();
            this.label_dcLinkMotorTwo.Text = "DC Link: " + ( this.motors[1].DcLinkCircuitVoltage / 1000.0f ).ToString("0.0");
            this.label_actualPositionMotorTwo.Text = "Position: " + this.motors[1].PositionActualValue;
            this.label_actualSpeedMotorTwo.Text = "Speed: " + this.motors[1].VelocityActualValue;
            this.label_actualCurrentMotorTwo.Text = "Current: " + ( this.motors[1].CurrentActualValue * currentBaselineTwo ).ToString("0.000");

            /*
             * AXLE 3 Update
             */
            if (this.motors[2].state == DEVICE_STATE.OPERATION_ENABLE) {
                groupBox_ProfileVelocityThree.Enabled = true;
            } else {
                groupBox_ProfileVelocityThree.Enabled = false;
                textBox_targetVelocityThree.Text = "0";
            }

            if (this.motors[2].state == DEVICE_STATE.FAULT) {
                button_clearFaultMotorThree.Enabled = true;
            } else {
                button_clearFaultMotorThree.Enabled = false;
            }

            this.label_stateMotorThree.Text = "State: " + this.motors[2].state.ToString();
            this.label_ModeOfOperationThree.Text = "Mode: " + ( (MODE_OF_OPERATION)this.motors[2].mode ).ToString();
            this.label_dcLinkMotorThree.Text = "DC Link: " + ( this.motors[2].DcLinkCircuitVoltage / 1000.0f ).ToString("0.0");
            this.label_actualPositionMotorThree.Text = "Position: " + this.motors[2].PositionActualValue;
            this.label_actualSpeedMotorThree.Text = "Speed: " + this.motors[2].VelocityActualValue;
            this.label_actualCurrentMotorThree.Text = "Current: " + ( this.motors[2].CurrentActualValue * currentBaselineThree ).ToString("0.000");
        }
        #endregion // Timer Event

        #region Plotting
        private void Plot()
        {
            double[] position;
            DateTime[] positionTime;
            double[] positionElapsedTime;
            double[] speed;
            DateTime[] speedTime;
            double[] speedElapsedTime;
            double[] current;
            DateTime[] currentTime;
            double[] currentElapsedTime;
            double[] temperature;
            DateTime[] temperatureTime;
            double[] tempeartureElapsedTime;
            double[] torque;
            DateTime[] torqueTime;
            double[] torqueElapsedTime;

            double currentBaseline = 0.0f;
            double torqueBaseline = 0.0f;
            double tpdoInterval = 0.0f;

            try {
                currentBaseline = Convert.ToDouble(textBox_currentPuOne.Text);
                torqueBaseline = Convert.ToDouble(textBox_torquePuOne.Text);
                tpdoInterval = Convert.ToSingle(textBox_TPDOInterval) / 1000.0f;
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }

            /*
             * AXLE 1 Plot
             */
            if (!this.checkBox_plotPauseOne.Checked) {
                this.formsPlot_MotorOne.Plot.Clear();
                lock (this.motors[0]) {
                    position = this.motors[0].position.GetValue();
                    positionTime = this.motors[0].position.GetTime();
                    positionElapsedTime = new double[positionTime.Length];
                    speed = this.motors[0].speed.GetValue();
                    speedTime = this.motors[0].speed.GetTime();
                    speedElapsedTime = new double[speedTime.Length];
                    current = this.motors[0].current.GetValue();
                    currentTime = this.motors[0].current.GetTime();
                    currentElapsedTime = new double[currentTime.Length];
                    temperature = this.motors[0].tempC.GetValue();
                    temperatureTime = this.motors[0].tempC.GetTime();
                    tempeartureElapsedTime = new double[temperatureTime.Length];
                    torque = this.motors[0].torque.GetValue();
                    torqueTime = this.motors[0].torque.GetTime();
                    torqueElapsedTime = new double[torqueTime.Length];
                }

                if (position.Length != 0) {
                    for(int i = 0; i < positionTime.Length; i++) {
                        positionElapsedTime[i] = (positionTime[i].Ticks - this.startLogTime.Ticks) / 10000000.0f;
                    }
                }
                if (speed.Length != 0) {
                    for (int i = 0; i < speedTime.Length; i++) {
                        speedElapsedTime[i] = ( speedTime[i].Ticks - this.startLogTime.Ticks ) / 10000000.0f;
                    }
                }
                if (current.Length != 0) {
                    for(int i = 0; i < currentTime.Length; i++) {
                        current[i] = current[i] * currentBaseline;
                        currentElapsedTime[i] = (currentTime[i].Ticks - this.startLogTime.Ticks) / 10000000.0f;
                    }
                }
                if(temperature.Length != 0) {
                    for(int i = 0; i < temperatureTime.Length; i++) {
                        tempeartureElapsedTime[i] = (temperatureTime[i].Ticks - this.startLogTime.Ticks) / 10000000.0f;
                    }
                } 
                if(torque.Length != 0) {
                    for(int i = 0; i < torqueTime.Length; i++) {
                        torque[i] = torque[i] * torqueBaseline;
                        torqueElapsedTime[i] = (torqueTime[i].Ticks - this.startLogTime.Ticks) / 10000000.0f;
                    }
                }

                if (( this.checkBox_PositionMotorOne.Checked ) && ( position.Length > 0 )) {
                    this.formsPlot_MotorOne.Plot.AddSignalXY(positionElapsedTime, position, label: "Rev", color: Color.Red);
                }
                if (( this.checkBox_SpeedMotorOne.Checked ) && ( speed.Length > 0 )) {
                    this.formsPlot_MotorOne.Plot.AddSignalXY(speedElapsedTime, speed, label: "Speed", color: Color.Blue);
                }
                if (( this.checkBox_CurrentMotorOne.Checked ) && ( current.Length > 0 )) {
                    this.formsPlot_MotorOne.Plot.AddSignalXY(currentElapsedTime, current, label: "Current", color: Color.Green);
                }
                if (( this.checkBox_TempMotorOne.Checked ) && ( temperature.Length > 0 )) {
                    this.formsPlot_MotorOne.Plot.AddSignalXY(tempeartureElapsedTime, temperature, label: "Temperature", color: Color.Black);
                }
                if((this.checkBox_TorqueMotorOne.Checked) && (torque.Length > 0)) {
                    this.formsPlot_MotorOne.Plot.AddSignalXY(torqueElapsedTime, torque, label: "Torque", color: Color.Violet);
                }
                this.formsPlot_MotorOne.Plot.Legend(location: ScottPlot.Alignment.UpperLeft);
                this.formsPlot_MotorOne.Plot.XLabel("samples");
                this.formsPlot_MotorOne.Refresh();
            }
        }
        private void button_clearPlotOne_Click(object sender, EventArgs e)
        {
            lock (this.motors[0]) {
                this.motors[0].position.Clear();
                this.motors[0].speed.Clear();
                this.motors[0].current.Clear();
                this.motors[0].tempC.Clear();
                this.motors[0].torque.Clear();
            }
        }
        #endregion

        #region Log
        private string GenerateFileName(string name, string ext)
        {
            string streamFileName = "";

            try {
                DateTime dateTimeStamp = DateTime.Now;
                string logLocation = Environment.CurrentDirectory;

                logLocation += "\\logs";
                if (!Directory.Exists(logLocation)) Directory.CreateDirectory(logLocation);

                logLocation += "\\" + dateTimeStamp.Year.ToString("D4");
                if (!Directory.Exists(logLocation)) Directory.CreateDirectory(logLocation);

                logLocation += "\\" + dateTimeStamp.Month.ToString("D2");
                if (!Directory.Exists(logLocation)) Directory.CreateDirectory(logLocation);

                logLocation += "\\" + dateTimeStamp.Day.ToString("D2");
                if (!Directory.Exists(logLocation)) Directory.CreateDirectory(logLocation);

                streamFileName = Path.Combine(logLocation, name + "_" +
                                dateTimeStamp.Year.ToString("D4") +
                                dateTimeStamp.Month.ToString("D2") +
                                dateTimeStamp.Day.ToString("D2") + "_" +
                                dateTimeStamp.Hour.ToString("D2") +
                                dateTimeStamp.Minute.ToString("D2") +
                                dateTimeStamp.Second.ToString("D2") + "." + ext);

                this.startLogTime = dateTimeStamp;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            return streamFileName;
        }
        private void OpenLogStream()
        {
            string header = "";
            /* Close and Create new Stream */
            this.CloseLogStream();
            #region Log
            this.file_name_log = this.GenerateFileName("LA", "csv");
            this.file_stream_log = new FileStream(this.file_name_log, FileMode.Append, FileAccess.Write, FileShare.Read);
            this.binary_writer_log = new BinaryWriter(this.file_stream_log);
            header = "PC Timestamp" + separator +
                "elapsed(second)" + separator +
                "state" + separator +
                "mode" + separator +
                "DC link" + separator +
                "position" + separator +
                "speed" + separator +
                "current" + separator +
                "torque" + separator +
                "phaseV" + separator +
                "temperature" + separator +
                "status" +
                Environment.NewLine;
            this.binary_writer_log.Write(Encoding.Default.GetBytes(header));
            this.label_logfilename.Text = "Log: " + Path.GetFileName(this.file_name_log);
            #endregion
            #region Raw CAN
            this.file_name_can = this.GenerateFileName("CAN", "csv");
            this.file_stream_can = new FileStream(this.file_name_can, FileMode.Append, FileAccess.Write, FileShare.Read);
            this.binary_writer_can = new BinaryWriter(this.file_stream_can);
            header = "PC Timestamp" + separator +
                "elapsed(second)" + separator +
                "Direction" + separator +
                "CAN-ID" + separator +
                "length" + separator +
                "Data" +
                Environment.NewLine;
            this.binary_writer_can.Write(Encoding.Default.GetBytes(header));
            #endregion
        }
        private void CloseLogStream()
        {
            #region LOG
            if (null != this.binary_writer_log) {
                this.binary_writer_log.Flush();
                this.binary_writer_log.Close();
                this.binary_writer_log = null;
            }

            if (null != this.file_stream_log) {
                this.file_stream_log.Close();
                this.file_stream_log = null;
            }
            #endregion
            #region CAN
            if (null != this.binary_writer_can) {
                this.binary_writer_can.Flush();
                this.binary_writer_can.Close();
                this.binary_writer_can = null;
            }
            if (null != this.file_stream_can) {
                this.file_stream_can.Close();
                this.file_stream_can = null;
            }
            #endregion

            this.label_logfilename.Text = "Log: ---";
        }
        private void CanTxLog(object sender, CanRxMsgArgs e)
        {
            if (this.binary_writer_can != null) {
                DateTime timestamp = DateTime.Now;
                float elapsed = ( timestamp.Ticks - this.startLogTime.Ticks ) / 10000000.0f;
                string logStr = "";
                logStr += timestamp.ToString() + separator;
                logStr += elapsed + separator;
                logStr += "TX" + separator;
                logStr += e.msgId.ToString() + separator;
                logStr += e.len.ToString() + separator;
                for (int i = 0; i < e.len; i++) {
                    logStr += e.data[i].ToString() + " ";
                }
                logStr += Environment.NewLine;
                this.binary_writer_can.Write(Encoding.Default.GetBytes(logStr));
            }
        }
        private void CanRxLog(object sender, CanRxMsgArgs e)
        {
            if (this.binary_writer_can != null) {
                DateTime timestamp = DateTime.Now;
                float elapsed = ( timestamp.Ticks - this.startLogTime.Ticks ) / 10000000.0f;
                string logStr = "";
                logStr += timestamp.ToString() + separator;
                logStr += elapsed + separator;
                logStr += "RX" + separator;
                logStr += e.msgId.ToString() + separator;
                logStr += e.len.ToString() + separator;
                for (int i = 0; i < e.len; i++) {
                    logStr += e.data[i].ToString() + " ";
                }
                logStr += Environment.NewLine;
                this.binary_writer_can.Write(Encoding.Default.GetBytes(logStr));
            }
        }
        #endregion
        #endregion  // Methods

    }
}
