using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using can_hw;

namespace SimpleUI
{
    public enum AXLE_ID 
    {
        AXLE_ONE,
        AXLE_TWO,
        AXLE_THREE,
        AXLE_FOUR,
        AXLE_FIVE,
        AXLE_SIX,
        AXLE_SEVEN,
        AXLE_EIGHT,
        AXLE_INVALID
    }

    public enum DEVICE_STATE
    {
        START,
        NOT_READY_TO_SWITCH_ON,
        SWITCH_ON_DISABLED,
        READY_TO_SWITCH_ON,
        SWITCHED_ON,
        OPERATION_ENABLE,
        QUICKSTOP_ACTIVE,
        FAULT_REACTION_ACTIVE,
        FAULT
    }

    public enum MODE_OF_OPERATION : sbyte
    {
        RESERVED = 0x00,
        PROFILE_VELOCITY = 0x03
    }

    class motor
    {
        #region Member
        private const UInt16 TPDO_MAX_COUNT = 64;
        private pcan_usb pcan;
        private ni_usb nican;
        private byte nodeId;
        private UInt16 rpdo_cobId_base;
        private UInt16 tpdo_cobId_base;
        public DEVICE_STATE state { get; private set; }
        private UInt16 controlStatus;
        private UInt16 statusWord;
        public byte mode { get; private set; }
        public Int32 PositionActualValue { get; private set; }
        public Int32 VelocityActualValue { get; private set; }
        public Int16 TorqueActualValue { get; private set; }
        public Int16 CurrentActualValue { get; private set; }
        public UInt32 DcLinkCircuitVoltage { get; private set; }
        #endregion // Member

        public motor(byte nodeId, AXLE_ID id)
        {
            if((nodeId <= 0) || (nodeId > 127)) {
                throw new Exception("Invalid CANopen node ID value");
            }
            this.nodeId = nodeId;
            this.initCobId(id);
            this.controlStatus = 0;
        }
        public void SetDevice(ref ni_usb device)
        {
            this.nican = device;
            this.pcan = null;
        }

        public void SetDevice(ref pcan_usb device)
        {
            this.nican = null;
            this.pcan = device;
        }

