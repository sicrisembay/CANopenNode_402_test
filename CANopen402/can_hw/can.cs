using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Peak.Can.Basic;
using TPCANHandle = System.Byte;
using NationalInstruments.EmbeddedNetworks.Interop;

namespace can_hw
{
    public enum SupportedVendor : byte
    {
        NI_XNET = 0,
        PEAK,
    }

    public class CanRxMsgArgs : EventArgs
    {
        public readonly UInt32 msgId;
        public readonly byte msgType;
        public readonly byte len;
        public readonly byte[] data;
        public readonly UInt64 timestamp;
        public CanRxMsgArgs(UInt32 msgId, byte msgType, byte[] data, UInt64 timestamp)
        {
            this.msgId = msgId;
            this.msgType = msgType;
            if(data != null) {
                this.len = (byte)data.Length;
            } else {
                this.len = 0;
            }
            if(this.len > 0)
            {
                this.data = new byte[this.len];
                data.CopyTo(this.data, 0);
            }
            this.timestamp = timestamp;
        }
    }

    public delegate void CanRxMsgHandler(object sender, CanRxMsgArgs e);
    public delegate void CanTxHook(object sender, CanRxMsgArgs e);

    public class pcan_usb
    {
        #region members
        private TPCANHandle m_PcanHandle;
        private TPCANBaudrate m_Baudrate;
        private bool bConnected = false;
        public event CanRxMsgHandler CanRxMsgEvent;
        public event CanTxHook CanTxHookEvent;
        private System.Threading.AutoResetEvent m_ReceiveEvent;
        private System.Threading.Thread m_ReadThread;
        #endregion

        #region methods

        #region Event Handlers
        #region Constructor/Destructor
        public pcan_usb()
        {
            this.m_PcanHandle = 0x00;
            this.m_Baudrate = TPCANBaudrate.PCAN_BAUD_250K;
            this.m_ReadThread = null;
        }

        ~pcan_usb()
        {
            if(this.m_PcanHandle != 0x00)
            {
                PCANBasic.Uninitialize(this.m_PcanHandle);
            }
            if (this.m_ReadThread != null)
            {
                this.m_ReadThread.Abort();
                this.m_ReadThread.Join();
                this.m_ReadThread = null;
            }
        }
        #endregion

        #region Message Handler
        private void CANReadThreadFunc()
        {
            UInt32 iBuffer;
            TPCANStatus stsResult;

            iBuffer = Convert.ToUInt32(m_ReceiveEvent.SafeWaitHandle.DangerousGetHandle().ToInt32());
            // Sets the handle of the Receive-Event.
            //
            stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_RECEIVE_EVENT, ref iBuffer, sizeof(UInt32));

            if (stsResult != TPCANStatus.PCAN_ERROR_OK)
            {
                Console.WriteLine("pcan::CANReadThreadFunc Error: " + stsResult);
                return;
            }

            // While this mode is selected
            while (true) //(rdbEvent.Checked)
            {
                // Waiting for Receive-Event
                // 
                if (m_ReceiveEvent.WaitOne(50))
                {
                    TPCANMsg CANMsg;
                    TPCANTimestamp CANTimeStamp;
                    do
                    {
                        stsResult = PCANBasic.Read(this.m_PcanHandle, out CANMsg, out CANTimeStamp);
                        if(stsResult == TPCANStatus.PCAN_ERROR_OK)
                        {
                            if(this.CanRxMsgEvent != null)
                            {
                                UInt32 msgId = CANMsg.ID;
                                byte msgType = (byte)CANMsg.MSGTYPE;
                                byte[] data = null;
                                if (CANMsg.LEN > 0) {
                                    data = new byte[CANMsg.LEN];
                                    Array.Copy(CANMsg.DATA, 0, data, 0, data.Length);

                                    UInt64 timestamp_us = (UInt64)( CANTimeStamp.micros ) +
                                                    ( (UInt64)( CANTimeStamp.millis ) * 1000 ) +
                                                    ( (UInt64)( CANTimeStamp.millis_overflow ) * ( 2 ^ 32 ) );

                                    this.CanRxMsgEvent(this, new CanRxMsgArgs(msgId, msgType, data, timestamp_us));
                                }
                            }
                        }
                    } while (this.bConnected && (!Convert.ToBoolean(stsResult & TPCANStatus.PCAN_ERROR_QRCVEMPTY)));
                }
            }
        }
        #endregion
        #endregion

