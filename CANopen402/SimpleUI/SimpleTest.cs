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
        #endregion // Members

        public SimpleTest()
        {
            InitializeComponent();

            /* Vendor combobox */
            this.cbb_vendor.Items.Clear();
            var vendorNames = Enum.GetNames(typeof(SupportedVendor));
            for (int i = 0; i < vendorNames.Length; i++) {
                this.cbb_vendor.Items.Add(vendorNames[i]);
            }
            this.cbb_vendor.SelectedIndex = 0;

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
                            this.set_obj_states(true);
                        }
                        break;
                    }
                    case SupportedVendor.PEAK: {
                        if (this.pcan.Connect(this.m_PcanHandle, this.m_BaudRate)) {
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
            this.set_obj_states(false);
        }

        #endregion  // Button Event
        #endregion  // Methods
    }
}