        #region Method
        #region Helper
        private void initCobId(AXLE_ID id)
        {
            switch (id) {
                case AXLE_ID.AXLE_ONE: {
                    this.tpdo_cobId_base = 0x181;
                    this.rpdo_cobId_base = 0x201;
                    break;
                }
                case AXLE_ID.AXLE_TWO: {
                    /* AXLE2 */
                    this.tpdo_cobId_base = 0x1C1;
                    this.rpdo_cobId_base = 0x241;
                    break;
                }
                case AXLE_ID.AXLE_THREE: {
                    /* AXLE3 */
                    this.tpdo_cobId_base = 0x281;
                    this.rpdo_cobId_base = 0x301;
                    break;
                }
                case AXLE_ID.AXLE_FOUR: {
                    /* AXLE4 */
                    this.tpdo_cobId_base = 0x2C1;
                    this.rpdo_cobId_base = 0x341;
                    break;
                }
                case AXLE_ID.AXLE_FIVE: {
                    /* AXLE5 */
                    this.tpdo_cobId_base = 0x381;
                    this.rpdo_cobId_base = 0x401;
                    break;
                }
                case AXLE_ID.AXLE_SIX: {
                    /* AXLE6 */
                    this.tpdo_cobId_base = 0x3C1;
                    this.rpdo_cobId_base = 0x441;
                    break;
                }
                case AXLE_ID.AXLE_SEVEN: {
                    /* AXLE7 */
                    this.tpdo_cobId_base = 0x481;
                    this.rpdo_cobId_base = 0x501;
                    break;
                }
                case AXLE_ID.AXLE_EIGHT: {
                    /* AXLE8 */
                    this.tpdo_cobId_base = 0x4C1;
                    this.rpdo_cobId_base = 0x541;
                    break;
                }

                default: {
                    this.tpdo_cobId_base = 0;
                    this.rpdo_cobId_base = 0;
                    break;
                }
            }
        }
        private void updateState()
        {
            if((this.statusWord & 0x004F) == 0) {
                this.state = DEVICE_STATE.NOT_READY_TO_SWITCH_ON;
            }
            if(((this.statusWord & 0x000F) == 0) &&
               ((this.statusWord & 0x0040) == 0x0040 )) {
                this.state = DEVICE_STATE.SWITCH_ON_DISABLED;
                this.controlStatus = (UInt16)(this.controlStatus & ~0x0002);
            }
            if ((( this.statusWord & 0x004E ) == 0 ) &&
                (( this.statusWord & 0x0021 ) == 0x0021 )) {
                this.state = DEVICE_STATE.READY_TO_SWITCH_ON;
                this.controlStatus = (UInt16)((this.controlStatus & ~0x0081) | 0x0006);
            }
            if ((( this.statusWord & 0x004C ) == 0 ) &&
                (( this.statusWord & 0x0023 ) == 0x0023 )) {
                this.state = DEVICE_STATE.SWITCHED_ON;
                this.controlStatus = (UInt16)( ( this.controlStatus & ~0x0088 ) | 0x0007 );
            }
            if ((( this.statusWord & 0x0048 ) == 0 ) &&
                (( this.statusWord & 0x0027 ) == 0x0027 )) {
                this.state = DEVICE_STATE.OPERATION_ENABLE;
                this.controlStatus = (UInt16)( ( this.controlStatus & ~0x0080 ) | 0x000F );
            }
            if ((( this.statusWord & 0x0068 ) == 0 ) &&
                (( this.statusWord & 0x0007 ) == 0x0007 )) {
                this.state = DEVICE_STATE.QUICKSTOP_ACTIVE;
                this.controlStatus = (UInt16)( ( this.controlStatus & ~0x0084 ) | 0x0002 );
            }
            if ((( this.statusWord & 0x0040 ) == 0 ) &&
                (( this.statusWord & 0x000F ) == 0x000F )) {
                this.state = DEVICE_STATE.FAULT_REACTION_ACTIVE;
            }
            if ((( this.statusWord & 0x0047 ) == 0 ) &&
                (( this.statusWord & 0x0008 ) == 0x0008 )) {
                this.state = DEVICE_STATE.FAULT;
            }
        }
        #endregion // Helper
        public void TpdoHandler(object sender, CanRxMsgArgs e)
        {
            if((e.msgId >= this.tpdo_cobId_base) &&
               (e.msgId < (this.tpdo_cobId_base + TPDO_MAX_COUNT))) {
                var tpdo = e.msgId + 1 - this.tpdo_cobId_base;
                /* Refer to Object Dictionary for Details */
                switch(tpdo) {
                    case 1: {
                        this.statusWord = BitConverter.ToUInt16(e.data, 0);
                        this.updateState();
                        break;
                    }
                    case 2: {
                        this.statusWord = BitConverter.ToUInt16(e.data, 0);
                        this.updateState();
                        this.mode = e.data[2];
                        break;
                    }
                    case 3: {
                        this.statusWord = BitConverter.ToUInt16(e.data, 0);
                        this.updateState();
                        this.PositionActualValue = BitConverter.ToInt32(e.data, 2);
                        break;
                    }
                    case 4: {
                        this.statusWord = BitConverter.ToUInt16(e.data, 0);
                        this.updateState();
                        this.VelocityActualValue = BitConverter.ToInt32(e.data, 2);
                        break;
                    }
                    case 5: {
                        this.statusWord = BitConverter.ToUInt16(e.data, 0);
                        this.updateState();
                        this.TorqueActualValue = BitConverter.ToInt16(e.data, 2);
                        break;
                    }
                    case 8: {
                        this.statusWord = BitConverter.ToUInt16(e.data, 0);
                        this.updateState();
                        this.CurrentActualValue = BitConverter.ToInt16(e.data, 2);
                        this.DcLinkCircuitVoltage = BitConverter.ToUInt32(e.data, 4);
                        break;
                    }
                    default: {
                        Console.WriteLine("Unknown TPDO" + tpdo);
                        break;
                    }
                }
            }
        }

        public void ResetNode()
        {
            byte[] data = new byte[] { 0x81, this.nodeId };
            if (this.pcan != null) {
                this.pcan.SendStandard(0, data);
            } else if(this.nican != null) {
                this.nican.SendStandard(0, data);
            }
            this.controlStatus = 0;
        }

        public void ResetComm()
        {
            this.controlStatus = 0;
            UInt16 controlword = 0;
            UInt32 msgId = (UInt32)( this.rpdo_cobId_base + 0 );
            if(this.pcan != null) {
                this.pcan.SendStandard(msgId, BitConverter.GetBytes(controlword));
            } else if (this.nican != null) {
                this.nican.SendStandard(msgId, BitConverter.GetBytes(controlword));
            }

            /* Reset communication */
            byte[] data = new byte[] { 0x82, this.nodeId };
            if (this.pcan != null) {
                this.pcan.SendStandard(0, data);
            } else if (this.nican != null) {
                this.nican.SendStandard(0, data);
            }
        }