        public bool Connect(TPCANHandle pcanHandle, TPCANBaudrate baudrate)
        {
            TPCANStatus stsResult;

            if((pcanHandle < PCANBasic.PCAN_USBBUS1) ||
               (pcanHandle > PCANBasic.PCAN_USBBUS8))
            {
                Console.WriteLine("Only PCAN USB is supported!");
                return false;
            }

            this.m_PcanHandle = pcanHandle;
            this.m_Baudrate = baudrate;

            stsResult = PCANBasic.Initialize(this.m_PcanHandle, this.m_Baudrate);
            if (stsResult != TPCANStatus.PCAN_ERROR_OK)
            {
                Console.WriteLine("An error occurred: " + stsResult);
                return false;
            }

            /* Create thread for reading incoming CAN messages */
            this.m_ReceiveEvent = new System.Threading.AutoResetEvent(false);
            System.Threading.ThreadStart threadDelegate = new System.Threading.ThreadStart(this.CANReadThreadFunc);
            if (this.m_ReadThread != null)
            {
                /* Destroy previous thread instance */
                this.m_ReadThread.Abort();
                this.m_ReadThread.Join();
                this.m_ReadThread = null;
            }
            this.m_ReadThread = new System.Threading.Thread(threadDelegate);
            this.m_ReadThread.Name = "pcan_usb worker";
            this.m_ReadThread.IsBackground = true;
            this.m_ReadThread.Start();

            this.bConnected = true;

            return true;
        }

        public void Disconnect()
        {
            if (this.m_PcanHandle != 0x00)
            {
                PCANBasic.Uninitialize(this.m_PcanHandle);
                this.m_PcanHandle = 0x00;
            }
            if (this.m_ReadThread != null)
            {
                this.m_ReadThread.Abort();
                this.m_ReadThread.Join();
                this.m_ReadThread = null;
            }

            this.bConnected = false;
        }

