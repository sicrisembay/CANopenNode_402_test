using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                    cbb_baudrates.SelectedIndex = 3;

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
            this.nican.Disconnect();
            for(int i = 0; i < this.motors.Length; i++) {
                this.pcan.CanRxMsgEvent -= this.motors[i].TpdoHandler;
                this.nican.CanRxMsgEvent -= this.motors[i].TpdoHandler;
            }
            this.set_obj_states(false);
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
        #endregion  // Button Event

        #endregion  // Methods

        private void timer_update_Tick(object sender, EventArgs e)
        {
            /*
             * AXLE 1 Update
             */
            if(this.motors[0].state == DEVICE_STATE.OPERATION_ENABLE) {
                groupBox_ProfileVelocityOne.Enabled = true;
            } else {
                groupBox_ProfileVelocityOne.Enabled = false;
                textBox_targetVelocityOne.Text = "0";
            }

            if(this.motors[0].state == DEVICE_STATE.FAULT) {
                button_clearFaultMotorOne.Enabled = true;
            } else {
                button_clearFaultMotorOne.Enabled = false;
            }

            this.label_stateMotorOne.Text = "State: " + this.motors[0].state.ToString();
            this.label_ModeOfOperationOne.Text = "Mode: " + ((MODE_OF_OPERATION) this.motors[0].mode).ToString();
            this.label_dcLinkMotorOne.Text = "DC Link: " + ( this.motors[0].DcLinkCircuitVoltage / 1000.0f ).ToString("0.0");
            this.label_actualPositionMotorOne.Text = "Position: " + this.motors[0].PositionActualValue;
            this.label_actualSpeedMotorOne.Text = "Speed: " + this.motors[0].VelocityActualValue;
            this.label_actualCurrentMotorOne.Text = "Current: " + ( this.motors[0].CurrentActualValue / 1000.0f ).ToString("0.000");

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
            this.label_actualCurrentMotorTwo.Text = "Current: " + ( this.motors[1].CurrentActualValue / 1000.0f ).ToString("0.000");

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
            this.label_actualCurrentMotorThree.Text = "Current: " + ( this.motors[2].CurrentActualValue / 1000.0f ).ToString("0.000");
        }

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
    }
}