        public void Ready()
        {
            UInt16 controlWord = (UInt16)((this.controlStatus & ~0x0082) | 0x0006);
            byte[] data = BitConverter.GetBytes(controlWord);
            UInt32 msgId = (UInt32)(this.rpdo_cobId_base + 0);
            
            if(this.pcan != null) {
                this.pcan.SendStandard(msgId, data);
            } else if(this.nican != null) {
                this.nican.SendStandard(msgId, data);
            }
        }

        public void SwitchOn()
        {
            UInt16 controlWord = (UInt16)((this.controlStatus & ~0x0008) | 0x0001);
            byte[] data = BitConverter.GetBytes(controlWord);
            UInt32 msgId = (UInt32)( this.rpdo_cobId_base + 0 );

            if (this.pcan != null) {
                this.pcan.SendStandard(msgId, data);
            } else if (this.nican != null) {
                this.nican.SendStandard(msgId, data);
            }
        }

        public void SwitchOff()
        {
            UInt16 controlWord = (UInt16)( this.controlStatus & ~0x0001 );
            byte[] data = BitConverter.GetBytes(controlWord);
            UInt32 msgId = (UInt32)( this.rpdo_cobId_base + 0 );

            if (this.pcan != null) {
                this.pcan.SendStandard(msgId, data);
            } else if (this.nican != null) {
                this.nican.SendStandard(msgId, data);
            }
        }

        public void DisableOperation()
        {
            UInt16 controlWord = (UInt16)( this.controlStatus & ~0x0008 );
            byte[] data = BitConverter.GetBytes(controlWord);
            UInt32 msgId = (UInt32)( this.rpdo_cobId_base + 0 );

            if (this.pcan != null) {
                this.pcan.SendStandard(msgId, data);
            } else if (this.nican != null) {
                this.nican.SendStandard(msgId, data);
            }
        }

        public void EnableOperation()
        {
            UInt16 controlWord = (UInt16)( this.controlStatus | 0x0008 );
            byte[] data = BitConverter.GetBytes(controlWord);
            UInt32 msgId = (UInt32)( this.rpdo_cobId_base + 0 );

            if (this.pcan != null) {
                this.pcan.SendStandard(msgId, data);
            } else if (this.nican != null) {
                this.nican.SendStandard(msgId, data);
            }
        }

        public void SetModeOfOperation(MODE_OF_OPERATION mode)
        {
            UInt32 msgId = (UInt32)( this.rpdo_cobId_base + 1 );
            byte[] data = new byte[3];
            data[0] = (byte)( this.controlStatus & 0x00FF );
            data[1] = (byte)( ( this.controlStatus >> 8 ) & 0x00FF );
            data[2] = (byte)mode;

            if (this.pcan != null) {
                this.pcan.SendStandard(msgId, data);
            } else if (this.nican != null) {
                this.nican.SendStandard(msgId, data);
            }
        }

        public void SetTargetVelocity(Int32 targetVelocity)
        {
            UInt32 msgId = (UInt32)( this.rpdo_cobId_base + 3 );
            byte[] controlWordBuf = BitConverter.GetBytes(this.controlStatus);
            byte[] targetVelocityBuf = BitConverter.GetBytes(targetVelocity);
            byte[] data = new byte[controlWordBuf.Length + targetVelocityBuf.Length];
            System.Buffer.BlockCopy(controlWordBuf, 0, data, 0, controlWordBuf.Length);
            System.Buffer.BlockCopy(targetVelocityBuf, 0, data, controlWordBuf.Length, targetVelocityBuf.Length);

            if (this.pcan != null) {
                this.pcan.SendStandard(msgId, data);
            } else if (this.nican != null) {
                this.nican.SendStandard(msgId, data);
            }
        }

        public void ClearFault()
        {
            UInt32 msgId = (UInt32)( this.rpdo_cobId_base + 0 );
            this.controlStatus = 0;
            UInt16 controlWord = (UInt16)( this.controlStatus | 0x0080 );
            byte[] data = BitConverter.GetBytes(controlWord);
            if (this.pcan != null) {
                this.pcan.SendStandard(msgId, data);
            } else if (this.nican != null) {
                this.nican.SendStandard(msgId, data);
            }
        }
        #endregion
    }
}