        public bool SendStandard(UInt32 can_id, byte[] data)
        {
            if (this.bConnected)
            {
                TPCANStatus stsResult;
                if(this.CanTxHookEvent != null) {
                    this.CanTxHookEvent(this, new CanRxMsgArgs(can_id, 0, data, 0));
                }
                TPCANMsg CANMsg = new TPCANMsg();
                CANMsg.ID = can_id;
                CANMsg.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                CANMsg.LEN = Convert.ToByte(data.Length);
                CANMsg.DATA = new byte[8];
                Array.Copy(data, 0, CANMsg.DATA, 0, data.Length);
                stsResult = PCANBasic.Write(this.m_PcanHandle, ref CANMsg);
                if (stsResult == TPCANStatus.PCAN_ERROR_OK)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("pcan::SendStandard error: " + stsResult);
                    return false;
                }
            } else
            {
                Console.WriteLine("pcan::SendStandard error: Not Connected");
                return false;
            }
        }
        #endregion
    }

    public class ni_usb
    {
        #region members
        private const int NI_XNET_FRAME_SIZE = 24;
        private const int NI_XNET_TIMESTAMP_OFFSET = 0;
        private const int NI_XNET_MSGID_OFFSET = 8;
        private const int NI_XNET_FRAMETYPE_OFFSET = 12;
        private const int NI_XNET_LENGTH_OFFSET = 15;
        private const int NI_XNET_PAYLOAD_OFFSET = 16;
        private const int MAX_N_FRAMES = 1500;
        private const int MAX_RAW_DATA_LEN = MAX_N_FRAMES * NI_XNET_FRAME_SIZE;

        private niXNET xnetSessionTx;
        private niXNET xnetSessionRx;
        private UInt32 baudRate;
        private bool bConnected;
        public event CanRxMsgHandler CanRxMsgEvent;
        public event CanTxHook CanTxHookEvent;
        private System.Threading.Thread m_ReadThread;
        #endregion

        #region methods

        #region Constructors
        public ni_usb()
        {
            this.xnetSessionTx = null;
            this.xnetSessionRx = null;
            this.baudRate = 0;
            this.bConnected = false;
        }

        ~ni_usb()
        {
            if (this.m_ReadThread != null)
            {
                this.m_ReadThread.Abort();
                this.m_ReadThread.Join();
                this.m_ReadThread = null;
            }
        }
        #endregion

        #region Message Handler
        private void CANReadThreadFunc()
        {
            byte[] rawData = new byte[MAX_RAW_DATA_LEN];
            uint numBytes;
            uint numFrames;

            while (true)
            {
                Thread.Sleep(10);

                if ((!this.bConnected) || (this.xnetSessionRx == null))
                {
                    continue;
                }

                try
                {
                    this.xnetSessionRx.nx_ReadFrame(rawData, MAX_RAW_DATA_LEN, 0, out numBytes);
                    numFrames = numBytes / NI_XNET_FRAME_SIZE;

                    if (numFrames == 0) continue;

                    /* Handle frame one at a time */
                    for(int i = 0; i < numFrames; i++)
                    {
                        /* Accept only CAN frame */
                        byte flag = rawData[i * NI_XNET_FRAME_SIZE + NI_XNET_FRAMETYPE_OFFSET];
                        if(((flag >> 5) & 0x07) == 0x00)
                        {
                            /* CAN frame */
                            UInt64 timestamp = BitConverter.ToUInt64(rawData, i * NI_XNET_FRAME_SIZE + NI_XNET_TIMESTAMP_OFFSET);
                            UInt32 msgId = BitConverter.ToUInt32(rawData, i * NI_XNET_FRAME_SIZE + NI_XNET_MSGID_OFFSET);
                            byte len = rawData[i * NI_XNET_FRAME_SIZE + NI_XNET_LENGTH_OFFSET];
                            byte[] payload = null;
                            if (len > 0)
                            {
                                payload = new byte[len];
                                Array.Copy(rawData, i * NI_XNET_FRAME_SIZE + NI_XNET_PAYLOAD_OFFSET,
                                           payload, 0, payload.Length);

                                if (this.CanRxMsgEvent != null) {
                                    this.CanRxMsgEvent(this, new CanRxMsgArgs(msgId, 0x00, payload, timestamp));
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        #endregion

        #region Event Handlers

        public bool Connect(string xnetInterface, UInt32 baudRate)
        {
            string databaseName = ":memory:";
            string clusterName = "";
            string xnetList = "";
            UInt32 xnetMode;

            try
            {
                /* Create Rx Sesstion. Clear existing session, if any */
                if(this.xnetSessionRx != null)
                {
                    this.xnetSessionRx.nx_Clear();
                    this.xnetSessionRx.Dispose();
                    this.xnetSessionRx = null;
                }
                xnetMode = niXNET.xNETConstants.nxMode_FrameInStream;
                this.xnetSessionRx = new niXNET(databaseName, clusterName, xnetList, xnetInterface, xnetMode);
                this.xnetSessionRx.nx_SetProperty(niXNET.xNETConstants.nxPropSession_IntfBaudRate, sizeof(UInt32), baudRate);

                /* Create Tx Session. Clear existing session, if any */
                if (this.xnetSessionTx != null)
                {
                    this.xnetSessionTx.nx_Clear();
                    this.xnetSessionTx.Dispose();
                    this.xnetSessionTx = null;
                }
                xnetMode = niXNET.xNETConstants.nxMode_FrameOutStream;
                this.xnetSessionTx = new niXNET(databaseName, clusterName, xnetList, xnetInterface, xnetMode);
                this.xnetSessionTx.nx_SetProperty(niXNET.xNETConstants.nxPropSession_IntfBaudRate, sizeof(UInt32), baudRate);
                this.xnetSessionTx.nx_GetProperty(niXNET.xNETConstants.nxPropSession_IntfBaudRate, sizeof(UInt32), out this.baudRate);

                /* Create thread to handle received packets */
                System.Threading.ThreadStart threadDelegate = new System.Threading.ThreadStart(this.CANReadThreadFunc);
                if (this.m_ReadThread != null)
                {
                    /* Destroy previous thread instance */
                    this.m_ReadThread.Abort();
                    this.m_ReadThread.Join();
                    this.m_ReadThread = null;
                }
                this.m_ReadThread = new System.Threading.Thread(threadDelegate);
                this.m_ReadThread.Name = "ni xnet worker";
                this.m_ReadThread.IsBackground = true;
                this.m_ReadThread.Start();

                this.bConnected = true;
            }
            catch
            {
                throw;
            }
            return true;
        }

        public bool Disconnect()
        {
            if (this.m_ReadThread != null)
            {
                this.m_ReadThread.Abort();
                this.m_ReadThread.Join();
                this.m_ReadThread = null;
            }

            this.bConnected = false;

            if (this.xnetSessionRx != null)
            {
                this.xnetSessionRx.nx_Clear();
                this.xnetSessionRx.Dispose();
                this.xnetSessionRx = null;
            }

            if (this.xnetSessionTx != null)
            {
                this.xnetSessionTx.nx_Clear();
                this.xnetSessionTx.Dispose();
                this.xnetSessionTx = null;
            }
            return true;
        }

        public bool SendStandard(UInt32 can_id, byte[] data)
        {
            if((this.xnetSessionTx == null) || !this.bConnected)
            {
                Console.WriteLine("ni_usb: SendStandard: invalid Tx session or not connected!");
                return false;
            }

            if(this.CanTxHookEvent != null) {
                this.CanTxHookEvent(this, new CanRxMsgArgs(can_id, 0, data, 0));
            }

            byte[] buffer = new byte[NI_XNET_FRAME_SIZE];
            /* CAN Identifier */
            buffer[NI_XNET_MSGID_OFFSET] = (byte)(can_id & 0x000000FF);
            buffer[NI_XNET_MSGID_OFFSET + 1] = (byte)((can_id >> 8) & 0x000000FF);
            buffer[NI_XNET_MSGID_OFFSET + 2] = (byte)((can_id >> 16) & 0x000000FF);
            buffer[NI_XNET_MSGID_OFFSET + 3] = (byte)((can_id >> 24) & 0x000000FF);
            /* Frame Type */
            buffer[NI_XNET_FRAMETYPE_OFFSET] = 0x00; // CAN protocol, CAN data frame;
            /* Payload Length */
            buffer[NI_XNET_LENGTH_OFFSET] = (byte)(data.Length);
            /* Payload */
            if (data.Length > 8)
            {
                Console.WriteLine("ni_usb: SendStandard: length > 8");
                return false;
            }

            Array.Copy(data, 0, buffer, NI_XNET_PAYLOAD_OFFSET, data.Length);

            int retval = this.xnetSessionTx.nx_WriteFrame(buffer, NI_XNET_FRAME_SIZE, 10);
            if(retval != 0)
            {
                Console.WriteLine("ni_usb: SendStandard: nx_WriteFrame returns " + retval);
                return false;
            }

            return true;
        }

        #endregion

        #endregion
    }
}
