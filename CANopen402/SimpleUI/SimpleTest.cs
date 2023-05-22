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
            this.cbb_ModeOfOperation.Items.Clear();
            var modesNames = Enum.GetNames(typeof(MODE_OF_OPERATION));
            for(int i = 0; i < modesNames.Length; i++) {
                this.cbb_ModeOfOperation.Items.Add(modesNames[i]);
            }
            this.cbb_ModeOfOperation.SelectedIndex = 1;

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

        private void button_ResetNodes_Click(object sender, EventArgs e)
        {
            this.motors[0].ResetNode();
        }

        private void button_ResetComms_Click(object sender, EventArgs e)
        {
            this.pcan.SendStandard(0, new byte[] { 0x82, 0x00 });
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

        private void button_SetMode_Click(object sender, EventArgs e)
        {
            MODE_OF_OPERATION mode = MODE_OF_OPERATION.RESERVED;
            var modeNames = Enum.GetNames(typeof(MODE_OF_OPERATION));
            switch (modeNames[cbb_ModeOfOperation.SelectedIndex]) {
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

        private void button_setTargetVelocity_Click(object sender, EventArgs e)
        {
            try {
                this.motors[0].SetTargetVelocity(Convert.ToInt32(textBox_targetVelocity.Text));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion  // Button Event

        #endregion  // Methods

        private void timer_update_Tick(object sender, EventArgs e)
        {
            if(this.motors[0].state == DEVICE_STATE.OPERATION_ENABLE) {
                groupBox_ProfileVelocity.Enabled = true;
            } else {
                groupBox_ProfileVelocity.Enabled = false;
                textBox_targetVelocity.Text = "0";
            }

            if(this.motors[0].state == DEVICE_STATE.FAULT) {
                button_clearFaultMotorOne.Enabled = true;
            } else {
                button_clearFaultMotorOne.Enabled = false;
            }

            this.label_stateMotorOne.Text = "State: " + this.motors[0].state.ToString();
            this.label_ModeOfOperation.Text = "Mode: " + ((MODE_OF_OPERATION) this.motors[0].mode).ToString();
            this.label_dcLinkMotorOne.Text = "DC Link: " + ( this.motors[0].DcLinkCircuitVoltage / 1000.0f ).ToString("0.0");
            this.label_actualPositionMotorOne.Text = "Position: " + this.motors[0].PositionActualValue;
            this.label_actualSpeedMotorOne.Text = "Speed: " + this.motors[0].VelocityActualValue;
            this.label_actualCurrentMotorOne.Text = "Current: " + ( this.motors[0].CurrentActualValue / 1000.0f ).ToString("0.000");
        }

        private void button_clearFaultMotorOne_Click(object sender, EventArgs e)
        {
            this.motors[0].ClearFault();
        }
    }
}
