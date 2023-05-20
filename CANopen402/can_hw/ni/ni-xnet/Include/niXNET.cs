//The attached Code is provided As Is. It has not been tested or validated as a product, 
//for use in a deployed application or system, or for use in hazardous environments. You 
//assume all risks for use of the Code and use of the Code is subject to the Sample Code 
//License Terms which can be found at: http://ni.com/samplecodelicense 



/*Functions that are commented were automatically generated and have not been tried
 They were let in the file as a starting point to extend the wrapper.
 Please see the readme for more information about the list of available functions.*/
namespace NationalInstruments.EmbeddedNetworks.Interop
{
    using System;
    using System.Runtime.InteropServices;

    public class niXNET : object, System.IDisposable
    {
        private System.IntPtr _handle;

        private bool _disposed = true;

        ~niXNET() { Dispose(false); }

        /***********************************************************************
                                    D A T A   T Y P E S
        ***********************************************************************/
        /* The ANSI C99 standard defines simple numeric types of a specific size,
           such as int32_t for a signed 32-bit integer.
           Many C/C++ compilers are not ANSI C99 by default, such as Microsoft Visual C/C++.
           Therefore, NI-XNET does not require use of ANSI C99.
           Since NI-XNET does not attempt to override ANSI C99 types (as defined in stdint.h),
           it uses legacy National Instruments numeric types such as i32. If desired, you can use
           ANSI C99 numeric types instead of the analogous NI-XNET numeric type
           (i.e. int32_t instead of i32). */

        //typedef void*              nxVoidPtr;
        //typedef uint*               nxU32Ptr;

        // Session Reference (handle).
        //typedef uint nxSessionRef_t;

        // Database Reference (handle).
        //typedef u32 nxDatabaseRef_t;

        //typedef i32 nxStatus_t;       // Return value

        // Absolute timestamp.
        //typedef u64 nxTimestamp_t;

        [StructLayout(LayoutKind.Sequential)]
        public struct niFlexRayStats
        {
            public uint NumSyntaxErrorChA;
            public uint NumSyntaxErrorChB;
            public uint NumContentErrorChA;
            public uint NumContentErrorChB;
            public uint NumSlotBoundaryViolationChA;
            public uint NumSlotBoundaryViolationChB;
        };

        public void Dispose()
        {
            this.Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if ((this._disposed == false))
            {
                PInvoke.nx_clear(this._handle);
                this._handle = System.IntPtr.Zero;
            }
            this._disposed = true;
        }/* */

        /***********************************************************************
               F U N C T I O N   P R O T O T Y P E S  :  S E S S I O N
        ***********************************************************************/
        //typedef u32 nxSessionRef_t;

        // Database Reference (handle).
        //typedef u32 nxDatabaseRef_t;

        //typedef i32 nxStatus_t;       // Return value

        // Absolute timestamp.
        //typedef u64 nxTimestamp_t;

        /*nxStatus_t _NXFUNC nxCreateSession (
                           const char * DatabaseName,
                           const char * ClusterName,
                           const char * List,
                           const char * Interface,
                           u32 Mode,
                           nxSessionRef_t * SessionRef); /* */
        public niXNET(string databaseName, string clusterName, string list, string xnetInterface, uint mode)
        {
            int pInvokeResult = PInvoke.CreateSession(databaseName, clusterName, list, xnetInterface, mode, out this._handle);
            PInvoke.TestForError(System.IntPtr.Zero, pInvokeResult);
            this._disposed = false;
        }

        public niXNET(uint numberOfDatabaseRef, uint[] arrayOfDatabaseRef, string xnetInterface, uint mode)
        {
            int pInvokeResult = PInvoke.createSessionByRef(numberOfDatabaseRef, arrayOfDatabaseRef, xnetInterface, mode, out this._handle);
            PInvoke.TestForError(System.IntPtr.Zero, pInvokeResult);
            this._disposed = false;
        }

        /*nxStatus_t _NXFUNC nxGetProperty (
                                   nxSessionRef_t SessionRef,
                                   u32 PropertyID,
                                   u32 PropertySize,
                                   void * PropertyValue); f64 (is double), u32[16], u32[], boolean, double, cstr, nxDatabaseRef_t[] (nxDatabaseRef_t is u32) /* */

        public int nx_GetProperty(uint propertyID, uint propertySize, out uint[] propertyValue)
        {
            int pInvokeResult = PInvoke.nx_getProperty(this._handle, propertyID, propertySize, out propertyValue);
            PInvoke.TestForError(this._handle, pInvokeResult);
            return pInvokeResult;
        }

        public int nx_GetProperty(uint propertyID, uint propertySize, out uint propertyValue)
        {
            int pInvokeResult = PInvoke.nx_getProperty(this._handle, propertyID, propertySize, out propertyValue);
            PInvoke.TestForError(this._handle, pInvokeResult);
            return pInvokeResult;
        }

        
        public int nx_GetProperty(uint propertyID, uint propertySize,out string propertyValue)
        {
            
            System.Text.StringBuilder propertyPtr = new System.Text.StringBuilder();
            int pInvokeResult = PInvoke.nx_getProperty(this._handle, propertyID, propertySize, propertyPtr);
            PInvoke.TestForError(this._handle, pInvokeResult);
            propertyValue = propertyPtr.ToString();
            return pInvokeResult;
        }

        /*nxStatus_t _NXFUNC nxGetPropertySize (
                                   nxSessionRef_t SessionRef,
                                   u32 PropertyID,
                                   u32 * PropertySize);/* */
        public int nx_GetPropertySize(uint propertyID, out uint propertySize)
        {
            int pInvokeResult = PInvoke.nx_getPropertySize(this._handle, propertyID, out propertySize);
            PInvoke.TestForError(this._handle, pInvokeResult);
            return pInvokeResult;
        }

        /*nxStatus_t _NXFUNC nxSetProperty (
                                   nxSessionRef_t SessionRef,
                                   u32 PropertyID,
                                   u32 PropertySize,
                                   void * PropertyValue);/* */
        public int nx_SetProperty(uint propertyID, uint propertySize, IntPtr propertyValue)
        {
            int pInvokeResult = PInvoke.nx_setProperty(this._handle, propertyID, propertySize, propertyValue);
            PInvoke.TestForError(this._handle, pInvokeResult);
            return pInvokeResult;
        }

        public int nx_SetProperty(uint propertyID, uint propertySize, uint propertyValue)
        {
            int pInvokeResult = PInvoke.nx_setProperty(this._handle, propertyID, propertySize,ref propertyValue);
            PInvoke.TestForError(this._handle, pInvokeResult);
            return pInvokeResult;
        }


        /*nxStatus_t _NXFUNC nxGetSubProperty (
                                   nxSessionRef_t SessionRef,
                                   u32 ActiveIndex,
                                   u32 PropertyID,
                                   u32 PropertySize,
        //                           void * PropertyValue);/* */
        //public unsafe int nx_GetSubProperty(uint activeIndex, uint propertyID, uint propertySize, void* propertyValue)
        //{
        //    int pInvokeResult = PInvoke.nx_getSubProperty(this._handle, activeIndex, propertyID, propertySize, propertyValue);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        /*nxStatus_t _NXFUNC nxGetSubPropertySize (
                                   nxSessionRef_t SessionRef,
                                   u32 ActiveIndex,
                                   u32 PropertyID,
                                   u32 * PropertySize);/* */
        //public int nx_GetSubPropertySize(uint activeIndex, uint propertyID, out uint propertySize)
        //{
        //    int pInvokeResult = PInvoke.nx_getSubPropertySize(this._handle, activeIndex, propertyID, out propertySize);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        /*nxStatus_t _NXFUNC nxSetSubProperty (
                                   nxSessionRef_t SessionRef,
                                   u32 ActiveIndex,
                                   u32 PropertyID,
                                   u32 PropertySize,
                                   void * PropertyValue);/* */
        //public unsafe int nx_SetSubProperty(uint activeIndex, uint propertyID, uint propertySize, void* propertyValue)
        //{
        //    int pInvokeResult = PInvoke.nx_setSubProperty(this._handle, activeIndex, propertyID, propertySize, propertyValue);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        /*nxStatus_t _NXFUNC nxReadFrame (
                                   nxSessionRef_t SessionRef,
                                   void * Buffer,
                                   u32 SizeOfBuffer,
                                   f64 Timeout,
                                   u32 * NumberOfBytesReturned);/* */
        public int nx_ReadFrame(byte[] buffer, uint sizeOfBuffer, double timeOut, out uint numberOfBytesReturned)
        {
            int pInvokeResult = PInvoke.nx_readFrame(this._handle, buffer, sizeOfBuffer, timeOut, out numberOfBytesReturned);
            PInvoke.TestForError(this._handle, pInvokeResult);
            return pInvokeResult;
        }

        /*nxStatus_t _NXFUNC nxReadSignalSinglePoint (
                                   nxSessionRef_t SessionRef,
                                   f64 * ValueBuffer,
                                   u32 SizeOfValueBuffer,
                                   nxTimestamp_t * TimestampBuffer,
                                   u32 SizeOfTimestampBuffer);/* */
        public int nx_ReadSignalSinglePoint( double[] valueBuffer, uint sizeOfValueBuffer, ulong[] timestampBuffer, uint sizeOfTimestampBuffer)
        {
            int pInvokeResult = PInvoke.nx_readSignalSinglePoint(this._handle, valueBuffer, sizeOfValueBuffer, timestampBuffer, sizeOfTimestampBuffer);
            PInvoke.TestForError(this._handle, pInvokeResult);
            return pInvokeResult;
        }

        /*nxStatus_t _NXFUNC nxReadSignalWaveform (
                                   nxSessionRef_t SessionRef,
                                   f64 Timeout,
                                   nxTimestamp_t * StartTime,
                                   f64 * DeltaTime,
                                   f64 * ValueBuffer,
                                   u32 SizeOfValueBuffer,
                                   u32 * NumberOfValuesReturned);/* */
        //public int nx_ReadSignalWaveform(double timeout, out ulong startTime, out double deltaTime, uint sizeOfValueBuffer, out uint numberOfValuesReturned)
        //{
        //    int pInvokeResult = PInvoke.nx_readSignalWaveform(this._handle, timeout, out startTime, out deltaTime, sizeOfValueBuffer, out numberOfValuesReturned);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        /*nxStatus_t _NXFUNC nxReadSignalXY (
                                   nxSessionRef_t SessionRef,
                                   nxTimestamp_t * TimeLimit,
                                   f64 * ValueBuffer,
                                   u32 SizeOfValueBuffer,
                                   nxTimestamp_t * TimestampBuffer,
                                   u32 SizeOfTimestampBuffer,
                                   u32 * NumPairsBuffer,
                                   u32 SizeOfNumPairsBuffer);/* */
        
        //public int nx_ReadSignalXY(ulong timeLimit, double[,] valueBuffer, uint sizeOfValueBuffer, ulong[,] timestampBuffer,uint sizeOfTimestampBuffer, uint[] numPairsBuffer, uint sizeOfNumPairsBuffer)
        //{
        //    int pInvokeResult = PInvoke.nx_readSignalXY(this._handle, timeLimit, valueBuffer, sizeOfValueBuffer, timestampBuffer, sizeOfTimestampBuffer, numPairsBuffer, sizeOfNumPairsBuffer);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        /*nxStatus_t _NXFUNC nxReadState (
                                   nxSessionRef_t SessionRef,
                                   u32 StateID,
                                   u32 StateSize,
                                   void * StateValue,
                                   nxStatus_t * Fault);/* */
        //public unsafe int nx_ReadState(uint stateID, uint stateSize, void* stateValue, out int fault)
        //{
        //    int pInvokeResult = PInvoke.nx_readState(this._handle, stateID, stateSize, stateValue, out fault);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}
		
		public int nx_ReadState(uint stateID, uint stateSize,out uint stateValue, out int fault)
        {
            int pInvokeResult = PInvoke.nx_readState(this._handle, stateID, stateSize,out stateValue, out fault);
            PInvoke.TestForError(this._handle, pInvokeResult);
            return pInvokeResult;
        }

        /*nxStatus_t _NXFUNC nxWriteFrame (
                                   nxSessionRef_t SessionRef,
                                   void * Buffer,
                                   u32 NumberOfBytesForFrames,
                                   f64 Timeout);/* */
        public int nx_WriteFrame(byte[] buffer, uint numberOfBytesForFrames, double timeOut)
        {
            int pInvokeResult = PInvoke.nx_writeFrame(this._handle, buffer, numberOfBytesForFrames, timeOut);
            PInvoke.TestForError(this._handle, pInvokeResult);
            return pInvokeResult;
        }

        /*nxStatus_t _NXFUNC nxWriteSignalSinglePoint (
                                   nxSessionRef_t SessionRef,
                                   f64 * ValueBuffer,
                                   u32 SizeOfValueBuffer);/* */
        public int nx_WriteSignalSinglePoint(double[] valueBuffer, uint sizeOfValueBuffer)
        {
            int pInvokeResult = PInvoke.nx_writeSignalSinglePoint(this._handle, valueBuffer, sizeOfValueBuffer);
            PInvoke.TestForError(this._handle, pInvokeResult);
            return pInvokeResult;
        }

        /*nxStatus_t _NXFUNC nxWriteState (
                                   nxSessionRef_t SessionRef,
                                   u32 StateID,
                                   u32 StateSize,
                                   void * StateValue);/* */
        //public unsafe int nx_WriteState(uint stateID, uint stateSize, void* stateValue)
        //{
        //    int pInvokeResult = PInvoke.nx_writeState(this._handle, stateID, stateSize, stateValue);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        /*nxStatus_t _NXFUNC nxWriteSignalWaveform (
                                   nxSessionRef_t SessionRef,
                                   f64 Timeout,
                                   f64 * ValueBuffer,
                                   u32 SizeOfValueBuffer);/* */
        public int nx_WriteSignalWaveform(double timeOut, double[,] valueBuffer, uint sizeOfValueBuffer)
        {
            int pInvokeResult = PInvoke.nx_writeSignalWaveform(this._handle, timeOut, valueBuffer, sizeOfValueBuffer);
            PInvoke.TestForError(this._handle, pInvokeResult);
            return pInvokeResult;
        }

        /*nxStatus_t _NXFUNC nxWriteSignalXY (
                                   nxSessionRef_t SessionRef,
                                   f64 Timeout,
                                   f64 * ValueBuffer,
                                   u32 SizeOfValueBuffer,
                                   nxTimestamp_t * TimestampBuffer,
                                   u32 SizeOfTimestampBuffer,
                                   u32 * NumPairsBuffer,
                                   u32 SizeOfNumPairsBuffer);/* */
        public int nx_WriteSignalXY(double timeOut, double[,] valueBuffer, uint sizeOfValueBuffer, ulong[,] timestampBuffer, uint sizeOfTimestampBuffer, uint[] numPairsBuffer, uint sizeOfNumPairsBuffer)
        {
            int pInvokeResult = PInvoke.nx_writeSignalXY(this._handle, timeOut, valueBuffer, sizeOfValueBuffer, timestampBuffer, sizeOfTimestampBuffer, numPairsBuffer, sizeOfNumPairsBuffer);
            PInvoke.TestForError(this._handle, pInvokeResult);
            return pInvokeResult;
        }

        /*nxStatus_t _NXFUNC nxConvertFramesToSignalsSinglePoint (
                                   nxSessionRef_t SessionRef,
                                   void * FrameBuffer,
                                   u32 NumberOfBytesForFrames,
                                   f64 * ValueBuffer,
                                   u32 SizeOfValueBuffer,
                                   nxTimestamp_t * TimestampBuffer,
                                   u32 SizeOfTimestampBuffer);/* */
        //public unsafe int nx_ConvertFramesToSignalsSinglePoint(void* frameBuffer, uint numberOfBytesForFrames, out double valueBuffer, uint sizeOfValueBuffer, out ulong timestampBuffer, uint sizeOfTimestampBuffer)
        //{
        //    int pInvokeResult = PInvoke.nx_convertFramesToSignalsSinglePoint(this._handle, frameBuffer, numberOfBytesForFrames, out valueBuffer, sizeOfValueBuffer, out timestampBuffer, sizeOfTimestampBuffer);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        /*nxStatus_t _NXFUNC nxConvertSignalsToFramesSinglePoint (
                                   nxSessionRef_t SessionRef,
                                   f64 * ValueBuffer,
                                   u32 SizeOfValueBuffer,
                                   void * Buffer,
                                   u32 SizeOfBuffer,
                                   u32 * NumberOfBytesReturned);/* */
        //public unsafe int nx_ConvertSignalsToFramesSinglePoint(out double valueBuffer, uint sizeOfValueBuffer, void* buffer, uint sizeOfBuffer, out uint numberOfBytesReturned)
        //{
        //    int pInvokeResult = PInvoke.nx_convertSignalsToFramesSinglePoint(this._handle, out valueBuffer, sizeOfValueBuffer, buffer, sizeOfBuffer, out numberOfBytesReturned);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        /*nxStatus_t _NXFUNC nxBlink (
                                   nxSessionRef_t InterfaceRef,
                                   u32 Modifier);/* */
        //public int nx_Blink(uint modifier)
        //{
        //    int pInvokeResult = PInvoke.nx_blink(this._handle, modifier);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        /*nxStatus_t _NXFUNC nxClear (
                                   nxSessionRef_t SessionRef);/* */
        public int nx_Clear()
        {
            int pInvokeResult = PInvoke.nx_clear(this._handle);
            PInvoke.TestForError(this._handle, pInvokeResult);
            return pInvokeResult;
        }

        /*nxStatus_t _NXFUNC nxConnectTerminals (
                                   nxSessionRef_t SessionRef,
                                   const char * source,
                                   const char * destination);/* */
        //public int nx_ConnectTerminals(string source, string destination)
        //{
        //    int pInvokeResult = PInvoke.nx_connectTerminals(this._handle, source, destination);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        /*nxStatus_t _NXFUNC nxDisconnectTerminals (
                                   nxSessionRef_t SessionRef,
                                   const char * source,
                                   const char * destination);/* */
        //public int nx_DisconnectTerminals(string source, string destination)
        //{
        //    int pInvokeResult = PInvoke.nx_disconnectTerminals(this._handle, source, destination);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        /*nxStatus_t _NXFUNC nxFlush (
                                   nxSessionRef_t SessionRef);/* */
        public int nx_Flush()
        {
            int pInvokeResult = PInvoke.nx_flush(this._handle);
            PInvoke.TestForError(this._handle, pInvokeResult);
            return pInvokeResult;
        }

        /*nxStatus_t _NXFUNC nxStart (
                                   nxSessionRef_t SessionRef,
                                   u32 Scope);/* */
        public int nx_Start(uint scope)
        {
            int pInvokeResult = PInvoke.nx_start(this._handle, scope);
            PInvoke.TestForError(this._handle, pInvokeResult);
            return pInvokeResult;
        }

        /*nxStatus_t _NXFUNC nxStop (
                                   nxSessionRef_t SessionRef,
                                   u32 Scope);/* */
        public int nx_Stop(uint scope)
        {
            int pInvokeResult = PInvoke.nx_stop(this._handle, scope);
            PInvoke.TestForError(this._handle, pInvokeResult);
            return pInvokeResult;
        }

        /*void _NXFUNC nxStatusToString (
                                   nxStatus_t Status,
                                   u32 SizeofString,
                                   char * StatusDescription);/* */
        public int nx_StatusToString(int status, uint sizeOfString, System.Text.StringBuilder statusDescription)
        {
            int pInvokeResult = PInvoke.nx_statusToString(status, sizeOfString, statusDescription);
            PInvoke.TestForError(this._handle, pInvokeResult);
            return pInvokeResult;
        }

        /*nxStatus_t _NXFUNC nxSystemOpen (
                                   nxSessionRef_t * SystemRef);/* */
        //public niXNET()
        //{
        //    int pInvokeResult = PInvoke.nx_systemOpen(out this._handle);
        //    PInvoke.TestForError(System.IntPtr.Zero, pInvokeResult);
        //    this._disposed = false;
        //}

        /*nxStatus_t _NXFUNC nxSystemClose (
                                   nxSessionRef_t SystemRef);/* */
        //public int nx_SystemClose()
        //{
        //    int pInvokeResult = PInvoke.nx_systemClose(this._handle);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        /*nxStatus_t _NXFUNC nxWait (
                                   nxSessionRef_t SessionRef,
                                   u32 Condition,
                                   u32 ParamIn,
                                   f64 Timeout,
                                   u32 * ParamOut);/* */
        //public int nx_Wait(uint condition, uint paramIn, double timeOut, out uint paramOut)
        //{
        //    int pInvokeResult = PInvoke.nx_wait(this._handle, condition, paramIn, timeOut, out paramOut);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        ///***********************************************************************
        //       F U N C T I O N   P R O T O T Y P E S  :  D A T A B A S E
        //***********************************************************************/

        ///*nxStatus_t _NXFUNC nxdbOpenDatabase (
        //                   const char * DatabaseName,
        //                   nxDatabaseRef_t * DatabaseRef); /* */
        //public int nxdb_OpenDatabase(string databaseName, out uint databaseRef)
        //{
        //    int pInvokeResult = PInvoke.nxdb_openDatabase(databaseName, out databaseRef);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        ///*nxStatus_t _NXFUNC nxdbCloseDatabase (
        //                           nxDatabaseRef_t DatabaseRef,
        //                           u32 CloseAllRefs);/* */
        //public int nxdb_CloseDatabase(uint databaseRef, uint closeAllRefs)
        //{
        //    int pInvokeResult = PInvoke.nxdb_closeDatabase(databaseRef, closeAllRefs);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        ///*nxStatus_t _NXFUNC nxdbCreateObject (
        //                           nxDatabaseRef_t ParentObjectRef,
        //                           u32 ObjectClass,
        //                           const char * ObjectName,
        //                           nxDatabaseRef_t * DbObjectRef);/* */
        //public int nxdb_CreateObject(uint parentObjectRef, uint objectClass, string objecName, out uint dbObjectRef)
        //{
        //    int pInvokeResult = PInvoke.nxdb_createObject(parentObjectRef, objectClass, objecName, out dbObjectRef);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        ///*nxStatus_t _NXFUNC nxdbFindObject (
        //                           nxDatabaseRef_t ParentObjectRef,
        //                           u32 ObjectClass,
        //                           const char * ObjectName,
        //                           nxDatabaseRef_t * DbObjectRef);/* */
        //public int nxdb_FindObject(uint parentObjectRef, uint objectClass, string objectName, out uint dbObjectRef)
        //{
        //    int pInvokeResult = PInvoke.nxdb_findObject(parentObjectRef, objectClass, objectName, out dbObjectRef);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        ///*nxStatus_t _NXFUNC nxdbDeleteObject (
        //                           nxDatabaseRef_t DbObjectRef);/* */
        //public int nxdb_DeleteObject(uint dbObjectRef)
        //{
        //    int pInvokeResult = PInvoke.nxdb_deleteObject(dbObjectRef);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        ///*nxStatus_t _NXFUNC nxdbSaveDatabase (
        //                           nxDatabaseRef_t DatabaseRef,
        //                           const char * DbFilepath); /* */
        //public int nxdb_SaveDatabase(uint databaseRef, string dbFilepath)
        //{
        //    int pInvokeResult = PInvoke.nxdb_saveDatabase(databaseRef, dbFilepath);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        ///*nxStatus_t _NXFUNC nxdbGetProperty (
        //                           nxDatabaseRef_t DbObjectRef,
        //                           u32 PropertyID,
        //                           u32 PropertySize,
        //                           void * PropertyValue);/* */
        //public unsafe int nxdb_GetProperty(uint dbObjectRef, uint propertyID, uint propertySize, void* propertyValue)
        //{
        //    int pInvokeResult = PInvoke.nxdb_getProperty(dbObjectRef, propertyID, propertySize, propertyValue);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        ///*nxStatus_t _NXFUNC nxdbGetPropertySize (
        //                           nxDatabaseRef_t DbObjectRef,
        //                           u32 PropertyID,
        //                           u32 * PropertySize);/* */
        //public int nxdb_GetPropertySize(uint dbObjectRef, uint propertyID, out uint propertySize)
        //{
        //    int pInvokeResult = PInvoke.nxdb_getPropertySize(dbObjectRef, propertyID, out propertySize);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        ///*nxStatus_t _NXFUNC nxdbSetProperty (
        //                           nxDatabaseRef_t DbObjectRef,
        //                           u32 PropertyID,
        //                           u32 PropertySize,
        //                           void * PropertyValue);/* */
        //public unsafe int nxdb_SetProperty(uint dbObjectRef, uint propertyID, uint propertySize, void* propertyValue)
        //{
        //    int pInvokeResult = PInvoke.nxdb_setProperty(dbObjectRef, propertyID, propertySize, propertyValue);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        ///* The NI-XNET documentation does not describe the Mode parameter.
        //   The Mode parameter was added near release. It specifies the type of DBC attribute
        //   that you want to search for. In the v1.2 release there is only one value:
        //      nxGetDBCMode_Attribute (0)
        //   Other values will be supported in subsequent releases.*/
        ///*nxStatus_t _NXFUNC nxdbGetDBCAttributeSize (
        //                           nxDatabaseRef_t DbObjectRef,
        //                           u32 Mode,
        //                           const char* AttributeName,
        //                           u32 *AttributeTextSize);/* */
        //public int nxdb_GetDBCAttributeSize(uint dbObjectRef, uint mode, string attributeName, out uint attributeTextSize)
        //{
        //    int pInvokeResult = PInvoke.nxdb_getDBCAttributeSize(dbObjectRef, mode, attributeName, out attributeTextSize);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        ///* The NI-XNET documentation does not describe the Mode parameter.
        //   The Mode parameter was added near release. It specifies the type of DBC attribute
        //   that you want to search for. In the v1.2 release there is only one value:
        //      nxGetDBCMode_Attribute (0)
        //   Other values will be supported in subsequent releases. */
        ///*nxStatus_t _NXFUNC nxdbGetDBCAttribute (
        //                           nxDatabaseRef_t DbObjectRef,
        //                           u32 Mode,
        //                           const char* AttributeName,
        //                           u32 AttributeTextSize,
        //                           char* AttributeText,
        //                           u32 * IsDefault);/* */
        //public int nxdb_GetDBCAttribute(uint dbObjectRef, uint mode, string attributeName, uint attributeTextSize, out string attributeText, out uint isDefault)
        //{
        //    int pInvokeResult = PInvoke.nxdb_getDBCAttribute(dbObjectRef, mode, attributeName, attributeTextSize, out attributeText, out isDefault);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        ///*nxStatus_t _NXFUNC nxdbAddAlias (
        //                           const char * DatabaseAlias,
        //                           const char * DatabaseFilepath,
        //                           u32          DefaultBaudRate);/* */
        //public int nxdb_AddAlias(string databaseAlias, string databaseFilepath, uint defaultBaudRate)
        //{
        //    int pInvokeResult = PInvoke.nxdb_addAlias(databaseAlias, databaseFilepath, defaultBaudRate);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        ///*nxStatus_t _NXFUNC nxdbRemoveAlias (
        //                           const char * DatabaseAlias);/* */
        //public int nxdb_RemoveAlias(string databaseAlias)
        //{
        //    int pInvokeResult = PInvoke.nxdb_removeAlias(databaseAlias);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        ///*nxStatus_t _NXFUNC nxdbDeploy (
        //                           const char * IPAddress,
        //                           const char * DatabaseAlias,
        //                           u32 WaitForComplete,
        //                           u32 * PercentComplete);/* */
        //public int nxdb_Deploy(string ipAddress, string databaseAlias, uint waitForComplete, out uint percentComplete)
        //{
        //    int pInvokeResult = PInvoke.nxdb_deploy(ipAddress, databaseAlias, waitForComplete, out percentComplete);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        ///*nxStatus_t _NXFUNC nxdbUndeploy (
        //                           const char * IPAddress,
        //                           const char * DatabaseAlias);/* */
        //public int nxdb_Undeploy(string ipAddress, string databaseAlias)
        //{
        //    int pInvokeResult = PInvoke.nxdb_undeploy(ipAddress, databaseAlias);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        ///*nxStatus_t _NXFUNC nxdbGetDatabaseList (
        //                           const char * IPAddress,
        //                           u32 SizeofAliasBuffer,
        //                           char * AliasBuffer,
        //                           u32 SizeofFilepathBuffer,
        //                           char * FilepathBuffer,
        //                           u32 * NumberOfDatabases);/* */
        //public int nxdb_GetDatabaseList(string ipAddress, uint sizeofAliasBuffer, out string aliasBuffer, uint sizeofFilepathBuffer, out string filepathBuffer, out uint numberOfDatabases)
        //{
        //    int pInvokeResult = PInvoke.nxdb_getDatabaseList(ipAddress, sizeofAliasBuffer, out aliasBuffer, sizeofFilepathBuffer, out filepathBuffer, out numberOfDatabases);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        ///*nxStatus_t _NXFUNC nxdbGetDatabaseListSizes (
        //                           const char * IPAddress,
        //                           u32 * SizeofAliasBuffer,
        //                           u32 * SizeofFilepathBuffer);/* */
        //public int nxdb_GetDatabaseListSizes(string ipAddress, out uint sizeofAliasBuffer, out uint sizeofFilepathBuffer)
        //{
        //    int pInvokeResult = PInvoke.nxdb_getDatabaseListSizes(ipAddress, out sizeofAliasBuffer, out sizeofFilepathBuffer);
        //    PInvoke.TestForError(this._handle, pInvokeResult);
        //    return pInvokeResult;
        //}

        public class xNETConstants
        {
            public const int NX_STATUS_QUALIFIER = 0x3FF63000;
            public const int NX_STATUS_WARNING = 0x00000000;
            public const int NX_STATUS_ERROR = unchecked((int)0x80000000);
            public const int NX_WARNING_BASE = (NX_STATUS_QUALIFIER | NX_STATUS_WARNING);
            public const int NX_ERROR_BASE = (NX_STATUS_QUALIFIER | NX_STATUS_ERROR);

            public const int nxSuccess = 0;

            // Macros to get fields of uint returned by nxReadState of nxState_SessionInfo
            // Get state of frames in the session; uses constants with prefix nxSessionInfoState_
            public byte nxSessionInfo_Get_State(uint StateValue)
            {
                return ((byte)((uint)StateValue & 0x00000003));
            }

            // Macros to get fields of uint returned by nxReadState of nxState_CANComm
            // Get CAN communication state; uses constants with prefix nxCANCommState_
            public byte nxCANComm_Get_CommState(uint StateValue)
            {
                return ((byte)((uint)StateValue & 0x0000000F));
            }
            // Get CAN transceiver error (!NERR); 1 = error, 0 = no error
            public byte nxCANComm_Get_TcvrErr(uint StateValue)
            {
                return ((byte)(((uint)StateValue >> 4) & 0x00000001));
            }
            // Get indication of CAN controller/transceiver sleep; 1 = asleep, 0 = awake
            public byte nxCANComm_Get_Sleep(uint StateValue)
            {
                return ((byte)(((uint)StateValue >> 5) & 0x00000001));
            }
            // Get last bus error that incremented counters; uses constants with prefix nxCANLastErr_
            public byte nxCANComm_Get_LastErr(uint StateValue)
            {
                return ((byte)(((uint)StateValue >> 8) & 0x0000000F));
            }
            // Get Transmit Error Counter as defined by the CAN protocol specification
            public byte nxCANComm_Get_TxErrCount(uint StateValue)
            {
                return ((byte)(((uint)StateValue >> 16) & 0x000000FF));
            }

            // Get Receive Error Counter as defined by the CAN protocol specification
            public byte nxCANComm_Get_RxErrCount(uint StateValue)
            {
                return ((byte)(((uint)StateValue >> 24) & 0x000000FF));
            }


            public const int nxErrInternalError = (NX_ERROR_BASE | 0x001);

            //! Board self test failed(code 2). Solution: try reinstalling the driver or
            //! switching the slot(s) of the board(s). If the error persists,contact
            //! National Instruments.
            public const int nxErrSelfTestError1 = (NX_ERROR_BASE | 0x002);

            //! Board self test failed(code 3). Solution: try reinstalling the driver or
            //! switching the slot(s) of the board(s). If the error persists,contact
            //! National Instruments.
            public const int nxErrSelfTestError2 = (NX_ERROR_BASE | 0x003);

            //! Board self test failed(code 4). Solution: try reinstalling the driver or
            //! switching the slot(s) of the board(s). If the error persists,contact
            //! National Instruments.
            public const int nxErrSelfTestError3 = (NX_ERROR_BASE | 0x004);

            //! Board self test failed(code 5). Solution: try reinstalling the driver or
            //! switching the slot(s) of the board(s). If the error persists,contact
            //! National Instruments.
            public const int nxErrSelfTestError4 = (NX_ERROR_BASE | 0x005);

            //! Board self test failed(code 6). Solution: try reinstalling the driver or
            //! switching the slot(s) of the board(s). If the error persists,contact
            //! National Instruments.
            public const int nxErrSelfTestError5 = (NX_ERROR_BASE | 0x006);

            //! Computer went to hibernation mode and the board lost power. Solution:
            //! prevent the computer from going to hibernation mode in the control panel.
            public const int nxErrPowerSuspended = (NX_ERROR_BASE | 0x007);

            //! A write queue overflowed. Solution: wait until queue space becomes available
            //! and retry.
            public const int nxErrOutputQueueOverflow = (NX_ERROR_BASE | 0x008);

            //! The board's firmware did not answer a command. Solution: Stop your
            //! application and execute a self test. Try deactivating/reactivating the
            //! driver in the Device Manager. If the problem persists, contact National
            //! Instruments.
            public const int nxErrFirmwareNoResponse = (NX_ERROR_BASE | 0x009);

            //! The operation timed out. Solution: specify a timeout long enough to complete
            //! the operation, or change the operation in a way that it can get completed in
            //! less time (e.g. read less data).
            public const int nxErrEventTimeout = (NX_ERROR_BASE | 0x00A);

            //! A read queue overflowed. Solution: reduce your data rate or call Read more
            //! frequently.
            public const int nxErrInputQueueOverflow = (NX_ERROR_BASE | 0x00B);

            //! The Read buffer is too small to hold a single frame. Solution: provide a
            //! buffer large enough.
            public const int nxErrInputQueueReadSize = (NX_ERROR_BASE | 0x00C);

            //! You tried to open the same frame twice. This is not permitted. Solution:
            //! open each frame only once.
            public const int nxErrDuplicateFrameObject = (NX_ERROR_BASE | 0x00D);

            //! You tried to open the same stream object twice. This is not permitted.
            //! Solution: open each stream object only once.
            public const int nxErrDuplicateStreamObject = (NX_ERROR_BASE | 0x00E);

            //! Self test is not possible since the board is in use by an application.
            //! Solution: stop all NI-XNET applications before executing a self test.
            public const int nxErrSelfTestNotPossible = (NX_ERROR_BASE | 0x00F);

            //! Allocation of memory failed. You do not have sufficient memory in the
            //! LabVIEW target. Solution: add more RAM or try to use fewer resources in your
            //! applications (arrays, XNET sessions, etc).
            public const int nxErrMemoryFull = (NX_ERROR_BASE | 0x010);

            //! The maximum number of sessions was exceeded. Solution: use fewer sessions.
            public const int nxErrMaxSessions = (NX_ERROR_BASE | 0x011);

            //! The maximum number of frames has been exceeded. Solution: Use fewer frames
            //! in your sessions.
            public const int nxErrMaxFrames = (NX_ERROR_BASE | 0x012);

            //! The maximum number of devices has been detected. Solution: use fewer
            //! devices.
            public const int nxErrMaxDevices = (NX_ERROR_BASE | 0x013);

            //! A driver support file is missing. Solution: try reinstalling the driver. If
            //! the error persists, contact National Instruments.
            public const int nxErrMissingFile = (NX_ERROR_BASE | 0x014);

            //! This indicates that a NULL pointer or an empty string was passed to a
            //! function. The user should verify that the parameters passed in make sense
            //! for the given function.
            public const int nxErrParameterNullOrEmpty = (NX_ERROR_BASE | 0x015);

            //! The maximum number of schedules has been detected. Solution: Use fewer
            //! schedules.
            public const int nxErrMaxSchedules = (NX_ERROR_BASE | 0x016);

            //! Board self test failed (code 17). Solution: Try reinstalling the driver or
            //! switching the slot(s) of the board(s). If the error persists, contact
            //! National Instruments.
            public const int nxErrSelfTestError6 = (NX_ERROR_BASE | 0x017);

            //! You cannot start an NI-XNET application while a self test is in progress.
            //! Solution: Complete the self test before starting any NI-XNET applications.
            public const int nxErrSelfTestInProgress = (NX_ERROR_BASE | 0x018);

            //! An invalid reference has been passed to a NI-XNET session function.
            //! Solution: Only pass reference retrieved from Create Session, or from an IO
            //! name of a session in LabVIEW project.
            public const int nxErrInvalidSessionHandle = (NX_ERROR_BASE | 0x020);

            //! An invalid reference has been passed to a NI-XNET system function. Solution:
            //! Only pass a valid system reference.
            public const int nxErrInvalidSystemHandle = (NX_ERROR_BASE | 0x021);

            //! A device reference was expected for a NI-XNET session function. Solution:
            //! Only pass a device reference.
            public const int nxErrDeviceHandleExpected = (NX_ERROR_BASE | 0x022);

            //! An interface reference was expected for a NI-XNET session function.
            //! Solution: Only pass an interface reference.
            public const int nxErrIntfHandleExpected = (NX_ERROR_BASE | 0x023);

            //! You have configured a property that conflicts with the current mode of the
            //! session. For example, you have created a CAN output session with a frame
            //! configured with a Timing Type = Cyclic and a Transmit Time of 0.
            public const int nxErrPropertyModeConflicting = (NX_ERROR_BASE | 0x024);

            //! XNET Create Timing Source VI is not supported on Windows. This VI is
            //! supported on LabVIEW Real-Time targets only.
            public const int nxErrTimingSourceNotSupported = (NX_ERROR_BASE | 0x025);

            //! You tried to create more than one LabVIEW timing source for a single
            //! interface. Only one timing source per interface is supported. The timing
            //! source remains until the top-level VI is idle (no longer running). Solution:
            //! Call the XNET Create Timing Source VI only once per interface. You can use
            //! the timing source with multiple timed structures (e.g. timed loops).
            public const int nxErrMultipleTimingSource = (NX_ERROR_BASE | 0x026);

            //! You invoked two or more VIs simultaneously for the same session, and those
            //! VIs do not support overlap. For example, you attempted to invoke two Read
            //! VIs at the same time for the same session. Solution: Wire the error cluster
            //! from one VI to another, to enforce sequential execution for the session.
            public const int nxErrOverlappingIO = (NX_ERROR_BASE | 0x027);

            //! You are trying to start an interface that is missing bus power for the
            //! transceiver. Some physical layers on NI-XNET hardware are internally
            //! powered, but others require external power for the port to operate. This
            //! error occurs when starting an interface on hardware that requires external
            //! power when no power is detected. Solution: Supply proper voltage to your
            //! transceiver. Refer to the NI-XNET Hardware Overview in the NI-XNET Hardware
            //! and Software Manual for more information.
            public const int nxErrMissingBusPower = (NX_ERROR_BASE | 0x028);

            //! The connection with a CompactDAQ chassis was lost, and the host software and
            //! modules are out of sync. There is no direct recovery for this problem until
            //! the chassis is reset. Solutions: Call DAQmx Reset Device as the first VI or
            //! function in your application, prior to creating XNET sessions. Alternately,
            //! you could reset the CompactDAQ chassis in Measurement and Automation
            //! Explorer (MAX).
            public const int nxErrCdaqConnectionLost = (NX_ERROR_BASE | 0x029);

            //! The transceiver value set is invalid (for this port, e.g. LS on a HS port)
            //! or you are trying to perform an operation that requires a different
            //! transceiver (e.g., trying to change the state of a disconnected
            //! transceiver). Solution: set a valid value.
            public const int nxErrInvalidTransceiver = (NX_ERROR_BASE | 0x071);

            //! The baud rate value set is invalid. Solution: set a valid value.
            public const int nxErrInvalidBaudRate = (NX_ERROR_BASE | 0x072);

            //! No baud rate value has been set. Solution: set a valid value.
            public const int nxErrBaudRateNotConfigured = (NX_ERROR_BASE | 0x073);

            //! The bit timing values set are invalid. Solution: set valid values.
            public const int nxErrInvalidBitTimings = (NX_ERROR_BASE | 0x074);

            //! The baud rate set does not match the transceiver's allowed range. Solution:
            //! change either the baud rate or the transceiver.
            public const int nxErrBaudRateXcvrMismatch = (NX_ERROR_BASE | 0x075);

            //! The configured terminal is not known for this interface. Solution: Make sure
            //! that that you pass in a valid value to Connect Terminals or Disconnect
            //! Terminals.
            public const int nxErrUnknownTimingSource = (NX_ERROR_BASE | 0x076);

            //! The configured terminal is inappropriate for the hardware. For example,
            //! setting a source to FrontPanel0 on XNET hardware that doesn't have
            //! front-panel trigger inputs, or selecting PXI_Clk10 for a non-PXI device.
            //! Solution: Pick an appropriate terminal for the hardware.
            public const int nxErrUnknownSynchronizationSource = (NX_ERROR_BASE | 0x077);

            //! The source that you connected to the Master Timebase destination is missing.
            //! When the start trigger is received, the interface verifies that a signal is
            //! present on the configured source. This check has determined that this signal
            //! is missing. Solution: Verify that your cables are configured correctly and
            //! that your timebase source is generating an appropriate waveform.
            public const int nxErrMissingTimebaseSource = (NX_ERROR_BASE | 0x078);

            //! The source that you connected to the Master Timebase destination is not
            //! generating an appropriate signal. When the start trigger is received, the
            //! interface verifies that a signal of a known frequency is present on the
            //! configured source. This check has determined that this source is generating
            //! a signal, but that the signal is not one of the supported frequencies for
            //! this hardware. Solution: Verify that your source is generating a signal at a
            //! supported frequency.
            public const int nxErrUnknownTimebaseFrequency = (NX_ERROR_BASE | 0x079);

            //! You are trying to disconnect a synchronization terminal that is not
            //! currently connected. Solution: Only disconnect synchronization terminals
            //! that have previously been connected.
            public const int nxErrUnconnectedSynchronizationSource = (NX_ERROR_BASE | 0x07A);

            //! You are trying to connect a synchronization terminal that is already in use.
            //! For example, you are trying to connect a trigger line to the Master Timebase
            //! when a different trigger line is already connected to the Master Timebase.
            //! Solution: Only connect to synchronization terminals that are not currently
            //! in use.
            public const int nxErrConnectedSynchronizationTerminal = (NX_ERROR_BASE | 0x07B);

            //! You are trying to connect an XNET terminal as a source terminal, but the
            //! desired XNET terminal is not valid as a source terminal. Solution: Only
            //! connect valid source terminals to the source terminal in XNET Connect
            //! Terminals.
            public const int nxErrInvalidSynchronizationSource = (NX_ERROR_BASE | 0x07C);

            //! You are trying to connect an XNET terminal as a destination terminal, but
            //! the desired XNET terminal is not valid as a destination terminal. Solution:
            //! Only connect valid destination terminals to the destination terminal in XNET
            //! Connect Terminals.
            public const int nxErrInvalidSynchronizationDestination = (NX_ERROR_BASE | 0x07D);

            //! You are trying to connect two XNET terminals that are incompatible.
            //! Solution: Only connect a source and destination terminals that are
            //! compatible with each other.
            public const int nxErrInvalidSynchronizationCombination = (NX_ERROR_BASE | 0x07E);

            //! The source that you connected to the Master Timebase destination has
            //! disappeared. When the start trigger is received, the interface verifies that
            //! a signal is present on the configured source. This check has determined that
            //! this signal was present, but while the interface was running, the signal
            //! disappeared, so all timebase configuration has reverted to using the onboard
            //! (unsynchronized) oscillator. Solution: Verify that your cables are
            //! configured correctly and that your timebase source is generating an
            //! appropriate waveform the entire time your application is running.
            public const int nxErrTimebaseDisappeared = (NX_ERROR_BASE | 0x07F);

            //! You called Read (State : FlexRay : Cycle Macrotick), and the FlexRay
            //! Macrotick is not connected as the master timebase of the interface.
            //! Solution: Call Connect Terminals to connect source of FlexRay Macrotick to
            //! destination of Master Timebase.
            public const int nxErrMacrotickDisconnected = (NX_ERROR_BASE | 0x080);

            //! The database specified could not be opened. Solution: Check that the alias
            //! and/or the file exist and that it is a valid database.
            public const int nxErrCannotOpenDatabaseFile = (NX_ERROR_BASE | 0x081);

            //! The cluster was not found in the database. Solution: Make sure you only
            //! initialize a cluster in a session that is defined in the database.
            public const int nxErrClusterNotFound = (NX_ERROR_BASE | 0x082);

            //! The frame was not found in the database. Solution: Make sure you only
            //! initialize frames in a session that are defined in the database.
            public const int nxErrFrameNotFound = (NX_ERROR_BASE | 0x083);

            //! The signal was not found in the database. Solution: Make sure you only
            //! initialize signals in a session that are defined in the database.
            public const int nxErrSignalNotFound = (NX_ERROR_BASE | 0x084);

            //! A necessary property for a cluster was not found in the database. Solution:
            //! Make sure you only initialize a cluster in a session that is completely
            //! defined in the database.
            public const int nxErrUnconfiguredCluster = (NX_ERROR_BASE | 0x085);

            //! A necessary property for a frame was not found in the database. Solution:
            //! Make sure you only initialize frames in a session that are completely
            //! defined in the database.
            public const int nxErrUnconfiguredFrame = (NX_ERROR_BASE | 0x086);

            //! A necessary property for a signal was not found in the database. Solution:
            //! Make sure you only initialize signals in a session that are completely
            //! defined in the database.
            public const int nxErrUnconfiguredSignal = (NX_ERROR_BASE | 0x087);

            //! Multiple clusters have been specified in one session, either directly
            //! (Stream I/O), or through the signals or frames specified. Solution: Make
            //! sure that in one session, you open only one cluster, including frames or
            //! signals that belong to the same cluster.
            public const int nxErrMultipleClusters = (NX_ERROR_BASE | 0x088);

            //! You specified a database of ':subordinate:' for a session mode other than
            //! mode of Frame Input Stream. Solution: either open a Frame Input Stream
            //! session, or use a real or in-memory database.
            public const int nxErrSubordinateNotAllowed = (NX_ERROR_BASE | 0x089);

            //! The interface name given does not specify a valid and existing interface.
            //! Solution: Use a valid and existing interface. These can be obtained using
            //! MAX, XNET system properties, or the LabVIEW XNET Interface IO name. If you
            //! are using CompactRIO, refer to the topic "Getting Started with CompactRIO"
            //! in the NI-XNET Hardware and Software Help.
            public const int nxErrInvalidInterface = (NX_ERROR_BASE | 0x08A);

            //! The operation is invalid for this interface (e.g. you tried to open a set of
            //! FlexRay frames on a CAN interface, or tried to request a CAN property from a
            //! FlexRay interface). Solution: run this operation on a suitable interface.
            public const int nxErrInvalidProtocol = (NX_ERROR_BASE | 0x08B);

            //! You tried to set the AutoStart property to FALSE for an Input session. This
            //! is not allowed. Solution: don't set the AutoStart property (TRUE is
            //! default).
            public const int nxErrInputSessionMustAutoStart = (NX_ERROR_BASE | 0x08C);

            //! The property ID you specified is not valid (or not valid for the current
            //! session mode or form factor).
            public const int nxErrInvalidPropertyId = (NX_ERROR_BASE | 0x08D);

            //! The contents of the property is bigger than the size specified. Use the
            //! nxGetPropertySize function to determine the size of the buffer needed.
            public const int nxErrInvalidPropertySize = (NX_ERROR_BASE | 0x08E);

            //! The function you called is not defined for the session mode (e.g. you called
            //! a frame I/O function on a signal I/O session).
            public const int nxErrIncorrectMode = (NX_ERROR_BASE | 0x08F);

            //! The data that you passed to the XNET Write is too small to hold all the data
            //! specified for the session. Solution: determine the number of elements
            //! (frames or signals) that you configured for the session, and pass that
            //! number of elements to XNET Write.
            public const int nxErrBufferTooSmall = (NX_ERROR_BASE | 0x090);

            //! For Signal Output sessions, the multiplexer signals used in the session must
            //! be specified explicitly in the signal list.
            public const int nxErrMustSpecifyMultiplexers = (NX_ERROR_BASE | 0x091);

            //! You used an XNET Session IO name, and that session was not found in your
            //! LabVIEW project. Solution: Within LabVIEW project, right-click the target
            //! (RT or My Computer), and select New > NI-XNET Session. Add the VI that uses
            //! the session under the target. If you are using the session with a built
            //! application (.EXE), ensure that you copy the built configuration file
            //! nixnetSession.txt such that it resides in the same folder as the executable.
            public const int nxErrSessionNotFound = (NX_ERROR_BASE | 0x092);

            //! You used the same XNET session name in multiple top-level VIs, which is not
            //! supported. Solution: Use each session in only one top-level VI (application)
            //! at a time.
            public const int nxErrMultipleUseOfSession = (NX_ERROR_BASE | 0x093);

            //! To execute this function properly, the session's list must contain only one
            //! frame. Solution: break your session up into multiple, each of which contains
            //! only one frame.
            public const int nxErrOnlyOneFrame = (NX_ERROR_BASE | 0x094);

            //! You used the same alias for different database files which is not allowed.
            //! Solution: Use each alias only for a single database file.
            public const int nxErrDuplicateAlias = (NX_ERROR_BASE | 0x095);

            //! You try to deploy a database file while another deployment is in progress.
            //! Solution: wait until the other deployment has finished and try again.
            public const int nxErrDeploymentInProgress = (NX_ERROR_BASE | 0x096);

            //! A signal or frame session has been opened, but it doesn’t contain signals or
            //! frames. Solution: specify at least one signal or frame.
            public const int nxErrNoFramesOrSignals = (NX_ERROR_BASE | 0x097);

            //! An invalid value has been specified for the ‘mode’ parameter. Solution:
            //! specify a valid value.
            public const int nxErrInvalidMode = (NX_ERROR_BASE | 0x098);

            //! A session was created by references, but no database references have been
            //! specified. Solution: specify at least one appropriate database reference
            //! (i.e. signal or frame or cluster ref depending on the session mode).
            public const int nxErrNeedReference = (NX_ERROR_BASE | 0x099);

            //! The interface has already been opened with different cluster settings than
            //! the ones specified for this session. Solution: make sure that the cluster
            //! settings agree for the interface, or use a different interface.
            public const int nxErrDifferentClusterOpen = (NX_ERROR_BASE | 0x09A);

            //! The cycle repetition of a frame in the database for the FlexRay protocol is
            //! invalid. Solution: Make sure that the cycle repetition is a power of 2
            //! between 1 and 64.
            public const int nxErrFlexRayInvalidCycleRep = (NX_ERROR_BASE | 0x09B);

            //! You called XNET Clear for the session, then tried to perform another
            //! operation. Solution: Defer clear (session close) until you are done using
            //! it. This error can also occur if you branch a wire after creating the
            //! session. Solution: Do not branch a session to multiple flows in the diagram.
            public const int nxErrSessionCleared = (NX_ERROR_BASE | 0x09C);

            //! You called Create Session VI with a list of items that does not match the
            //! mode. This includes using: 1) signal items for a Frame I/O mode 2) frame
            //! items for a Signal I/O mode 3) cluster item for a mode other than Frame
            //! Input Stream or Frame Output Stream
            public const int nxErrWrongModeForCreateSelection = (NX_ERROR_BASE | 0x09D);

            //! You tried to create a new session while the interface is already running.
            //! Solution: Create all sessions before starting any of them.
            public const int nxErrInterfaceRunning = (NX_ERROR_BASE | 0x09E);

            //! You wrote a frame whose payload length is larger than the maximum payload
            //! allowed by the database (e.g. wrote 10 bytes for CAN frame, max 8 bytes).
            //! Solution: Never write more payload bytes than the Payload Length Maximum
            //! property of the session.
            public const int nxErrFrameWriteTooLarge = (NX_ERROR_BASE | 0x09F);

            //! You called a Read function with a nonzero timeout, and you used a negative
            //! numberToRead. Negative value for numberToRead requests all available data
            //! from the Read, which is ambiguous when used with a timeout. Solutions: 1)
            //! Pass timeout of and numberToRead of -1, to request all available data. 2)
            //! Pass timeout > 0, and numberToRead > 0, to wait for a specific number of
            //! data elements.
            public const int nxErrTimeoutWithoutNumToRead = (NX_ERROR_BASE | 0x0A0);

            //! Timestamps are not (yet) supported for Write Signal XY. Solution: Do not
            //! provide a timestamp array for Write Signal XY.
            public const int nxErrTimestampsNotSupported = (NX_ERROR_BASE | 0x0A1);

            // \REVIEW: Rename to WaitCondition
            //! The condition parameter passed to Wait is not known. Solution: Pass a valid
            //! parameter.
            public const int nxErrUnknownCondition = (NX_ERROR_BASE | 0x0A2);

            //! You attempted an I/O operation, but the session is not yet started (and the
            //! AutoStart property is set to FALSE). Solution: call Start before you use
            //! this IO operation.
            public const int nxErrSessionNotStarted = (NX_ERROR_BASE | 0x0A3);

            //! The maximum number of Wait operations has been exceeded. Solution: If you
            //! are waiting for multiple events on the interface, use fewer Wait operations
            //! on this interface (even for multiple sessions). If you are waiting for
            //! multiple events for a frame (e.g. transmit complete), use only one Wait at a
            //! time for that frame.
            public const int nxErrMaxWaitsExceeded = (NX_ERROR_BASE | 0x0A4);

            //! You used an invalid name for an XNET Device. Solution: Get valid XNET Device
            //! names from the XNET System properties (only).
            public const int nxErrInvalidDevice = (NX_ERROR_BASE | 0x0A5);

            //! A terminal name passed to ConnectTerminals or DisconnectTerminals is
            //! unknown. Solution: only pass valid names.
            public const int nxErrInvalidTerminalName = (NX_ERROR_BASE | 0x0A6);

            //! You tried to blink the port LEDs but these are currently busy. Solution:
            //! stop all applications running on that port; do not access it from MAX or LV
            //! Project.
            public const int nxErrPortLEDsBusy = (NX_ERROR_BASE | 0x0A7);

            //! You tried to set a FlexRay keyslot ID that is not listed as valid in the
            //! database. Solution: only pass slot IDs of frames that have the startup or
            //! sync property set in the database.
            public const int nxErrInvalidKeyslot = (NX_ERROR_BASE | 0x0A8);

            //! You tried to set a queue size that is bigger than the maximum allowed.
            //! Solution: Specify an in-range queue size.
            public const int nxErrMaxQueueSizeExceeded = (NX_ERROR_BASE | 0x0A9);

            //! You wrote a frame whose payload length is different than the payload length
            //! configured by the database. Solution: Never write a different payload length
            //! for a frame that is different than the configured payload length.
            public const int nxErrFrameSizeMismatch = (NX_ERROR_BASE | 0x0AA);

            //! The index to indicate an session list element is too large. Solution:
            //! Specify an index in the range ... NumInList-1.
            public const int nxErrIndexTooBig = (NX_ERROR_BASE | 0x0AB);

            //! You have tried to create a session that is invalid for the mode of the
            //! driver/firmware. For example, you are using the Replay Exclusive mode for
            //! Stream Output and you have an output session open.
            public const int nxErrSessionModeIncompatibility = (NX_ERROR_BASE | 0x0AC);

            //! You have tried to create a session using a frame that is incompatible with
            //! the selected session type. For example, you are using a LIN diagnostic frame
            //! with a single point output session.
            public const int nxErrSessionTypeFrameIncompatibility = (NX_ERROR_BASE | 0x15D);

            //! The trigger signal for a frame is allowed only in Single Point Signal
            //! sessions (Input or Output). For Output Single Point Signal Sessions only one
            //! trigger signal is allowed per frame. Solution: Do not use the trigger
            //!signal, or change to a single point I/O session.
            public const int nxErrTriggerSignalNotAllowed = (NX_ERROR_BASE | 0x0AD);

            //! To execute this function properly, the session's list must contain only one
            //! cluster. Solution: Use only one cluster in the session.
            public const int nxErrOnlyOneCluster = (NX_ERROR_BASE | 0x0AE);

            //! You attempted to convert a CAN or LIN frame with a payload length greater
            //! than 8. For example, you may be converting a frame that uses a higher layer
            //! transport protocol, such as SAE-J1939. NI-XNET currently supports conversion
            //! of CAN/LIN frames only (layer 2). Solutions: 1) Implement higher layer
            //! protocols (including signal conversion) within your code. 2) Contact
            //! National Instruments to request this feature in a future version.
            public const int nxErrConvertInvalidPayload = (NX_ERROR_BASE | 0x0AF);

            //! Allocation of memory failed for the data returned from LabVIEW XNET Read.
            //! Solutions: 1) Wire a smaller "number to read" to XNET Read (default -1 uses
            //! queue size). 2) For Signal Input Waveform, use a smaller resample rate. 3)
            //! Set smaller value for session's queue size property (default is large to
            //! avoid loss of data).
            public const int nxErrMemoryFullReadData = (NX_ERROR_BASE | 0x0B0);

            //! Allocation of memory failed in the firmware. Solutions: 1) Create less
            //! firmware objects 2) Set smaller value for output session's queue size
            //! property (default is large to avoid loss of data).
            public const int nxErrMemoryFullFirmware = (NX_ERROR_BASE | 0x0B1);

            //! The NI-XNET driver no longer can communicate with the device. Solution: Make
            //! sure the device has not been removed from the computer.
            public const int nxErrCommunicationLost = (NX_ERROR_BASE | 0x0B2);

            //! A LIN schedule has an invalid priority. Solution: Use a valid priority (0 =
            //! NULL schedule, 1..254 = Run once schedule, 255 = Continuous schedule).
            public const int nxErrInvalidPriority = (NX_ERROR_BASE | 0x0B3);

            //! (Dis)ConnectTerminals is not allowed for XNET C Series modules. Solution: To
            //! connect the module start trigger, use the Session property Interface Source
            //! Terminal Start Trigger.
            public const int nxErrSynchronizationNotAllowed = (NX_ERROR_BASE | 0x0B4);

            //! You requested a time (like Start or Communication Time) before the event has
            //! happened. Solution: Request the time only after it occurred.
            public const int nxErrTimeNotReached = (NX_ERROR_BASE | 0x0B5);

            //! An internal input queue overflowed. Solution: Attempt to pull data from the
            //! hardware faster. If you are connected by an external bus (for example, USB
            //! or Ethernet), you can try to use a faster connection.
            public const int nxErrInternalInputQueueOverflow = (NX_ERROR_BASE | 0x0B6);

            //! A bad firmware image file can not be loaded to the hardware. Solution:
            //! Uninstall and reinstall the NI-XNET software as the default firmware file
            //! may be corrupt. If you are using a custom firmware file, try rebuilding it.
            public const int nxErrBadImageFile = (NX_ERROR_BASE | 0x0B7);

            //! The encoding of embedded network data (CAN, FlexRay, LIN, etc.) within the
            //! TDMS file is invalid. Solutions: 1) In the application that wrote (created)
            //! the logfile, and the application in which you are reading it, confirm that
            //! both use the same major version for frame data encoding
            //! (NI_network_frame_version property of the TDMS channel). 2) Ensure that your
            //! file was not corrupted.
            public const int nxErrInvalidLogfile = (NX_ERROR_BASE | 0x0B8);

            //! A property value was out of range or incorrect. Solution: specify a correct
            //! value.
            public const int nxErrInvalidPropertyValue = (NX_ERROR_BASE | 0x0C0);

            //! Integration of the interface into the FlexRay cluster failed, so
            //! communication did not start for the interface. Solution: check the cluster
            //! and/or interface parameters and verify that there are startup frames
            //! defined.
            public const int nxErrFlexRayIntegrationFailed = (NX_ERROR_BASE | 0x0C1);

            //! The PDU was not found in the database. Solution: Make sure you initialize
            //! only PDUs in a session that are defined in the database.
            public const int nxErrPduNotFound = (NX_ERROR_BASE | 0x0D0);

            //! A necessary property for a PDU was not found in the database. Solution: Make
            //! sure you initialize only PDUs in a session that are completely defined in
            //! the database.
            public const int nxErrUnconfiguredPdu = (NX_ERROR_BASE | 0x0D1);

            //! You tried to open the same PDU twice. This is not permitted. Solution: Open
            //! each PDU only once.
            public const int nxErrDuplicatePduObject = (NX_ERROR_BASE | 0x0D2);

            //! You can access this database object only by PDU, not by frame. Solution: For
            //! CAN and LIN, this is not supported by the current version of NI-XNET; for
            //! FlexRay, make sure the database is set to use PDUs.
            public const int nxErrNeedPdu = (NX_ERROR_BASE | 0x0D3);

            //! Remote communication with the LabVIEW RT target failed. Solution: check if
            //! NI-XNET has been installed on the RT target and check if the NI-XNET RPC
            //! server has been started.
            public const int nxErrRPCCommunication = (NX_ERROR_BASE | 0x100);

            //! File transfer communication with the LabVIEW Real-Time (RT) target failed.
            //! Solution: check if the RT target has been powered on, the RT target has been
            //! connected to the network, and if the IP address settings are correct.
            public const int nxErrFileTransferCommunication = (NX_ERROR_BASE | 0x101);
            public const int nxErrFTPCommunication = (NX_ERROR_BASE | 0x101);

            //! File transfer on the LabVIEW Real-Time (RT) target failed, because the
            //! required files could not be accessed. Solution: You may have executed a VI
            //! that opened the database, but did not close. If that is the case, you should
            //! change the VI to call Database Close, then reboot the RT controller to
            //! continue.
            public const int nxErrFileTransferAccess = (NX_ERROR_BASE | 0x102);
            public const int nxErrFTPFileAccess = (NX_ERROR_BASE | 0x102);

            //! The database file you want to use is already assigned to another alias.
            //! Solution: Each database file can only be assigned to a single alias. Use the
            //! alias that is already assigned to the database instead.
            public const int nxErrDatabaseAlreadyInUse = (NX_ERROR_BASE | 0x103);

            //! An internal file used by NI-XNET could not be accessed. Solution: Make sure
            //! that the internal NI-XNET files are not write protected and that the
            //! directories for these files exist.
            public const int nxErrInternalFileAccess = (NX_ERROR_BASE | 0x104);

            //! The file cannot be deployed because another file deployment is already
            //! active. Solution: wait until the other file deployment has finished and try
            //! again.
            public const int nxErrFileTransferActive = (NX_ERROR_BASE | 0x105);

            //! The nixnet.dll or one of its components could not be loaded. Solution: try
            //! reinstalling NI-XNET. If the error persists,contact National Instruments.
            public const int nxErrDllLoad = (NX_ERROR_BASE | 0x117);

            //! You attempted to perform an action on a session or interface that is
            //! started, and the action that requires the session/interface to be stopped.
            //! Solution: Stop the object before performing this action.
            public const int nxErrObjectStarted = (NX_ERROR_BASE | 0x11E);

            //! You have passed a default payload to the firmware where the number of bytes
            //! in the payload is larger than the number of bytes that this frame can
            //! transmit. Solution: Decrease the number of bytes in your default payload.
            public const int nxErrDefaultPayloadNumBytes = (NX_ERROR_BASE | 0x11F);

            //! You attempted to set a CAN arbitration ID with an invalid value. For
            //! example, a CAN standard arbitration ID supports only 11 bits. If you attempt
            //! to set a standard arbitration ID that uses more than 11 bits, this error is
            //! returned. Solution: Use a valid arbitration ID.
            public const int nxErrInvalidArbitrationId = (NX_ERROR_BASE | 0x123);

            //! You attempted to set a LIN ID with an invalid value. For example, a LIN ID
            //! supports only 6 bits. If you attempt to set an ID that uses more than 6
            //! bits, this error is returned. Solution: Use a valid LIN ID.
            public const int nxErrInvalidLinId = (NX_ERROR_BASE | 0x124);

            //! Too many open files. NI-XNET allows up to 7 database files to be opened
            //! simultaneously. Solution: Open fewer files.
            public const int nxErrTooManyOpenFiles = (NX_ERROR_BASE | 0x130);

            //! Bad reference has been passed to a database function, e.g. a session
            //! reference, or frame reference to retrieve properties from a signal.
            public const int nxErrDatabaseBadReference = (NX_ERROR_BASE | 0x131);

            //! Creating a database file failed. Solution: Verify access rights to the
            //! destination directory or check if overwritten file has read only permission.
            public const int nxErrCreateDatabaseFile = (NX_ERROR_BASE | 0x132);

            //! A cluster with the same name already exists in the database. Solution: Use
            //! another name for this cluster.
            public const int nxErrDuplicateClusterName = (NX_ERROR_BASE | 0x133);

            //! A frame with the same name already exists in the cluster. Solution: Use
            //! another name for this frame.
            public const int nxErrDuplicateFrameName = (NX_ERROR_BASE | 0x134);

            //! A signal with the same name already exists in the frame. Solution: Use
            //! another name for this signal.
            public const int nxErrDuplicateSignalName = (NX_ERROR_BASE | 0x135);

            //! An ECU with the same name already exists in the cluster. Solution: Use
            //! another name for this ECU.
            public const int nxErrDuplicateECUName = (NX_ERROR_BASE | 0x136);

            //! A subframe with the same name already exists in the frame. Solution: Use
            //! another name for this subframe.
            public const int nxErrDuplicateSubframeName = (NX_ERROR_BASE | 0x137);

            //! The operation is improper for the protocol in use, e.g. you cannot assign
            //! FlexRay channels to a CAN frame.
            public const int nxErrImproperProtocol = (NX_ERROR_BASE | 0x138);

            //! Wrong parent relationship for a child that you are creating with XNET
            //! Database Create.
            public const int nxErrObjectRelation = (NX_ERROR_BASE | 0x139);

            //! The retrieved required property is not defined on the specified object.
            //! Solution: Make sure that your database file has this property defined or
            //! that you set it in the objects created in memory.
            public const int nxErrUnconfiguredRequiredProperty = (NX_ERROR_BASE | 0x13B);

            //! The feature is not supported under LabVIEW RT, e.g.Save Database
            public const int nxErrNotSupportedOnRT = (NX_ERROR_BASE | 0x13C);

            //! The object name contains unsupported characters. The name must contain just
            //! alphanumeric characters and the underscore, but cannot begin with a digit.
            //! The maximum size is 128.
            public const int nxErrNameSyntax = (NX_ERROR_BASE | 0x13D);

            //! Unsupported database format. For reading a database, the extension must be
            //! .xml, .dbc, .ncd, or .ldf. For saving, the extension must be .xml.
            public const int nxErrFileExtension = (NX_ERROR_BASE | 0x13E);

            //! Database object not found, e.g. an object with given name doesn't exist.
            public const int nxErrDatabaseObjectNotFound = (NX_ERROR_BASE | 0x13F);

            //! Database cache file cannot be removed or replaced on the disc, e.g. it is
            //! write-protected.
            public const int nxErrRemoveDatabaseCacheFile = (NX_ERROR_BASE | 0x140);

            //! You are trying to write a read-only property, e.g. the mux value on a signal
            //! is a read only property (can be changed on the subframe).
            public const int nxErrReadOnlyProperty = (NX_ERROR_BASE | 0x141);

            //! You are trying to change a signal to be a mux signal, but a mux is already
            //! defined in this frame
            public const int nxErrFrameMuxExists = (NX_ERROR_BASE | 0x142);

            //! You are trying to define FlexRay in-cycle-repetition slots before defining
            //! the first slot. Define the first slot (frame ID) before defining
            //! in-cycle-repetition slots.
            public const int nxErrUndefinedFirstSlot = (NX_ERROR_BASE | 0x144);

            //! You are trying to define FlexRay in-cycle-repetition channels before
            //! defining the first channels. Define the Channel Assignment on a frame before
            //! defining in-cycle-repetition channels.
            public const int nxErrUndefinedFirstChannels = (NX_ERROR_BASE | 0x145);

            //! You must define the protocol before setting this property, e.g. the frame ID
            //! has a different meaning in a CAN or FlexRay cluster.
            public const int nxErrUndefinedProtocol = (NX_ERROR_BASE | 0x146);

            //! The database information on the real-time system has been created with an
            //! older NI-XNET version. This version is no longer supported. To correct this
            //! error, re-deploy your database to the real-time system.
            public const int nxErrOldDatabaseCacheFile = (NX_ERROR_BASE | 0x147);

            //! Frame ConfigStatus: A signal within the frame exceeds the frame boundaries
            //! (Payload Length).
            public const int nxErrDbConfigSigOutOfFrame = (NX_ERROR_BASE | 0x148);

            //! Frame ConfigStatus: A signal within the frame overlaps another signal.
            public const int nxErrDbConfigSigOverlapped = (NX_ERROR_BASE | 0x149);

            //! Frame ConfigStatus: A integer signal within the frame is defined with more
            //! than 52 bits. Not supported.
            public const int nxErrDbConfigSig52BitInteger = (NX_ERROR_BASE | 0x14A);

            //! Frame ConfigStatus: Frame is defined with wrong number of bytes Allowed
            //! values: - CAN: 0-8, - Flexray: 0-254 and even number.
            public const int nxErrDbConfigFrameNumBytes = (NX_ERROR_BASE | 0x14B);

            //! You are trying to add transmitted FlexRay frames to an ECU, with at least
            //! two of them having Startup or Sync property on. Only one Sync or Startup
            //! frame is allowed to be sent by an ECU.
            public const int nxErrMultSyncStartup = (NX_ERROR_BASE | 0x14C);

            //! You are trying to add TX/RX frames to an ECU which are defined in a
            //! different cluster than the ECU.
            public const int nxErrInvalidCluster = (NX_ERROR_BASE | 0x14D);

            //! Database name parameter is incorrect. Solution: Use a valid name for the
            //! database, e.g. ":memory:" for in-memory database.
            public const int nxErrDatabaseName = (NX_ERROR_BASE | 0x14E);

            //! Database object is locked because it is used in a session. Solution:
            //! Configure the database before using it in a session.
            public const int nxErrDatabaseObjectLocked = (NX_ERROR_BASE | 0x14F);

            //! Alias name passed to a function is not defined. Solution: Define the alias
            //! before calling the function.
            public const int nxErrAliasNotFound = (NX_ERROR_BASE | 0x150);

            //! Database file cannot be saved because frames are assigned to FlexRay
            //! channels not defined in the cluster. Solution: Verify that all frames in the
            //! FlexRay cluster are assigned to an existing cluster channel.
            public const int nxErrClusterFrameChannelRelation = (NX_ERROR_BASE | 0x151);

            //! Frame ConfigStatus: This FlexRay frame transmitted in a dynamic segment uses
            //! both channels A and B. This is not allowed. Solution: Use either channel A
            //! or B.
            public const int nxErrDynFlexRayFrameChanAandB = (NX_ERROR_BASE | 0x152);

            //! Database is locked because it is being modified by an another instance of
            //! the same application. Solution: Close the database in the other application
            //! instance.
            public const int nxErrDatabaseLockedInUse = (NX_ERROR_BASE | 0x153);

            //! A frame name is ambiguous, e.g. a frame with the same name exists in another
            //! cluster. Solution: Specify the cluster name for the frame using the required
            //! syntax.
            public const int nxErrAmbiguousFrameName = (NX_ERROR_BASE | 0x154);

            //! A signal name is ambiguous, e.g. a signal with the same name exists in
            //! another frame. Solution: Use [frame].[signal] syntax for the signal.
            public const int nxErrAmbiguousSignalName = (NX_ERROR_BASE | 0x155);

            //! An ECU name is ambiguous, e.g. an ECU with the same name exists in another
            //! cluster. Solution: Specify the cluster name for the ECU using the required
            //! syntax.
            public const int nxErrAmbiguousECUName = (NX_ERROR_BASE | 0x156);

            //! A subframe name is ambiguous, e.g. a subframe with the same name exists in
            //! another cluster. Solution: Specify the cluster name for the subframe using
            //! the required syntax.
            public const int nxErrAmbiguousSubframeName = (NX_ERROR_BASE | 0x157);

            //! A LIN schedule name is ambiguous, e.g. a schedule with the same name exists
            //! in another cluster. Solution: Specify the cluster name for the schedule
            //! using the required syntax.
            public const int nxErrAmbiguousScheduleName = (NX_ERROR_BASE | 0x158);

            //! A LIN schedule with the same name already exists in the database. Solution:
            //! Use another name for this schedule.
            public const int nxErrDuplicateScheduleName = (NX_ERROR_BASE | 0x159);

            //! A LIN diagnostic schedule change requires the diagnostic schedule to be
            //! defined in the database. Solution: Define the diagnostic schedule in the
            //! database.
            public const int nxErrDiagnosticScheduleNotDefined = (NX_ERROR_BASE | 0x18F);

            //! Multiplexers (mode-dependent signals) are not supported when the given
            //! protocol is used. Solution: Contact National Instruments to see whether
            //! there is a newer NI-XNET version that supports multiplexers for the given
            //! protocol.
            public const int nxErrProtocolMuxNotSupported = (NX_ERROR_BASE | 0x15A);

            //! Saving a FIBEX file containing a LIN cluster is not supported in this
            //! NI-XNET version. Solution: Contact National Instruments to see whether there
            //! is a newer NI-XNET version that supports saving a FIBEX file that contains a
            //! LIN cluster.
            public const int nxErrSaveLINnotSupported = (NX_ERROR_BASE | 0x15B);

            //! This property requires an ECU configured as LIN master to be present in this
            //! cluster. Solution: Create a LIN master ECU in this cluster.
            public const int nxErrLINmasterNotDefined = (NX_ERROR_BASE | 0x15C);

            //! You cannot mix open of NI-XNET database objects as both manual and
            //! automatic. You open manually by calling the Database Open VI. You open
            //! automatically when you 1) wire the IO name directly to a property node or
            //! VI, 2) branch a wire to multiple data flows on the diagram, 3) use the IO
            //! name with a VI or property node after closing it with the Database Close VI.
            //! Solution: Change your diagram to use the manual technique in all locations
            //! (always call Open and Close VIs), or to use the automatic technique in all
            //! locations (never call Open or Close VIs).
            public const int nxErrMixAutoManualOpen = (NX_ERROR_BASE | 0x15E);

            //! Due to problems in LabVIEW versions 8.5 through 8.6.1, automatic open of
            //! NI-XNET database objects is not suppported. You open automatically when you
            //! 1) wire the IO name directly to a property node or VI, 2) branch a wire to
            //! multiple data flows on the diagram, 3) use the IO name with a VI or property
            //! node after closing it with the Database Close VI. Solution: Change your
            //! diagram to call the Database Open VI prior to any use (VI or property node)
            //! in a data flow (including a new wire branch). Change your diagram to call
            //! the Database Close VI when you are finished using the database in your
            //! application.
            public const int nxErrAutoOpenNotSupported = (NX_ERROR_BASE | 0x15F);

            //! You called a Write function with the number of array elements (frames or
            //! signals) different than the number of elements configured in the session
            //! (such as the "list" parameter of the Create Session function). Solution:
            //! Write the same number of elements as configured in the session.
            public const int nxErrWrongNumSignalsWritten = (NX_ERROR_BASE | 0x160);

            //! You used XNET session from multiple LabVIEW projects (or multiple
            //! executables), which NI-XNET does not support. Solution: Run XNET sessions in
            //! only one LabVIEW project at a time.
            public const int nxErrMultipleLvProject = (NX_ERROR_BASE | 0x161);

            //! When an XNET session is used at runtime, all sessions in the same scope are
            //! created on the interface. The same scope is defined as all sessions within
            //! the same LabVIEW project which use the same cluster and interface (same
            //! physical cable configuration). If you attempt to use a session in the same
            //! scope after running the VI, this error occurs. The most likely cause is that
            //! you added a new session, and tried to use that new session in a running VI.
            //! Solution: Configure all session in LabVIEW project, then run the VI(s) that
            //! use those sessions.
            public const int nxErrSessionConflictLvProject = (NX_ERROR_BASE | 0x162);

            //! You used an empty name for an XNET database object (database, cluster, ECU,
            //! frame, or signal). Empty name is not supported. Solution: Refer to NI-XNET
            //! help for IO names to review the required syntax for the name, and change
            //! your code to use that syntax.
            public const int nxErrDbObjectNameEmpty = (NX_ERROR_BASE | 0x163);

            //! You used a name for an XNET database object (such as frame or signal) that
            //! did not include a valid cluster selection. Solution: Refer to the NI-XNET
            //! help for the IO name that you are using, and use the syntax specified for
            //! that class, which includes the cluster selection.
            public const int nxErrMissingAliasInDbObjectName = (NX_ERROR_BASE | 0x164);

            //! Unsupported FIBEX file version. Solution: Use only FIBEX versions that are
            //! supported by this version of NI-XNET. Please see the NI-XNET documentation
            //! for information on which FIBEX versions are currently supported.
            public const int nxErrFibexImportVersion = (NX_ERROR_BASE | 0x165);

            //! You used an empty name for the XNET Session. Empty name is not supported.
            //! Solution: Use a valid XNET session name from your LabVIEW project.
            public const int nxErrEmptySessionName = (NX_ERROR_BASE | 0x166);

            //! There is not enough message RAM on the FlexRay hardware to configure the
            //! data partition for the object(s). Solution: Please refer to the manual for
            //! limitations on the number of objects that can be created at any given time
            //! based on the payload length.
            public const int nxErrNotEnoughMessageRAMForObject = (NX_ERROR_BASE | 0x167);

            //! The FlexRay keyslot ID has been configured and a startup session has been
            //! created. Either the keyslot ID needs to be configured OR the startup session
            //! needs to be created. Both cannot exist at the same time. Solution: Choose a
            //! single method to configure startup sessions in your application.
            public const int nxErrKeySlotIDConfig = (NX_ERROR_BASE | 0x168);

            //! An unsupported session was created. For example, stream output is not
            //! supported on FlexRay hardware. Solution: Only use supported sessions in your
            //! application.
            public const int nxErrUnsupportedSession = (NX_ERROR_BASE | 0x169);


            //! An XNET session was created after starting the Interface. Only the Stream
            //! Input session in the subordinate mode can be created after the Interface has
            //! started. Solution: Create sessions prior to starting the XNET Interface in
            //! your application.
            public const int nxErrObjectCreatedAfterStart = (NX_ERROR_BASE | 0x170);

            //! The Single Slot property was enabled on the XNET FlexRay Interface after the
            //! interface had started. Solution: Enable the Single Slot property prior to
            //! starting the XNET FlexRay Interface.
            public const int nxErrSingleSlotEnabledAfterStart = (NX_ERROR_BASE | 0x171);

            //! The FlexRay macrotick offset specified for XNET Create Timing Source is
            //! unsupported. Example: Specifying a macrotick offset greater than
            //! MacroPerCycle will result in this error. Solution: Specify a macrotick
            //! offset within the supported range for the cluster.
            public const int nxErrUnsupportedNumMacroticks = (NX_ERROR_BASE | 0x172);

            //! You used invalid syntax in the name of a database object (signal, frame, or
            //! ECU). For example, you may have specified a frame's name as
            //! [cluster].[frame], which is allowed in NI-XNET for C/C++, but not NI-XNET
            //! for LabVIEW. Solution: Use the string syntax specified in the help topic for
            //! the XNET I/O name class you are using.
            public const int nxErrBadSyntaxInDatabaseObjectName = (NX_ERROR_BASE | 0x173);

            //! A LIN schedule entry name is ambiguous, e.g. a schedule entry with the same
            //! name exists in another schedule. Solution: Specify the schedule name for the
            //! schedule entry using the required syntax.
            public const int nxErrAmbiguousScheduleEntryName = (NX_ERROR_BASE | 0x174);

            //! A LIN schedule entry with the same name already exists in the schedule.
            //! Solution: Use another name for this schedule entry.
            public const int nxErrDuplicateScheduleEntryName = (NX_ERROR_BASE | 0x175);

            //! At least one of the frames in the session has an undefined identifier.
            //! Solution: Set the frame's "Identifier (Slot)" property before creating the
            //! session.
            public const int nxErrUndefinedFrameId = (NX_ERROR_BASE | 0x176);

            //! At least one of the frames in the session has an undefined payload length.
            //! Solution: Set the frame's "Payload Length (in bytes)" property before
            //! creating the session.
            public const int nxErrUndefinedFramePayloadLength = (NX_ERROR_BASE | 0x177);

            //! At least one of the signals in the session has an undefined start bit.
            //! Solution: Set the "Start Bit" property of the signal before creating the
            //! session.
            public const int nxErrUndefinedSignalStartBit = (NX_ERROR_BASE | 0x178);

            //! At least one of the signals in the session has an undefined number of bits.
            //! Solution: Set the "Number of Bits" property of the signal before creating
            //! the session.
            public const int nxErrUndefinedSignalNumBits = (NX_ERROR_BASE | 0x179);

            //! At least one of the signals in the session has an undefined byte order.
            //! Solution: Set the "Byte Order" property of the signal before creating the
            //! session.
            public const int nxErrUndefinedSignalByteOrder = (NX_ERROR_BASE | 0x17A);

            //! At least one of the signals in the session has an undefined data type.
            //! Solution: Set the "Data Type" property of the signal before creating the
            //! session.
            public const int nxErrUndefinedSignalDataType = (NX_ERROR_BASE | 0x17B);

            //! At least one of the subframes in the session has an undefined multiplexer
            //! value. Solution: Set the "Multiplexer Value" property of the subframe before
            //! creating the session.
            public const int nxErrUndefinedSubfMuxValue = (NX_ERROR_BASE | 0x17C);

            //! You provided an invalid index to Write (State LIN Schedule Change).
            //! Solution: Use a number from to N-1, where N is the number of LIN schedules
            //! returned from the cluster property LIN Schedules. If you are using LabVIEW,
            //! the string for the number must be decimal (not hexadecimal).
            public const int nxErrInvalidLinSchedIndex = (NX_ERROR_BASE | 0x17D);

            //! You provided an invalid name to Write (State LIN Schedule Change). Solution:
            //! Use a valid LIN schedule name returned from the cluster property LIN
            //! Schedules, or the session property Interface LIN Schedules. You can use the
            //! short name (schedule only) or long name (schedule plus database and
            //! cluster).
            public const int nxErrInvalidLinSchedName = (NX_ERROR_BASE | 0x17E);

            //! You provided an invalid active index for the session property.
            public const int nxErrInvalidActiveFrameIndex = (NX_ERROR_BASE | 0x17F);

            //! You provided an invalid name for Frame:Active of the session property node.
            //! Solution: Use a valid item name from the session's List property. You can
            //! use the short name (frame or signal only) or long name (frame/signal plus
            //! database and cluster).
            public const int nxErrInvalidActiveFrameName = (NX_ERROR_BASE | 0x180);

            //! The database you are using requires using PDUs, and the operation is
            //! ambiguous with respect to PDUs. Example: You are trying to get the frame
            //! parent of the signal, but the PDU in which the signal is contained is
            //! referenced in multiple frames.
            public const int nxErrAmbiguousPDU = (NX_ERROR_BASE | 0x181);

            //! A PDU with the same name already exists in the cluster. Solution: Use
            //! another name for this PDU.
            public const int nxErrDuplicatePDU = (NX_ERROR_BASE | 0x182);

            //! You are trying to assign start bits or update bits to PDUs referenced in a
            //! frame, but the number of elements in this array is different than the number
            //! of referenced PDUs. Solution: Use the same number of elements in the array
            //! as in the PDU references array.
            public const int nxErrNumberOfPDUs = (NX_ERROR_BASE | 0x183);

            //! The configuration of this object requires using advanced PDUs, which the
            //! given protocol does not support. Solution: You cannot use this object in the
            //! given protocol.
            public const int nxErrPDUsRequired = (NX_ERROR_BASE | 0x184);

            //! The maximum number of PDUs has been exceeded. Solution: Use fewer PDUs in
            //! your sessions.
            public const int nxErrMaxPDUs = (NX_ERROR_BASE | 0x185);

            //! This mode value is not currently supported. Solution: Use a valid value.
            public const int nxErrUnsupportedMode = (NX_ERROR_BASE | 0x186);

            //! The firmware image on your XNET C Series module is corrupted. Solution:
            //! Update the firmware of this C Series module in MAX.
            public const int nxErrBadcSeriesFpgaSignature = (NX_ERROR_BASE | 0x187);

            //! The firmware version of your XNET C Series module is not in sync with your
            //! host computer. Solution: Update the firmware of this C Series module in MAX.
            public const int nxErrBadcSeriesFpgaRevision = (NX_ERROR_BASE | 0x188);

            //! The firmware version of your XNET C Series module is not in sync with the
            //! NI-XNET software on your remote target. Solution: Update the NI-XNETsoftware
            //! on the remote target.
            public const int nxErrBadFpgaRevisionOnTarget = (NX_ERROR_BASE | 0x189);

            //! The terminal you are trying to use is already in use. Only one connection
            //! per terminal is allowed. Solution: disconnect the terminal that is already
            //! in use.
            public const int nxErrRouteInUse = (NX_ERROR_BASE | 0x18A);

            //! You need to install a supported version of NI-DAQmx for your XNET C Series
            //! module to work correctly with your Compact DAQ system. Solution: Check the
            //! NI-XNET readme file for supported versions of the NI-DAQmx driver software.
            public const int nxErrDAQmxIncorrectVersion = (NX_ERROR_BASE | 0x18B);

            //! The NI-DAQmx driver cannot create the requested route. Solution: Resolve
            //! routing conflicts or invalid terminal names.
            public const int nxErrAddRoute = (NX_ERROR_BASE | 0x18C);

            //! You attempted to transmit a go to sleep frame (by setting the LIN Sleep
            //! mode to Remote Sleep) on a LIN interface configured as slave.  In
            //! conformance with the LIN protocol standard, only an interface configured
            //! as master may transmit a go to sleep frame.
            public const int nxErrRemoteSleepOnLinSlave = (NX_ERROR_BASE | 0x18D);

            //! You attempted to set properties related to Sleep and Wakeup
            //! when the FlexRay cluster defined in the Fibex file does not support it.
            //! Solution: Edit the Fibex file used in your application to include all
            //! relevant cluster wakeup attributes.
            public const int nxErrSleepWakeupNotSupported = (NX_ERROR_BASE | 0x18E);

            //! The data payload written for a diagnostic frame for transmit does not
            //! conform to the LIN transport layer specification.  Solution: Ensure the
            //! data payload for a diagnostic frame conforms to the transport layer
            //! specification.
            public const int nxErrLINTransportLayer = (NX_ERROR_BASE | 0x192);

            //! An error occurred within the NI-XNET example code for logfile access (TDMS).
            //! Solution: For LabVIEW, the subVI with the error is shown as the source,
            //! and you can open that subVI to determine the cause of the problem.
            //! For other programming languages, review the source code for the logfile
            //! example to determine the cause of the problem.
            public const int nxErrLogfile = (NX_ERROR_BASE | 0x193);

            // Warning Section

            //! There is a warning from importing the database file. For details, refer to
            //! the import log file nixnetfx-log.txt or nixnetldf-log.txt under
            //! %ALLUSERSPROFILE%\\Application Data\\National Instruments\\NI-XNET. Please note
            //! that this location may be hidden on your computer.
            public const int nxWarnDatabaseImport = (NX_WARNING_BASE | 0x085);

            //! The database file has been imported, but it was not created by the XNET
            //! Editor or using the XNET API. Saving the database file with the XNET API or
            //! XNET Editor may lose information from the original file.
            public const int nxWarnDatabaseImportFIBEXNoXNETFile = (NX_WARNING_BASE | 0x086);

            //! The database file was not created by the XNET Editor or using the XNET API.
            //! Additionally, there is another warning. For details, refer to the import log
            //! file nixnetfx-log.txt under %ALLUSERSPROFILE%\\Application Data\\National
            //! Instruments\\NI-XNET.
            public const int nxWarnDatabaseImportFIBEXNoXNETFilePlusWarning = (NX_WARNING_BASE | 0x087);

            //! Close Database returns a warning instead of an error when an invalid
            //! reference is passed to the function.
            public const int nxWarnDatabaseBadReference = (NX_WARNING_BASE | 0x131);

            //! Your are retrieving signals from a frame that uses advanced PDU
            //! configuration. The signal start bit is given relative to the PDU, and it may
            //! be different than the start bit relative to the frame.
            public const int nxWarnAdvancedPDU = (NX_WARNING_BASE | 0x132);

            //! The multiplexer size exceeds 16 bit. This is not supported for Single Point
            //! sessions.
            public const int nxWarnMuxExceeds16Bit = (NX_WARNING_BASE | 0x133);


            /***********************************************************************
                                      P R O P E R T Y   I D S
            ***********************************************************************/

            // Class IDs used for encoding of property IDs (nxProp*)
            // Also class parameter of function nxdbCreateObject, nxdbDeleteObject, and nxdbFindObject
            public const uint nxClass_Database = 0x00000000;  //Database
            public const uint nxClass_Cluster = 0x00010000;   //Cluster
            public const uint nxClass_Frame = 0x00020000;   //Frame
            public const uint nxClass_Signal = 0x00030000;   //Signal
            public const uint nxClass_Subframe = 0x00040000;   //Subframe
            public const uint nxClass_ECU = 0x00050000;   //ECU
            public const uint nxClass_LINSched = 0x00060000;   //LIN Schedule
            public const uint nxClass_LINSchedEntry = 0x00070000;   //LIN Schedule Entry
            public const uint nxClass_PDU = 0x00080000;   //PDU
            public const uint nxClass_Session = 0x00100000;   //Session
            public const uint nxClass_System = 0x00110000;   //System
            public const uint nxClass_Device = 0x00120000;   //Device
            public const uint nxClass_Interface = 0x00130000;   //Interface

            public const uint nxClass_Mask = 0x00FF0000;   //mask for object class

            // Datatype IDs used in encoding of property IDs (nxProp*)
            public const uint nxPrptype_uint = 0x00000000;
            public const uint nxPrptype_f64 = 0x01000000;
            public const uint nxPrptype_bool = 0x02000000;   // use byte as datatype (semantic only)
            public const uint nxPrptype_string = 0x03000000;
            public const uint nxPrptype_1Dstring = 0x04000000;   // comma-separated list
            public const uint nxPrptype_ref = 0x05000000;   // uint reference (handle)
            public const uint nxPrptype_1Dref = 0x06000000;   // array of uint reference
            public const uint nxPrptype_time = 0x07000000;   // nxTimestamp_t
            public const uint nxPrptype_1Duint = 0x08000000;   // array of uint values
            public const uint nxPrptype_u64 = 0x09000000;
            public const uint nxPrptype_1Dbyte = 0x0A000000;   // array of byte values

            public const uint nxPrptype_Mask = 0xFF000000;   // mask for proptype
            /* PropertyId parameter of nxGetProperty, nxGetPropertySize, nxSetProperty functions. */

            // Session:Auto Start?
            public const uint nxPropSession_AutoStart = ((uint)0x00000001 | nxClass_Session | nxPrptype_bool);     //--rw
            // Session:ClusterName
            public const uint nxPropSession_ClusterName = ((uint)0x0000000A | nxClass_Session | nxPrptype_string);   //--r
            // Session:Database
            public const uint nxPropSession_DatabaseName = ((uint)0x00000002 | nxClass_Session | nxPrptype_string);   //--r
            // Session:List of Signals / List of Frames
            public const uint nxPropSession_List = ((uint)0x00000003 | nxClass_Session | nxPrptype_1Dstring); //--r
            // Session:Mode
            public const uint nxPropSession_Mode = ((uint)0x00000004 | nxClass_Session | nxPrptype_uint);      //--r
            // Session:Number of Frames
            public const uint nxPropSession_NumFrames = ((uint)0x0000000D | nxClass_Session | nxPrptype_uint);      //--r
            // Session:Number in List
            public const uint nxPropSession_NumInList = ((uint)0x00000005 | nxClass_Session | nxPrptype_uint);      //--r
            // Session:Number of Values Pending
            public const uint nxPropSession_NumPend = ((uint)0x00000006 | nxClass_Session | nxPrptype_uint);      //--r
            // Session:Number of Values Unused
            public const uint nxPropSession_NumUnused = ((uint)0x0000000B | nxClass_Session | nxPrptype_uint);      //--r
            // Session:Payload Length Maximum
            public const uint nxPropSession_PayldLenMax = ((uint)0x00000009 | nxClass_Session | nxPrptype_uint);      //--r
            // Session:Protocol
            public const uint nxPropSession_Protocol = ((uint)0x00000008 | nxClass_Session | nxPrptype_uint);      //--r
            // Session:Queue Size
            public const uint nxPropSession_QueueSize = ((uint)0x0000000C | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Resample Rate
            public const uint nxPropSession_ResampRate = ((uint)0x00000007 | nxClass_Session | nxPrptype_f64);      //--rw
            // Session:Interface:Baud Rate
            public const uint nxPropSession_IntfBaudRate = ((uint)0x00000016 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:Bus Error Frames to Input Stream?
            public const uint nxPropSession_IntfBusErrToInStrm = ((uint)0x00000015 | nxClass_Session | nxPrptype_bool);     //--rw
            // Session:Interface:Echo Transmit?
            public const uint nxPropSession_IntfEchoTx = ((uint)0x00000010 | nxClass_Session | nxPrptype_bool);     //--rw
            // Session:Interface:Name
            public const uint nxPropSession_IntfName = ((uint)0x00000013 | nxClass_Session | nxPrptype_string);   //--r
            // Session:Interface:Output Stream List
            public const uint nxPropSession_IntfOutStrmList = ((uint)0x00000011 | nxClass_Session | nxPrptype_1Dref);    //--rw
            // Session:Interface:Output Stream Timing
            public const uint nxPropSession_IntfOutStrmTimng = ((uint)0x00000012 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:Start Trigger Frames to Input Stream?
            public const uint nxPropSession_IntfStartTrigToInStrm = ((uint)0x00000014 | nxClass_Session | nxPrptype_bool);     //--rw
            // Session:Interface:CAN:External Transceiver Configuration
            public const uint nxPropSession_IntfCANExtTcvrConfig = ((uint)0x00000023 | nxClass_Session | nxPrptype_uint);      //--w
            // Session:Interface:CAN:Listen Only?
            public const uint nxPropSession_IntfCANLstnOnly = ((uint)0x00000022 | nxClass_Session | nxPrptype_bool);     //--rw
            // Session:Interface:CAN:Pending Transmit Order
            public const uint nxPropSession_IntfCANPendTxOrder = ((uint)0x00000020 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:CAN:Single Shot Transmit?
            public const uint nxPropSession_IntfCANSingShot = ((uint)0x00000024 | nxClass_Session | nxPrptype_bool);     //--rw
            // Session:Interface:CAN:Termination
            public const uint nxPropSession_IntfCANTerm = ((uint)0x00000025 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:CAN:Transceiver State
            public const uint nxPropSession_IntfCANTcvrState = ((uint)0x00000028 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:CAN:Transceiver Type
            public const uint nxPropSession_IntfCANTcvrType = ((uint)0x00000029 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:CAN:Output Stream List By ID
            public const uint nxPropSession_IntfCANOutStrmListById = ((uint)0x00000021 | nxClass_Session | nxPrptype_1Duint);    //--rw
            // Session:Interface:FlexRay:Accepted Startup Range
            public const uint nxPropSession_IntfFlexRayAccStartRng = ((uint)0x00000030 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Allow Halt Due To Clock?
            public const uint nxPropSession_IntfFlexRayAlwHltClk = ((uint)0x00000031 | nxClass_Session | nxPrptype_bool);     //--rw
            // Session:Interface:FlexRay:Allow Passive to Active
            public const uint nxPropSession_IntfFlexRayAlwPassAct = ((uint)0x00000032 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Auto Asleep When Stopped
            public const uint nxPropSession_IntfFlexRayAutoAslpWhnStp = ((uint)0x0000003A | nxClass_Session | nxPrptype_bool);     //--rw
            // Session:Interface:FlexRay:Cluster Drift Damping
            public const uint nxPropSession_IntfFlexRayClstDriftDmp = ((uint)0x00000033 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Coldstart?
            public const uint nxPropSession_IntfFlexRayColdstart = ((uint)0x00000034 | nxClass_Session | nxPrptype_bool);     //--r
            // Session:Interface:FlexRay:Decoding Correction
            public const uint nxPropSession_IntfFlexRayDecCorr = ((uint)0x00000035 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Delay Compensation Ch A
            public const uint nxPropSession_IntfFlexRayDelayCompA = ((uint)0x00000036 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Delay Compensation Ch B
            public const uint nxPropSession_IntfFlexRayDelayCompB = ((uint)0x00000037 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Key Slot Identifier
            public const uint nxPropSession_IntfFlexRayKeySlotID = ((uint)0x00000038 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Latest Tx
            public const uint nxPropSession_IntfFlexRayLatestTx = ((uint)0x00000041 | nxClass_Session | nxPrptype_uint);      //--r
            // Session:Interface:FlexRay:Listen Timeout
            public const uint nxPropSession_IntfFlexRayListTimo = ((uint)0x00000042 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Macro Initial Offset Ch A
            public const uint nxPropSession_IntfFlexRayMacInitOffA = ((uint)0x00000043 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Macro Initial Offset Ch B
            public const uint nxPropSession_IntfFlexRayMacInitOffB = ((uint)0x00000044 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Micro Initial Offset Ch A
            public const uint nxPropSession_IntfFlexRayMicInitOffA = ((uint)0x00000045 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Micro Initial Offset Ch B
            public const uint nxPropSession_IntfFlexRayMicInitOffB = ((uint)0x00000046 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Max Drift
            public const uint nxPropSession_IntfFlexRayMaxDrift = ((uint)0x00000047 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Microtick
            public const uint nxPropSession_IntfFlexRayMicrotick = ((uint)0x00000048 | nxClass_Session | nxPrptype_uint);      //--r
            // Session:Interface:FlexRay:Null Frames To Input Stream?
            public const uint nxPropSession_IntfFlexRayNullToInStrm = ((uint)0x00000049 | nxClass_Session | nxPrptype_bool);     //--rw
            // Session:Interface:FlexRay:Offset Correction
            public const uint nxPropSession_IntfFlexRayOffCorr = ((uint)0x00000058 | nxClass_Session | nxPrptype_uint);      //--r
            // Session:Interface:FlexRay:Offset Correction Out
            public const uint nxPropSession_IntfFlexRayOffCorrOut = ((uint)0x00000050 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Rate Correction
            public const uint nxPropSession_IntfFlexRayRateCorr = ((uint)0x00000059 | nxClass_Session | nxPrptype_uint);      //--r
            // Session:Interface:FlexRay:Rate Correction Out
            public const uint nxPropSession_IntfFlexRayRateCorrOut = ((uint)0x00000052 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Samples Per Microtick
            public const uint nxPropSession_IntfFlexRaySampPerMicro = ((uint)0x00000053 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Single Slot Enabled?
            public const uint nxPropSession_IntfFlexRaySingSlotEn = ((uint)0x00000054 | nxClass_Session | nxPrptype_bool);     //--rw
            // Session:Interface:FlexRay:Statistics Enabled?
            public const uint nxPropSession_IntfFlexRayStatisticsEn = ((uint)0x0000005A | nxClass_Session | nxPrptype_bool);     //--rw
            // Session:Interface:FlexRay:Symbol Frames To Input Stream?
            public const uint nxPropSession_IntfFlexRaySymToInStrm = ((uint)0x0000003D | nxClass_Session | nxPrptype_bool);     //--rw
            // Session:Interface:FlexRay:Sync on Ch A Even Cycle
            public const uint nxPropSession_IntfFlexRaySyncChAEven = ((uint)0x0000005B | nxClass_Session | nxPrptype_1Duint);    //--r
            // Session:Interface:FlexRay:Sync on Ch A Odd Cycle
            public const uint nxPropSession_IntfFlexRaySyncChAOdd = ((uint)0x0000005C | nxClass_Session | nxPrptype_1Duint);    //--r
            // Session:Interface:FlexRay:Sync on Ch B Even Cycle
            public const uint nxPropSession_IntfFlexRaySyncChBEven = ((uint)0x0000005D | nxClass_Session | nxPrptype_1Duint);    //--r
            // Session:Interface:FlexRay:Sync on Ch B Odd Cycle
            public const uint nxPropSession_IntfFlexRaySyncChBOdd = ((uint)0x0000005E | nxClass_Session | nxPrptype_1Duint);    //--r
            // Session:Interface:FlexRay:Sync Frame Status
            public const uint nxPropSession_IntfFlexRaySyncStatus = ((uint)0x0000005F | nxClass_Session | nxPrptype_uint);      //--r
            // Session:Interface:FlexRay:Termination
            public const uint nxPropSession_IntfFlexRayTerm = ((uint)0x00000057 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Wakeup Channel
            public const uint nxPropSession_IntfFlexRayWakeupCh = ((uint)0x00000055 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Wakeup Pattern
            public const uint nxPropSession_IntfFlexRayWakeupPtrn = ((uint)0x00000056 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:FlexRay:Sleep
            public const uint nxPropSession_IntfFlexRaySleep = ((uint)0x0000003B | nxClass_Session | nxPrptype_uint);      //--w
            // Session:Interface:FlexRay:Connected Channels
            public const uint nxPropSession_IntfFlexRayConnectedChs = ((uint)0x0000003C | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:LIN:Break Length
            public const uint nxPropSession_IntfLINBreakLength = ((uint)0x00000070 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:LIN:Master?
            public const uint nxPropSession_IntfLINMaster = ((uint)0x00000072 | nxClass_Session | nxPrptype_bool);     //--rw
            // Session:Interface:LIN:Schedule Names
            public const uint nxPropSession_IntfLINSchedNames = ((uint)0x00000075 | nxClass_Session | nxPrptype_1Dstring); //--r
            // Session:Interface:LIN:Sleep
            public const uint nxPropSession_IntfLINSleep = ((uint)0x00000073 | nxClass_Session | nxPrptype_uint);      //--w
            // Session:Interface:LIN:Termination
            public const uint nxPropSession_IntfLINTerm = ((uint)0x00000074 | nxClass_Session | nxPrptype_uint);      //--rw
            // Session:Interface:LIN:Diagnostics P2min
            public const uint nxPropSession_IntfLINDiagP2min = ((uint)0x00000077 | nxClass_Session | nxPrptype_f64);      //--rw
            // Session:Interface:LIN:Diagnostics STmin
            public const uint nxPropSession_IntfLINDiagSTmin = ((uint)0x00000076 | nxClass_Session | nxPrptype_f64);      //--rw
            // Session:Interface:Source Terminal:Start Trigger
            public const uint nxPropSession_IntfSrcTermStartTrigger = ((uint)0x00000090 | nxClass_Session | nxPrptype_string);   //--rw
            // System:Devices
            public const uint nxPropSys_DevRefs = ((uint)0x00000002 | nxClass_System | nxPrptype_1Dref);     //--r
            // System:Interfaces (All)
            public const uint nxPropSys_IntfRefs = ((uint)0x00000003 | nxClass_System | nxPrptype_1Dref);     //--r
            // System:Interfaces (CAN)
            public const uint nxPropSys_IntfRefsCAN = ((uint)0x00000004 | nxClass_System | nxPrptype_1Dref);     //--r
            // System:Interfaces (FlexRay)
            public const uint nxPropSys_IntfRefsFlexRay = ((uint)0x00000005 | nxClass_System | nxPrptype_1Dref);     //--r
            // System:Interfaces (LIN)
            public const uint nxPropSys_IntfRefsLIN = ((uint)0x00000007 | nxClass_System | nxPrptype_1Dref);     //--r
            // System:Version:Build
            public const uint nxPropSys_VerBuild = ((uint)0x00000006 | nxClass_System | nxPrptype_uint);       //--r
            // System:Version:Major
            public const uint nxPropSys_VerMajor = ((uint)0x00000008 | nxClass_System | nxPrptype_uint);       //--r
            // System:Version:Minor
            public const uint nxPropSys_VerMinor = ((uint)0x00000009 | nxClass_System | nxPrptype_uint);       //--r
            // System:Version:Phase
            public const uint nxPropSys_VerPhase = ((uint)0x0000000A | nxClass_System | nxPrptype_uint);       //--r
            // System:Version:Update
            public const uint nxPropSys_VerUpdate = ((uint)0x0000000B | nxClass_System | nxPrptype_uint);       //--r
            // System:CompactDAQ Packet Time
            public const uint nxPropSys_CDAQPktTime = ((uint)0x0000000C | nxClass_System | nxPrptype_f64);       //--rw
            // Device:Form Factor
            public const uint nxPropDev_FormFac = ((uint)0x00000001 | nxClass_Device | nxPrptype_uint);       //--r
            // Device:Interfaces
            public const uint nxPropDev_IntfRefs = ((uint)0x00000002 | nxClass_Device | nxPrptype_1Dref);     //--r
            // Device:Name
            public const uint nxPropDev_Name = ((uint)0x00000003 | nxClass_Device | nxPrptype_string);    //--r
            // Device:Number of Ports
            public const uint nxPropDev_NumPorts = ((uint)0x00000004 | nxClass_Device | nxPrptype_uint);       //--r
            // Device:Product Number
            public const uint nxPropDev_ProductNum = ((uint)0x00000008 | nxClass_Device | nxPrptype_uint);       //--r
            // Device:Serial Number
            public const uint nxPropDev_SerNum = ((uint)0x00000005 | nxClass_Device | nxPrptype_uint);       //--r
            // Device:Slot Number
            public const uint nxPropDev_SlotNum = ((uint)0x00000006 | nxClass_Device | nxPrptype_uint);       //--r
            // Interface:Device
            public const uint nxPropIntf_DevRef = ((uint)0x00000001 | nxClass_Interface | nxPrptype_ref);    //--r
            // Interface:Name
            public const uint nxPropIntf_Name = ((uint)0x00000002 | nxClass_Interface | nxPrptype_string); //--r
            // Interface:Number
            public const uint nxPropIntf_Num = ((uint)0x00000003 | nxClass_Interface | nxPrptype_uint);    //--r
            // Interface:Port Number
            public const uint nxPropIntf_PortNum = ((uint)0x00000004 | nxClass_Interface | nxPrptype_uint);    //--r
            // Interface:Protocol
            public const uint nxPropIntf_Protocol = ((uint)0x00000005 | nxClass_Interface | nxPrptype_uint);    //--r
            // Interface:CAN:Termination Capability
            public const uint nxPropIntf_CANTermCap = ((uint)0x00000008 | nxClass_Interface | nxPrptype_uint);    //--r
            // Interface:CAN:Transceiver Capability
            public const uint nxPropIntf_CANTcvrCap = ((uint)0x00000007 | nxClass_Interface | nxPrptype_uint);    //--r


            /* PropertyId parameter of nxGetSubProperty, nxGetSubPropertySize, nxSetSubProperty functions. */

            // Session:Frame:CAN:Start Time Offset
            public const uint nxPropSessionSub_CANStartTimeOff = ((uint)0x00000081 | nxClass_Session | nxPrptype_f64);      //--w
            // Session:Frame:CAN:Transmit Time
            public const uint nxPropSessionSub_CANTxTime = ((uint)0x00000082 | nxClass_Session | nxPrptype_f64);      //--w
            // Session:Frame:CAN:Skip N Cyclic Frames
            public const uint nxPropSessionSub_SkipNCyclicFrames = ((uint)0x00000083 | nxClass_Session | nxPrptype_uint);      //--w


            /* PropertyId parameter of nxdbGetProperty, nxdbGetPropertySize, nxdbSetProperty functions. */

            // Database:Name
            public const uint nxPropDatabase_Name = ((uint)0x00000001 | nxClass_Database | nxPrptype_string);  //--r
            // Database:Clusters
            public const uint nxPropDatabase_ClstRefs = ((uint)0x00000002 | nxClass_Database | nxPrptype_1Dref);   //--r
            // Database:Show Invalid Frames and Signals
            public const uint nxPropDatabase_ShowInvalidFromOpen = ((uint)0x00000003 | nxClass_Database | nxPrptype_bool);    //--rw
            // Cluster:Baud Rate
            public const uint nxPropClst_BaudRate = ((uint)0x00000001 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:Comment
            public const uint nxPropClst_Comment = ((uint)0x00000008 | nxClass_Cluster | nxPrptype_string);   //--rw
            // Cluster:Configuration Status
            public const uint nxPropClst_ConfigStatus = ((uint)0x00000009 | nxClass_Cluster | nxPrptype_uint);      //--r
            // Cluster:Database
            public const uint nxPropClst_DatabaseRef = ((uint)0x00000002 | nxClass_Cluster | nxPrptype_ref);      //--r
            // Cluster:ECUs
            public const uint nxPropClst_ECURefs = ((uint)0x00000003 | nxClass_Cluster | nxPrptype_1Dref);    //--r
            // Cluster:Frames
            public const uint nxPropClst_FrmRefs = ((uint)0x00000004 | nxClass_Cluster | nxPrptype_1Dref);    //--r
            // Cluster:Name (Short)
            public const uint nxPropClst_Name = ((uint)0x00000005 | nxClass_Cluster | nxPrptype_string);   //--rw
            // Cluster:PDUs
            public const uint nxPropClst_PDURefs = ((uint)0x00000008 | nxClass_Cluster | nxPrptype_1Dref);    //--r
            // Cluster:PDUs Required?
            public const uint nxPropClst_PDUsReqd = ((uint)0x0000000A | nxClass_Cluster | nxPrptype_bool);     //--r
            // Cluster:Protocol
            public const uint nxPropClst_Protocol = ((uint)0x00000006 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:Signals
            public const uint nxPropClst_SigRefs = ((uint)0x00000007 | nxClass_Cluster | nxPrptype_1Dref);    //--r
            // Cluster:FlexRay:Action Point Offset
            public const uint nxPropClst_FlexRayActPtOff = ((uint)0x00000020 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:CAS Rx Low Max
            public const uint nxPropClst_FlexRayCASRxLMax = ((uint)0x00000021 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Channels
            public const uint nxPropClst_FlexRayChannels = ((uint)0x00000022 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Cluster Drift Damping
            public const uint nxPropClst_FlexRayClstDriftDmp = ((uint)0x00000023 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Cold Start Attempts
            public const uint nxPropClst_FlexRayColdStAts = ((uint)0x00000024 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Cycle
            public const uint nxPropClst_FlexRayCycle = ((uint)0x00000025 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Dynamic Segment Start
            public const uint nxPropClst_FlexRayDynSegStart = ((uint)0x00000026 | nxClass_Cluster | nxPrptype_uint);      //--r
            // Cluster:FlexRay:Dynamic Slot Idle Phase
            public const uint nxPropClst_FlexRayDynSlotIdlPh = ((uint)0x00000027 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Latest Usable Dynamic Slot
            public const uint nxPropClst_FlexRayLatestUsableDyn = ((uint)0x0000002A | nxClass_Cluster | nxPrptype_uint);      //--r
            // Cluster:FlexRay:Latest Guaranteed Dynamic Slot
            public const uint nxPropClst_FlexRayLatestGuarDyn = ((uint)0x0000002B | nxClass_Cluster | nxPrptype_uint);      //--r
            // Cluster:FlexRay:Listen Noise
            public const uint nxPropClst_FlexRayLisNoise = ((uint)0x00000028 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Macro Per Cycle
            public const uint nxPropClst_FlexRayMacroPerCycle = ((uint)0x00000029 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Macrotick
            public const uint nxPropClst_FlexRayMacrotick = ((uint)0x00000030 | nxClass_Cluster | nxPrptype_f64);      //--r
            // Cluster:FlexRay:Max Without Clock Correction Fatal
            public const uint nxPropClst_FlexRayMaxWoClkCorFat = ((uint)0x00000031 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Max Without Clock Correction Passive
            public const uint nxPropClst_FlexRayMaxWoClkCorPas = ((uint)0x00000032 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Minislot Action Point Offset
            public const uint nxPropClst_FlexRayMinislotActPt = ((uint)0x00000033 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Minislot
            public const uint nxPropClst_FlexRayMinislot = ((uint)0x00000034 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Network Management Vector Length
            public const uint nxPropClst_FlexRayNMVecLen = ((uint)0x00000035 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:NIT
            public const uint nxPropClst_FlexRayNIT = ((uint)0x00000036 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:NIT Start
            public const uint nxPropClst_FlexRayNITStart = ((uint)0x00000037 | nxClass_Cluster | nxPrptype_uint);      //--r
            // Cluster:FlexRay:Number Of Minislots
            public const uint nxPropClst_FlexRayNumMinislt = ((uint)0x00000038 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Number Of Static Slots
            public const uint nxPropClst_FlexRayNumStatSlt = ((uint)0x00000039 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Offset Correction Start
            public const uint nxPropClst_FlexRayOffCorSt = ((uint)0x00000040 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Payload Length Dynamic Maximum
            public const uint nxPropClst_FlexRayPayldLenDynMax = ((uint)0x00000041 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Payload Length Maximum
            public const uint nxPropClst_FlexRayPayldLenMax = ((uint)0x00000042 | nxClass_Cluster | nxPrptype_uint);      //--r
            // Cluster:FlexRay:Payload Length Static
            public const uint nxPropClst_FlexRayPayldLenSt = ((uint)0x00000043 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Static Slot
            public const uint nxPropClst_FlexRayStatSlot = ((uint)0x00000045 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Symbol Window
            public const uint nxPropClst_FlexRaySymWin = ((uint)0x00000046 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Symbol Window Start
            public const uint nxPropClst_FlexRaySymWinStart = ((uint)0x00000047 | nxClass_Cluster | nxPrptype_uint);      //--r
            // Cluster:FlexRay:Sync Node Max
            public const uint nxPropClst_FlexRaySyncNodeMax = ((uint)0x00000048 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:TSS Transmitter
            public const uint nxPropClst_FlexRayTSSTx = ((uint)0x00000049 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Wakeup Symbol Rx Idle
            public const uint nxPropClst_FlexRayWakeSymRxIdl = ((uint)0x00000050 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Wakeup Symbol Rx Low
            public const uint nxPropClst_FlexRayWakeSymRxLow = ((uint)0x00000051 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Wakeup Symbol Rx Window
            public const uint nxPropClst_FlexRayWakeSymRxWin = ((uint)0x00000052 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Wakeup Symbol Tx Idle
            public const uint nxPropClst_FlexRayWakeSymTxIdl = ((uint)0x00000053 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Wakeup Symbol Tx Low
            public const uint nxPropClst_FlexRayWakeSymTxLow = ((uint)0x00000054 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Cluster:FlexRay:Use Wakeup
            public const uint nxPropClst_FlexRayUseWakeup = ((uint)0x00000055 | nxClass_Cluster | nxPrptype_bool);     //--rw
            // Cluster:LIN:Schedules
            public const uint nxPropClst_LINSchedules = ((uint)0x00000070 | nxClass_Cluster | nxPrptype_1Dref);    //--r
            // Cluster:LIN:Tick
            public const uint nxPropClst_LINTick = ((uint)0x00000071 | nxClass_Cluster | nxPrptype_f64);      //--rw
            // Cluster:FlexRay:Allow Passive to Active
            public const uint nxPropClst_FlexRayAlwPassAct = ((uint)0x00000072 | nxClass_Cluster | nxPrptype_uint);      //--rw
            // Frame:Cluster
            public const uint nxPropFrm_ClusterRef = ((uint)0x00000001 | nxClass_Frame | nxPrptype_ref);        //--r
            // Frame:Comment
            public const uint nxPropFrm_Comment = ((uint)0x00000002 | nxClass_Frame | nxPrptype_string);     //--rw
            // Frame:Configuration Status
            public const uint nxPropFrm_ConfigStatus = ((uint)0x00000009 | nxClass_Frame | nxPrptype_uint);        //--r
            // Frame:Default Payload
            public const uint nxPropFrm_DefaultPayload = ((uint)0x00000005 | nxClass_Frame | nxPrptype_1Dbyte);       //--rw
            // Frame:Identifier (Slot)
            public const uint nxPropFrm_ID = ((uint)0x00000003 | nxClass_Frame | nxPrptype_uint);        //--rw
            // Frame:Name (Short)
            public const uint nxPropFrm_Name = ((uint)0x00000004 | nxClass_Frame | nxPrptype_string);     //--rw
            // Frame:Payload Length (in bytes)
            public const uint nxPropFrm_PayloadLen = ((uint)0x00000007 | nxClass_Frame | nxPrptype_uint);        //--rw
            // Frame:Signals
            public const uint nxPropFrm_SigRefs = ((uint)0x00000008 | nxClass_Frame | nxPrptype_1Dref);      //--r
            // Frame:CAN:Extended Identifier?
            public const uint nxPropFrm_CANExtID = ((uint)0x00000010 | nxClass_Frame | nxPrptype_bool);       //--rw
            // Frame:CAN:Timing Type
            public const uint nxPropFrm_CANTimingType = ((uint)0x00000011 | nxClass_Frame | nxPrptype_uint);        //--rw
            // Frame:CAN:Transmit Time
            public const uint nxPropFrm_CANTxTime = ((uint)0x00000012 | nxClass_Frame | nxPrptype_f64);        //--rw
            // Frame:FlexRay:Base Cycle
            public const uint nxPropFrm_FlexRayBaseCycle = ((uint)0x00000020 | nxClass_Frame | nxPrptype_uint);        //--rw
            // Frame:FlexRay:Channel Assignment
            public const uint nxPropFrm_FlexRayChAssign = ((uint)0x00000021 | nxClass_Frame | nxPrptype_uint);        //--rw
            // Frame:FlexRay:Cycle Repetition
            public const uint nxPropFrm_FlexRayCycleRep = ((uint)0x00000022 | nxClass_Frame | nxPrptype_uint);        //--rw
            // Frame:FlexRay:Payload Preamble?
            public const uint nxPropFrm_FlexRayPreamble = ((uint)0x00000023 | nxClass_Frame | nxPrptype_bool);       //--rw
            // Frame:FlexRay:Startup?
            public const uint nxPropFrm_FlexRayStartup = ((uint)0x00000024 | nxClass_Frame | nxPrptype_bool);       //--rw
            // Frame:FlexRay:Sync?
            public const uint nxPropFrm_FlexRaySync = ((uint)0x00000025 | nxClass_Frame | nxPrptype_bool);       //--rw
            // Frame:FlexRay:Timing Type
            public const uint nxPropFrm_FlexRayTimingType = ((uint)0x00000026 | nxClass_Frame | nxPrptype_uint);        //--rw
            // Frame:FlexRay:In Cycle Repetitions:Enabled?
            public const uint nxPropFrm_FlexRayInCycRepEnabled = ((uint)0x00000030 | nxClass_Frame | nxPrptype_bool);       //--r
            // Frame:FlexRay:In Cycle Repetitions:Identifiers
            public const uint nxPropFrm_FlexRayInCycRepIDs = ((uint)0x00000031 | nxClass_Frame | nxPrptype_1Duint);      //--rw
            // Frame:FlexRay:In Cycle Repetitions:Channel Assignments
            public const uint nxPropFrm_FlexRayInCycRepChAssigns = ((uint)0x00000032 | nxClass_Frame | nxPrptype_1Duint);      //--rw
            // Frame:LIN:Checksum
            public const uint nxPropFrm_LINChecksum = ((uint)0x00000050 | nxClass_Frame | nxPrptype_uint);        //--r
            // Frame:Mux:Is Data Multiplexed?
            public const uint nxPropFrm_MuxIsMuxed = ((uint)0x00000040 | nxClass_Frame | nxPrptype_bool);       //--r
            // Frame:Mux:Data Multiplexer Signal
            public const uint nxPropFrm_MuxDataMuxSigRef = ((uint)0x00000041 | nxClass_Frame | nxPrptype_ref);        //--r
            // Frame:Mux:Static Signals
            public const uint nxPropFrm_MuxStaticSigRefs = ((uint)0x00000042 | nxClass_Frame | nxPrptype_1Dref);      //--r
            // Frame:Mux:Subframes
            public const uint nxPropFrm_MuxSubframeRefs = ((uint)0x00000043 | nxClass_Frame | nxPrptype_1Dref);      //--r
            // Frame: PDUs
            public const uint nxPropFrm_PDURefs = ((uint)0x00000060 | nxClass_Frame | nxPrptype_1Dref);      //--rw
            // Frame: PDU Start Bits
            public const uint nxPropFrm_PDUStartBits = ((uint)0x00000061 | nxClass_Frame | nxPrptype_1Duint);      //--rw
            // Frame: PDU Update Bits
            public const uint nxPropFrm_PDUUpdateBits = ((uint)0x00000063 | nxClass_Frame | nxPrptype_1Duint);      //--rw
            // PDU: Cluster
            public const uint nxPropPDU_ClusterRef = ((uint)0x00000004 | nxClass_PDU | nxPrptype_ref);          //--r
            // PDU: Comment
            public const uint nxPropPDU_Comment = ((uint)0x00000002 | nxClass_PDU | nxPrptype_string);       //--rw
            // PDU:Configuration Status
            public const uint nxPropPDU_ConfigStatus = ((uint)0x00000007 | nxClass_PDU | nxPrptype_uint);          //--r
            // PDU:Frames
            public const uint nxPropPDU_FrmRefs = ((uint)0x00000006 | nxClass_PDU | nxPrptype_1Dref);        //--r
            // PDU: Name (Short)
            public const uint nxPropPDU_Name = ((uint)0x00000001 | nxClass_PDU | nxPrptype_string);       //--rw
            // PDU: Payload Length (in bytes)
            public const uint nxPropPDU_PayloadLen = ((uint)0x00000003 | nxClass_PDU | nxPrptype_uint);          //--rw
            // PDU:Signals
            public const uint nxPropPDU_SigRefs = ((uint)0x00000005 | nxClass_PDU | nxPrptype_1Dref);        //--r
            // PDU:Mux:Is Data Multiplexed?
            public const uint nxPropPDU_MuxIsMuxed = ((uint)0x00000008 | nxClass_PDU | nxPrptype_bool);         //--r
            // PDU:Mux:Data Multiplexer Signal
            public const uint nxPropPDU_MuxDataMuxSigRef = ((uint)0x00000009 | nxClass_PDU | nxPrptype_ref);          //--r
            // PDU:Mux:Static Signals
            public const uint nxPropPDU_MuxStaticSigRefs = ((uint)0x0000000A | nxClass_PDU | nxPrptype_1Dref);        //--r
            // PDU:Mux:Subframes
            public const uint nxPropPDU_MuxSubframeRefs = ((uint)0x0000000B | nxClass_PDU | nxPrptype_1Dref);        //--r
            // Signal:Byte Order
            public const uint nxPropSig_ByteOrdr = ((uint)0x00000001 | nxClass_Signal | nxPrptype_uint);       //--rw
            // Signal:Comment
            public const uint nxPropSig_Comment = ((uint)0x00000002 | nxClass_Signal | nxPrptype_string);    //--rw
            // Signal:Configuration Status
            public const uint nxPropSig_ConfigStatus = ((uint)0x00000009 | nxClass_Signal | nxPrptype_uint);       //--r
            // Signal:Data Type
            public const uint nxPropSig_DataType = ((uint)0x00000003 | nxClass_Signal | nxPrptype_uint);       //--rw
            // Signal:Default Value
            public const uint nxPropSig_Default = ((uint)0x00000004 | nxClass_Signal | nxPrptype_f64);       //--rw
            // Signal:Frame
            public const uint nxPropSig_FrameRef = ((uint)0x00000005 | nxClass_Signal | nxPrptype_ref);      //--r
            // Signal:Maximum Value
            public const uint nxPropSig_Max = ((uint)0x00000006 | nxClass_Signal | nxPrptype_f64);       //--rw
            // Signal:Minimum Value
            public const uint nxPropSig_Min = ((uint)0x00000007 | nxClass_Signal | nxPrptype_f64);       //--rw
            // Signal:Name (Short)
            public const uint nxPropSig_Name = ((uint)0x00000008 | nxClass_Signal | nxPrptype_string);    //--rw
            // Signal:Name (Unique to Cluster)
            public const uint nxPropSig_NameUniqueToCluster = ((uint)0x00000010 | nxClass_Signal | nxPrptype_string);    //--r
            // Signal:Number of Bits
            public const uint nxPropSig_NumBits = ((uint)0x00000012 | nxClass_Signal | nxPrptype_uint);       //--rw
            // Signal:PDU
            public const uint nxPropSig_PDURef = ((uint)0x00000011 | nxClass_Signal | nxPrptype_ref);      //--r
            // Signal:Scaling Factor
            public const uint nxPropSig_ScaleFac = ((uint)0x00000013 | nxClass_Signal | nxPrptype_f64);       //--rw
            // Signal:Scaling Offset
            public const uint nxPropSig_ScaleOff = ((uint)0x00000014 | nxClass_Signal | nxPrptype_f64);       //--rw
            // Signal:Start Bit
            public const uint nxPropSig_StartBit = ((uint)0x00000015 | nxClass_Signal | nxPrptype_uint);       //--rw
            // Signal:Unit
            public const uint nxPropSig_Unit = ((uint)0x00000016 | nxClass_Signal | nxPrptype_string);    //--rw
            // Signal:Mux:Data Multiplexer?
            public const uint nxPropSig_MuxIsDataMux = ((uint)0x00000030 | nxClass_Signal | nxPrptype_bool);      //--rw
            // Signal:Mux:Dynamic?
            public const uint nxPropSig_MuxIsDynamic = ((uint)0x00000031 | nxClass_Signal | nxPrptype_bool);      //--r
            // Signal:Mux:Multiplexer Value
            public const uint nxPropSig_MuxValue = ((uint)0x00000032 | nxClass_Signal | nxPrptype_uint);       //--r
            // Signal:Mux:Subframe
            public const uint nxPropSig_MuxSubfrmRef = ((uint)0x00000033 | nxClass_Signal | nxPrptype_ref);       //--r
            // Subframe:Configuration Status
            public const uint nxPropSubfrm_ConfigStatus = ((uint)0x00000009 | nxClass_Subframe | nxPrptype_uint);     //--r
            // Subframe:Dynamic Signals
            public const uint nxPropSubfrm_DynSigRefs = ((uint)0x00000001 | nxClass_Subframe | nxPrptype_1Dref);   //--r  
            // Subframe:"Frame"
            public const uint nxPropSubfrm_FrmRef = ((uint)0x00000002 | nxClass_Subframe | nxPrptype_ref);     //--r
            // Subframe:Multiplexer Value
            public const uint nxPropSubfrm_MuxValue = ((uint)0x00000003 | nxClass_Subframe | nxPrptype_uint);     //--rw
            // Subframe:Name (Short)
            public const uint nxPropSubfrm_Name = ((uint)0x00000004 | nxClass_Subframe | nxPrptype_string);  //--rw
            // Subframe:PDU
            public const uint nxPropSubfrm_PDURef = ((uint)0x00000005 | nxClass_Subframe | nxPrptype_ref);     //--r
            // Subframe:Name (Unique to Cluster)
            public const uint nxPropSubfrm_NameUniqueToCluster = ((uint)0x00000007 | nxClass_Subframe | nxPrptype_string);  //--r
            // ECU:Cluster
            public const uint nxPropECU_ClstRef = ((uint)0x00000001 | nxClass_ECU | nxPrptype_ref);          //--r
            // ECU:Comment
            public const uint nxPropECU_Comment = ((uint)0x00000005 | nxClass_ECU | nxPrptype_string);       //--rw
            // ECU:Configuration Status
            public const uint nxPropECU_ConfigStatus = ((uint)0x00000009 | nxClass_ECU | nxPrptype_uint);          //--r
            // ECU:Name (Short)
            public const uint nxPropECU_Name = ((uint)0x00000002 | nxClass_ECU | nxPrptype_string);       //--rw
            // ECU:Frames Received
            public const uint nxPropECU_RxFrmRefs = ((uint)0x00000003 | nxClass_ECU | nxPrptype_1Dref);        //--rw
            // ECU:Frames Transmitted
            public const uint nxPropECU_TxFrmRefs = ((uint)0x00000004 | nxClass_ECU | nxPrptype_1Dref);        //--rw
            // ECU:FlexRay:Coldstart?
            public const uint nxPropECU_FlexRayIsColdstart = ((uint)0x00000010 | nxClass_ECU | nxPrptype_bool);         //--r
            // ECU:FlexRay:Startup Frame
            public const uint nxPropECU_FlexRayStartupFrameRef = ((uint)0x00000011 | nxClass_ECU | nxPrptype_ref);          //--r
            // ECU:FlexRay:Wakeup Pattern
            public const uint nxPropECU_FlexRayWakeupPtrn = ((uint)0x00000012 | nxClass_ECU | nxPrptype_uint);          //--rw
            // ECU:FlexRay:Wakeup Channels
            public const uint nxPropECU_FlexRayWakeupChs = ((uint)0x00000013 | nxClass_ECU | nxPrptype_uint);          //--rw
            // ECU:FlexRay:Connected Channels
            public const uint nxPropECU_FlexRayConnectedChs = ((uint)0x00000014 | nxClass_ECU | nxPrptype_uint);          //--rw
            // ECU:LIN:Master?
            public const uint nxPropECU_LINMaster = ((uint)0x00000020 | nxClass_ECU | nxPrptype_bool);         //--rw
            // ECU:LIN:Protocol Version
            public const uint nxPropECU_LINProtocolVer = ((uint)0x00000021 | nxClass_ECU | nxPrptype_uint);          //--rw
            // ECU:LIN:Initial NAD
            public const uint nxPropECU_LINInitialNAD = ((uint)0x00000022 | nxClass_ECU | nxPrptype_uint);          //--rw
            // ECU:LIN:Configured NAD
            public const uint nxPropECU_LINConfigNAD = ((uint)0x00000023 | nxClass_ECU | nxPrptype_uint);          //--rw
            // ECU:LIN:Supplier ID
            public const uint nxPropECU_LINSupplierID = ((uint)0x00000024 | nxClass_ECU | nxPrptype_uint);          //--rw
            // ECU:LIN:Function ID
            public const uint nxPropECU_LINFunctionID = ((uint)0x00000025 | nxClass_ECU | nxPrptype_uint);          //--rw
            // ECU:LIN:P2 Min
            public const uint nxPropECU_LINP2min = ((uint)0x00000026 | nxClass_ECU | nxPrptype_f64);          //--rw
            // ECU:LIN:ST Min
            public const uint nxPropECU_LINSTmin = ((uint)0x00000027 | nxClass_ECU | nxPrptype_f64);          //--rw
            // LIN Schedule:Cluster
            public const uint nxPropLINSched_ClstRef = ((uint)0x00000005 | nxClass_LINSched | nxPrptype_ref);     //--r
            // LIN Schedule:Comment
            public const uint nxPropLINSched_Comment = ((uint)0x00000006 | nxClass_LINSched | nxPrptype_string);  //--rw
            // LIN Schedule:Configuration Status
            public const uint nxPropLINSched_ConfigStatus = ((uint)0x00000007 | nxClass_LINSched | nxPrptype_uint);     //--r
            // LIN Schedule:Entries
            public const uint nxPropLINSched_Entries = ((uint)0x00000001 | nxClass_LINSched | nxPrptype_1Dref);   //--r
            // LIN Schedule:Name
            public const uint nxPropLINSched_Name = ((uint)0x00000002 | nxClass_LINSched | nxPrptype_string);  //--rw
            // LIN Schedule:Priority
            public const uint nxPropLINSched_Priority = ((uint)0x00000003 | nxClass_LINSched | nxPrptype_uint);     //--rw
            // LIN Schedule:Run Mode
            public const uint nxPropLINSched_RunMode = ((uint)0x00000004 | nxClass_LINSched | nxPrptype_uint);     //--rw
            // LIN Schedule Entry:Collision Resolving Schedule
            public const uint nxPropLINSchedEntry_CollisionResSched = ((uint)0x00000001 | nxClass_LINSchedEntry | nxPrptype_ref); //--rw
            // LIN Schedule Entry:Delay
            public const uint nxPropLINSchedEntry_Delay = ((uint)0x00000002 | nxClass_LINSchedEntry | nxPrptype_f64); //--rw
            // LIN Schedule Entry:Event Identifier
            public const uint nxPropLINSchedEntry_EventID = ((uint)0x00000003 | nxClass_LINSchedEntry | nxPrptype_uint); //--rw
            // LIN Schedule Entry:Frames
            public const uint nxPropLINSchedEntry_Frames = ((uint)0x00000004 | nxClass_LINSchedEntry | nxPrptype_1Dref); //--rw
            // LIN Schedule Entry:Name
            public const uint nxPropLINSchedEntry_Name = ((uint)0x00000006 | nxClass_LINSchedEntry | nxPrptype_string);  //--rw
            // LIN Schedule Entry:Name (Unique to Cluster)
            public const uint nxPropLINSchedEntry_NameUniqueToCluster = ((uint)0x00000008 | nxClass_LINSchedEntry | nxPrptype_string);  //--r
            // LIN Schedule Entry:Schedule
            public const uint nxPropLINSchedEntry_Sched = ((uint)0x00000007 | nxClass_LINSchedEntry | nxPrptype_ref);     //--r
            // LIN Schedule Entry:Type
            public const uint nxPropLINSchedEntry_Type = ((uint)0x00000005 | nxClass_LINSchedEntry | nxPrptype_uint);     //--rw
            // LIN Schedule Entry:Node Configuration:Free Format:Data Bytes
            public const uint nxPropLINSchedEntry_NC_FF_DataBytes = ((uint)0x00000009 | nxClass_LINSchedEntry | nxPrptype_1Dbyte);    //--rw


            /***********************************************************************
               C O N S T A N T S   F O R   F U N C T I O N   P A R A M E T E R S
            ***********************************************************************/

            // Parameter Mode of function nxCreateSession
            public const int nxMode_SignalInSinglePoint = 0; // SignalInSinglePoint
            public const int nxMode_SignalInWaveform = 1;  // SignalInWaveform
            public const int nxMode_SignalInXY = 2;  // SignalInXY
            public const int nxMode_SignalOutSinglePoint = 3;  // SignalOutSinglePoint
            public const int nxMode_SignalOutWaveform = 4;  // SignalOutWaveform
            public const int nxMode_SignalOutXY = 5;  // SignalOutXY
            public const int nxMode_FrameInStream = 6;  // FrameInStream
            public const int nxMode_FrameInQueued = 7;  // FrameInQueued
            public const int nxMode_FrameInSinglePoint = 8;  // FrameInSinglePoint
            public const int nxMode_FrameOutStream = 9;  // FrameOutStream
            public const int nxMode_FrameOutQueued = 10; // FrameOutQueued
            public const int nxMode_FrameOutSinglePoint = 11; // FrameOutSinglePoint
            public const int nxMode_SignalConversionSinglePoint = 12; // SignalConversionSinglePoint

            // Parameter Scope of functions nxStart, nxStop
            public const int nxStartStop_Normal = 0;  // StartStop_Normal
            public const int nxStartStop_SessionOnly = 1;  // StartStop_SessionOnly
            public const int nxStartStop_InterfaceOnly = 2;  // StartStop_InterfaceOnly
            public const int nxStartStop_SessionOnlyBlocking = 3;  // StartStop_SessionOnlyBlocking

            // Parameter Modifier of nxBlink
            public const int nxBlink_Disable = 0;  // Blink_Disable
            public const int nxBlink_Enable = 1;  // Blink_Enable

            // Terminal names for nxConnectTerminals and nxDisconnectTerminals (source or destination)
            public const string nxTerm_PXI_Trig0 = "PXI_Trig0";             // PXI_Trig0 same as RTSI0
            public const string nxTerm_PXI_Trig1 = "PXI_Trig1";
            public const string nxTerm_PXI_Trig2 = "PXI_Trig2";
            public const string nxTerm_PXI_Trig3 = "PXI_Trig3";
            public const string nxTerm_PXI_Trig4 = "PXI_Trig4";
            public const string nxTerm_PXI_Trig5 = "PXI_Trig5";
            public const string nxTerm_PXI_Trig6 = "PXI_Trig6";
            public const string nxTerm_PXI_Trig7 = "PXI_Trig7";
            public const string nxTerm_FrontPanel0 = "FrontPanel0";
            public const string nxTerm_FrontPanel1 = "FrontPanel1";
            public const string nxTerm_PXI_Star = "PXI_Star";
            public const string nxTerm_PXI_Clk10 = "PXI_Clk10";
            public const string nxTerm_10MHzTimebase = "10MHzTimebase";
            public const string nxTerm_1MHzTimebase = "1MHzTimebase";
            public const string nxTerm_MasterTimebase = "MasterTimebase";
            public const string nxTerm_CommTrigger = "CommTrigger";
            public const string nxTerm_StartTrigger = "StartTrigger";
            public const string nxTerm_FlexRayStartCycle = "FlexRayStartCycle";
            public const string nxTerm_FlexRayMacrotick = "FlexRayMacrotick";
            public const string nxTerm_LogTrigger = "LogTrigger";

            /* StateID for nxReadState
            These constants use an encoding similar to property ID (nxProp_ prefix).
            */
            // Current time of the interface (using nxTimestamp_t)
            public const uint nxState_TimeCurrent = ((uint)0x00000001 | nxClass_Interface | nxPrptype_time);   // TimeCurrent
            // Time when communication began on the interface (protocol operational / integrated)
            public const uint nxState_TimeCommunicating = ((uint)0x00000002 | nxClass_Interface | nxPrptype_time);   // TimeCommunicating
            // Start time of the interface, when the attempt to communicate began (startup protocol)
            public const uint nxState_TimeStart = ((uint)0x00000003 | nxClass_Interface | nxPrptype_time);   // TimeStart
            // Session information: Use macros with prefix nxSessionInfo_Get_ to get fields of the uint
            public const uint nxState_SessionInfo = ((uint)0x00000004 | nxClass_Interface | nxPrptype_uint);    // SessionInfo
            // CAN communication: Use macros with prefix nxCANComm_Get_ to get fields of the uint
            public const uint nxState_CANComm = ((uint)0x00000010 | nxClass_Interface | nxPrptype_uint);    // CANComm
            // FlexRay communication: Use macros with prefix nxFlexRayComm_Get_ to get fields of the uint
            public const uint nxState_FlexRayComm = ((uint)0x00000020 | nxClass_Interface | nxPrptype_uint);    // FlexRayComm
            // FlexRay statistics: Use typedef nxFlexRayStats_t to read these statistics using a struct of multiple uint
            public const uint nxState_FlexRayStats = ((uint)0x00000021 | nxClass_Interface | nxPrptype_1Duint);  // FlexRayStats
            // LIN communication: Use macros with prefix nxLINComm_Get_ to get fields of 2 uint's
            public const uint nxState_LINComm = ((uint)0x00000030 | nxClass_Interface | nxPrptype_uint);    // LINComm

            /* StateID for nxWriteState
            These constants use an encoding similar to property ID (nxProp_ prefix).
            */
            public const uint nxState_LINScheduleChange = ((uint)0x00000081 | nxClass_Interface | nxPrptype_uint);    // LINScheduleChange
            public const uint nxState_LINDiagnosticScheduleChange = ((uint)0x00000083 | nxClass_Interface | nxPrptype_uint);    // LINDiagnosticScheduleChange
            public const uint nxState_FlexRaySymbol = ((uint)0x00000082 | nxClass_Interface | nxPrptype_uint);    // FlexRaySymbol


            // State of frames in the session, from nxState_SessionInfo (nxSessionInfo_Get_State)
            public const uint nxSessionInfoState_Stopped = 0;     // all frames stopped
            public const uint nxSessionInfoState_Started = 1;     // all frames started
            public const uint nxSessionInfoState_Mix = 2;     // one or more frames started, and one or more frames stopped

            // Communication state from nxState_CANComm (nxCANComm_Get_CommState)
            public const int nxCANCommState_ErrorActive = 0;
            public const int nxCANCommState_ErrorPassive = 1;
            public const int nxCANCommState_BusOff = 2;
            public const int nxCANCommState_Init = 3;

            // Last bus error from nxState_CANComm (nxCANComm_Get_LastErr)
            public const int nxCANLastErr_None = 0;
            public const int nxCANLastErr_Stuff = 1;
            public const int nxCANLastErr_Form = 2;
            public const int nxCANLastErr_Ack = 3;
            public const int nxCANLastErr_Bit1 = 4;
            public const int nxCANLastErr_Bit0 = 5;
            public const int nxCANLastErr_CRC = 6;

            // Macros to get fields of uint returned by nxReadState of nxState_FlexRayComm
            /* Get FlexRay Protocol Operation Control (POC) state,
            which uses constants with prefix nxFlexRayPOCState_ */
            public byte nxFlexRayComm_Get_POCState(uint StateValue)
            {
                return ((byte)((uint)StateValue & 0x0000000F));
            }
            /* From FlexRay spec 9.3.1.3.4: "the number of consecutive even/odd cycle pairs
        (vClockCorrectionFailed) that have passed without clock synchronization having performed an offset or a rate
        correction due to lack of synchronization frames (as maintained by the POC process)."
        This value is used for comparison to the cluster thresholds MaxWithoutClockCorrectFatal and
        MaxWithoutClockCorrectionPassive (XNET properties nxPropClst_FlexRayMaxWoClkCorFat
        and nxPropClst_FlexRayMaxWoClkCorPas). */
            public byte nxFlexRayComm_Get_ClockCorrFailed(uint StateValue)
            {
                return ((byte)(((uint)StateValue >> 4) & 0x0000000F));
            }
            /* From FlexRay spec 9.3.1.3.1: "the number of consecutive even/odd cycle pairs (vAllowPassiveToActive)
            that have passed with valid rate and offset correction terms, but the node still in POC:normal passive
            state due to a host configured delay to POC:normal active state (as maintained by the POC process).
            This value is used for comparison to the interface threshold AllowPassiveToActive
            (XNET property nxPropSession_IntfFlexRayAlwPassAct). */
            public byte nxFlexRayComm_Get_PassiveToActiveCount(uint StateValue)
            {
                return ((byte)(((uint)StateValue >> 8) & 0x0000001F));
            }
            public byte nxFlexRayComm_Get_ChannelASleep(uint StateValue)
            {
                return ((byte)(((uint)StateValue >> 13) & 0x00000001));
            }
            public byte nxFlexRayComm_Get_ChannelBSleep(uint StateValue)
            {
                return ((byte)(((uint)StateValue >> 14) & 0x00000001));
            }

            // POC state (Protocol Operation Control state) from nxFlexRayPOC_Get_State
            public const int nxFlexRayPOCState_DefaultConfig = 0;
            public const int nxFlexRayPOCState_Ready = 1;
            public const int nxFlexRayPOCState_NormalActive = 2;
            public const int nxFlexRayPOCState_NormalPassive = 3;
            public const int nxFlexRayPOCState_Halt = 4;
            public const int nxFlexRayPOCState_Monitor = 5;
            public const int nxFlexRayPOCState_Config = 15;

            // Macros to get fields of 1st uint returned by nxReadState of nxState_LINComm
            // Get indication of LIN interface sleep state; 1 = asleep, 0 = awake
            public byte nxLINComm_Get_Sleep(uint StateValue)
            {
                return ((byte)(((uint)StateValue >> 1) & 0x00000001));
            }
            // Get LIN communication state; uses constants with prefix nxLINCommState_
            public byte nxLINComm_Get_CommState(uint StateValue)
            {
                return ((byte)(((uint)StateValue >> 2) & 0x00000003));
            }
            // Get last bus error; this code uses constants with prefix nxLINLastErrCode_
            public byte nxLINComm_Get_LastErrCode(uint StateValue)
            {
                return ((byte)(((uint)StateValue >> 4) & 0x0000000F));
            }
            // Get received data for last bus error; this value applies only to specific codes
            public byte nxLINComm_Get_LastErrReceived(uint StateValue)
            {
                return ((byte)(((uint)StateValue >> 8) & 0x000000FF));
            }
            // Get expected data for last bus error; this value applies only to specific codes
            public byte nxLINComm_Get_LastErrExpected(uint StateValue)
            {
                return ((byte)(((uint)StateValue >> 16) & 0x000000FF));
            }
            // Get ID of last bus error; this value applies only to specific codes
            public byte nxLINComm_Get_LastErrID(uint StateValue)
            {
                return ((byte)(((uint)StateValue >> 24) & 0x0000003F));
            }
            // Get indication of LIN transceiver ready (powered); 1 = powered, 0 = not powered
            public byte nxLINComm_Get_TcvrRdy(uint StateValue)
            {
                return ((byte)(((uint)StateValue >> 31) & 0x00000001));
            }

            // Macros to get fields of 2nd uint returned by nxReadState of nxState_LINComm
            // Get index of the currently running schedule (0xFF if Null-schedule).
            public byte nxLINComm_Get2_ScheduleIndex(uint State2Value)
            {
                return ((byte)(((uint)State2Value) & 0x000000FF));
            }

            // Communication state from nxState_LINComm (nxLINComm_Get_CommState macro)
            public const int nxLINCommState_Idle = 0;
            public const int nxLINCommState_Active = 1;
            public const int nxLINCommState_Inactive = 2;

            // Diagnostic schedule state for nxState_LINDiagnosticScheduleChange
            public const int nxLINDiagnosticSchedule_NULL = 0x0000;
            public const int nxLINDiagnosticSchedule_MasterReq = 0x0001;
            public const int nxLINDiagnosticSchedule_SlaveResp = 0x0002;

            // Last error code from nxState_LINComm (nxLINComm_Get_LastErrCode macro)
            public const int nxLINLastErrCode_None = 0;
            public const int nxLINLastErrCode_UnknownId = 1;
            public const int nxLINLastErrCode_Form = 2;
            public const int nxLINLastErrCode_Framing = 3;
            public const int nxLINLastErrCode_Readback = 4;
            public const int nxLINLastErrCode_Timeout = 5;
            public const int nxLINLastErrCode_CRC = 6;

            // Condition of nxWait
            public const int nxCondition_TransmitComplete = 0x8001;  // TransmitComplete
            public const int nxCondition_IntfCommunicating = 0x8002;  // IntfCommunicating
            public const int nxCondition_IntfRemoteWakeup = 0x8003;  // IntfRemoteWakeup

            // Constants for use with Timeout parameter of read and write functions
            public const int nxTimeout_None = (0);
            public const int nxTimeout_Infinite = (-1);

            // Parameter Mode of function nxdbGetDBCAttribute and nxdbGetDBCAttributeSize
            public const int nxGetDBCMode_Attribute = 0;  // Attribute
            public const int nxGetDBCMode_EnumerationList = 1;  // Enumeration List
            public const int nxGetDBCMode_AttributeList = 2;  // List of available attributes of given type
            public const int nxGetDBCMode_ValueTableList = 3;  // Value table for a signal

            /***********************************************************************
               C O N S T A N T S   F O R   H A R D W A R E   P R O P E R T I E S
            ***********************************************************************/

            // System/Device/Interface properties (hardware info)

            // Property ID nxPropSys_VerPhase
            public const int nxPhase_Development = 0;
            public const int nxPhase_Alpha = 1;
            public const int nxPhase_Beta = 2;
            public const int nxPhase_Release = 3;

            // Property ID nxPropDev_FormFac
            public const int nxDevForm_PXI = 0;
            public const int nxDevForm_PCI = 1;
            public const int nxDevForm_cSeries = 2;

            // Property ID nxPropIntf_CANTermCap
            public const int nxCANTermCap_No = 0;
            public const int nxCANTermCap_Yes = 1;

            // Property ID nxPropIntf_CANTcvrCap
            public const int nxCANTcvrCap_HS = 0;
            public const int nxCANTcvrCap_LS = 1;
            public const int nxCANTcvrCap_XS = 3;

            // Property ID nxPropIntf_Protocol and nxPropClst_Protocol
            public const int nxProtocol_CAN = 0;
            public const int nxProtocol_FlexRay = 1;
            public const int nxProtocol_LIN = 2;

            /***********************************************************************
               C O N S T A N T S   F O R   S E S S I O N   P R O P E R T I E S
            ***********************************************************************/

            // Session properties (including runtime interface properties)

            // Macro to set nxPropSession_IntfBaudRate for an advanced CAN baud rate (bit timings)
            // If you pass a basic baud rate like 125000 or 500000, NI-XNET calculates bit timings for you
            public uint nxAdvCANBaudRate_Set(uint TimeQuantum, uint TimeSeg0, uint TimeSeg1, uint SyncJumpWidth)
            {
                return ((((uint)TimeQuantum) & 0x0000FFFF) | (((uint)TimeSeg0 << 16) & 0x000F0000) | (((uint)TimeSeg1 << 20) & 0x00700000) | (((uint)SyncJumpWidth << 24) & 0x03000000) | ((uint)0x80000000));
            }

            // Macros to get fields of nxPropSession_IntfBaudRate for an advanced CAN baud rate
            public ushort nxAdvCANBaudRate_Get_TimeQuantum(uint AdvBdRt)
            {
                return ((ushort)(((uint)AdvBdRt) & 0x0000FFFF));
            }
            public byte nxAdvCANBaudRate_Get_TimeSeg0(uint AdvBdRt)
            {
                return ((byte)(((uint)AdvBdRt >> 16) & 0x0000000F));
            }
            public byte nxAdvCANBaudRate_Get_TimeSeg1(uint AdvBdRt)
            {
                return ((byte)(((uint)AdvBdRt >> 20) & 0x00000007));
            }
            public byte nxAdvCANBaudRate_Get_SyncJumpWidth(uint AdvBdRt)
            {
                return ((byte)(((uint)AdvBdRt >> 24) & 0x00000003));
            }
            public byte nxAdvCANBaudRate_Get_NumSamples(uint AdvBdRt)
            {
                return ((byte)(((uint)AdvBdRt >> 26) & 0x00000001));
            }

            // Property ID nxPropSession_IntfCANTerm
            public const int nxCANTerm_Off = 0;
            public const int nxCANTerm_On = 1;

            // Property ID nxPropSession_IntfCANTcvrState
            public const int nxCANTcvrState_Normal = 0;
            public const int nxCANTcvrState_Sleep = 1;
            public const int nxCANTcvrState_SWWakeup = 2;
            public const int nxCANTcvrState_SWHighSpeed = 3;

            // Property ID nxPropSession_IntfCANTcvrType
            public const int nxCANTcvrType_HS = 0;
            public const int nxCANTcvrType_LS = 1;
            public const int nxCANTcvrType_SW = 2;
            public const int nxCANTcvrType_Ext = 3;
            public const int nxCANTcvrType_Disc = 4;

            // Property ID nxPropSession_IntfFlexRaySampPerMicro
            public const int nxFlexRaySampPerMicro_1 = 0;
            public const int nxFlexRaySampPerMicro_2 = 1;
            public const int nxFlexRaySampPerMicro_4 = 2;

            // Property ID nxPropSession_IntfFlexRayTerm
            public const int nxFlexRayTerm_Off = 0;
            public const int nxFlexRayTerm_On = 1;

            // Property ID nxPropSession_IntfLINSleep
            public const int nxLINSleep_RemoteSleep = 0;
            public const int nxLINSleep_RemoteWake = 1;
            public const int nxLINSleep_LocalSleep = 2;
            public const int nxLINSleep_LocalWake = 3;

            // Property ID nxPropSession_IntfLINTerm
            public const int nxLINTerm_Off = 0;
            public const int nxLINTerm_On = 1;

            // Property ID nxPropSession_IntfOutStrmTimng
            public const int nxOutStrmTimng_Immediate = 0;
            public const int nxOutStrmTimng_ReplayExclusive = 1;
            public const int nxOutStrmTimng_ReplayInclusive = 2;

            // Property ID nxPropSession_IntfCANPendTxOrder
            public const int nxCANPendTxOrder_AsSubmitted = 0;
            public const int nxCANPendTxOrder_ByIdentifier = 1;

            // Property ID nxPropSession_IntfFlexRaySleep
            public const int nxFlexRaySleep_LocalSleep = 0;
            public const int nxFlexRaySleep_LocalWake = 1;
            public const int nxFlexRaySleep_RemoteWake = 2;

            // Property ID nxPropSession_IntfCANExtTcvrConfig
            // These bits can be combined to define the capabilities of the connected
            // external transceiver.
            public const int nxCANExtTcvrConfig_NormalSupported = (1 << 2);
            public const int nxCANExtTcvrConfig_SleepSupported = (1 << 5);
            public const int nxCANExtTcvrConfig_SWWakeupSupported = (1 << 8);
            public const int nxCANExtTcvrConfig_SWHighSpeedSupported = (1 << 11);
            public const int nxCANExtTcvrConfig_PowerOnSupported = (1 << 14);
            public const int nxCANExtTcvrConfig_NormalOutput0Set = (1 << 0);
            public const int nxCANExtTcvrConfig_SleepOutput0Set = (1 << 3);
            public const int nxCANExtTcvrConfig_SWWakeupOutput0Set = (1 << 6);
            public const int nxCANExtTcvrConfig_SWHighSpeedOutput0Set = (1 << 9);
            public const int nxCANExtTcvrConfig_PowerOnOutput0Set = (1 << 12);
            public const int nxCANExtTcvrConfig_NormalOutput1Set = (1 << 1);
            public const int nxCANExtTcvrConfig_SleepOutput1Set = (1 << 4);
            public const int nxCANExtTcvrConfig_SWWakeupOutput1Set = (1 << 7);
            public const int nxCANExtTcvrConfig_SWHighSpeedOutput1Set = (1 << 10);
            public const int nxCANExtTcvrConfig_PowerOnOutput1Set = (1 << 13);
            public const int nxCANExtTcvrConfig_nErrConnected = (1 << 31);


            /***********************************************************************
               C O N S T A N T S   F O R   D A T A B A S E   P R O P E R T I E S
            ***********************************************************************/

            // Database properties (Database/Cluster/ECU/Frame/Subframe/Signal)

            // Property ID nxPropClst_FlexRayChannels, nxPropFrm_FlexRayChAssign
            // nxPropClst_FlexRayConnectedChannels and nxPropClst_FlexRayWakeChannels
            public const int nxFrmFlexRayChAssign_A = 1;
            public const int nxFrmFlexRayChAssign_B = 2;
            public const int nxFrmFlexRayChAssign_AandB = 3;
            public const int nxFrmFlexRayChAssign_None = 4;

            // Property ID nxPropClst_FlexRaySampClkPer
            public const int nxClstFlexRaySampClkPer_p0125us = 0;
            public const int nxClstFlexRaySampClkPer_p025us = 1;
            public const int nxClstFlexRaySampClkPer_p05us = 2;

            // Property ID nxPropClst_Protocol uses prefix nxProtocol_

            // Property ID nxPropFrm_FlexRayTimingType
            public const int nxFrmFlexRayTiming_Cyclic = 0;
            public const int nxFrmFlexRayTiming_Event = 1;

            // Property ID nxPropFrm_CANTimingType
            public const int nxFrmCANTiming_CyclicData = 0;
            public const int nxFrmCANTiming_EventData = 1;
            public const int nxFrmCANTiming_CyclicRemote = 2;
            public const int nxFrmCANTiming_EventRemote = 3;

            // Property ID nxPropSig_ByteOrdr
            public const int nxSigByteOrdr_LittleEndian = 0;  // Intel
            public const int nxSigByteOrdr_BigEndian = 1;  // Motorola

            // Property ID nxPropSig_DataType
            public const int nxSigDataType_Signed = 0;
            public const int nxSigDataType_Unsigned = 1;
            public const int nxSigDataType_IEEEFloat = 2;

            // Property ID nxPropECU_LINProtocolVer
            public const int nxLINProtocolVer_1_2 = 2;
            public const int nxLINProtocolVer_1_3 = 3;
            public const int nxLINProtocolVer_2_0 = 4;
            public const int nxLINProtocolVer_2_1 = 5;
            public const int nxLINProtocolVer_2_2 = 6;

            // Property ID nxPropLINSched_RunMode
            public const int nxLINSchedRunMode_Continuous = 0;
            public const int nxLINSchedRunMode_Once = 1;
            public const int nxLINSchedRunMode_Null = 2;

            // Property ID nxPropLINSchedEntry_Type
            public const int nxLINSchedEntryType_Unconditional = 0;
            public const int nxLINSchedEntryType_Sporadic = 1;
            public const int nxLINSchedEntryType_EventTriggered = 2;
            public const int nxLINSchedEntryType_NodeConfigService = 3;

            // Property ID nxPropFrm_LINChecksum
            public const int nxFrmLINChecksum_Classic = 0;
            public const int nxFrmLINChecksum_Enhanced = 1;

            /***********************************************************************
                                    F R A M E
            ***********************************************************************/

            // Type
            public const uint nxFrameType_CAN_Data = 0x00;
            public const uint nxFrameType_CAN_Remote = 0x01;
            public const uint nxFrameType_CAN_BusError = 0x02;
            public const uint nxFrameType_FlexRay_Data = 0x20;
            public const uint nxFrameType_FlexRay_Null = 0x21;
            public const uint nxFrameType_FlexRay_Symbol = 0x22;
            public const uint nxFrameType_LIN_Data = 0x40;
            public const uint nxFrameType_LIN_BusError = 0x41;
            public const uint nxFrameType_Special_Delay = 0xE0;
            public const uint nxFrameType_Special_LogTrigger = 0xE1;
            public const uint nxFrameType_Special_StartTrigger = 0xE2;


            /* For Data frames, your application may not be concerned with specifics for
            CAN, FlexRay, or LIN. For example, you can use fields of the frame to determine
            the contents of Payload, and write general-purpose code to map signal
            values in/out of the Payload data bytes.
            This macro can be used with the frame's Type to determine if the frame is a
            data frame. The macro is used in boolean conditionals. */
            //        public byte nxFrameType_IsData(byte frametype)
            public bool nxFrameType_IsData(byte frametype)
            {
                return ((byte)(frametype) & 0x1F) == 0;
            }

            public const uint nxFrameId_CAN_IsExtended = 0x20000000;

            // Macros to get fields of frame Identifier for FlexRay input
            public ushort nxFrameId_FlexRay_Get_Slot(uint FrameId)
            {
                return (ushort)(((uint)FrameId) & 0x0000FFFF);
            }

            /* When Type is nxFrameType_FlexRay_Data,
            the following bitmasks are used with the Flags field.
            */
            public const byte nxFrameFlags_FlexRay_Startup = 0x01;     // Startup frame
            public const byte nxFrameFlags_FlexRay_Sync = 0x02;     // Sync frame
            public const byte nxFrameFlags_FlexRay_Preamble = 0x04;     // Preamble bit
            public const byte nxFrameFlags_FlexRay_ChA = 0x10;     // Transfer on Channel A
            public const byte nxFrameFlags_FlexRay_ChB = 0x20;     // Transfer on Channel B

            /* When Type is nxFrameType_LIN_Data,
            the following bitmasks are used with the Flags field.
            */
            public const byte nxFrameFlags_LIN_EventSlot = 0x01;     // Unconditional frame in event-triggered slot

            /* When Type is nxFrameType_CAN_Data, nxFrameType_CAN_Remote,
            nxFrameType_FlexRay_Data, or nxFrameType_LIN_Data,
            the following bitmasks are used with the Flags field.
            */
            public const byte nxFrameFlags_TransmitEcho = 0x80;

            /* When Type is nxFrameType_FlexRay_Symbol,
            the following values are used with the first Payload byte (offset 0).
            */
            public const byte nxFlexRaySymbol_MTS = 0x00;
            public const byte nxFlexRaySymbol_Wakeup = 0x01;

            /*
            public ushort  nxInternal_PadPayload(ushort payload)
            {
                return (ushort)(payload) ? (( (ushort)(payload) + 7) & 0x01F8) : 8;
            } /* */

            [StructLayout(LayoutKind.Sequential)]
            public struct nxFrameFixed_t
            {
                public ulong Timestamp;
                uint Identifier;
                byte Type;
                byte Flags;
                byte Info;
                byte PayloadLength;
                byte[] Payload;
                //byte[] Payload = new byte[nxInternal_PadPayload(payld)];
            };

            [StructLayout(LayoutKind.Sequential)]
            public struct nxFrameCAN_t
            {
                public ulong Timestamp;
                uint Identifier;
                byte Type;
                byte Flags;
                byte Info;
                byte PayloadLength;
                byte[] Payload;
                //byte[] Payload = new byte[((ushort)(8) ? (((ushort)(8) + 7) & 0x01F8) : 8)];
            };

            [StructLayout(LayoutKind.Sequential)]
            public struct nxFrameLIN_t
            {
                public ulong Timestamp;
                uint Identifier;
                byte Type;
                byte Flags;
                byte Info;
                byte PayloadLength;
                byte[] Payload;
                //byte[] Payload = new byte[((ushort)(8) ? (((ushort)(8) + 7) & 0x01F8) : 8)];
            };

            [StructLayout(LayoutKind.Sequential)]
            public struct nxFrameVar_t
            {
                public ulong Timestamp;
                uint Identifier;
                byte Type;
                byte Flags;
                byte Info;
                byte PayloadLength;
                byte[] Payload;
                //byte[] Payload = new byte[((ushort)(1) ? (((ushort)(1) + 7) & 0x01F8) : 8)];
            };

            /*public nxFrameFixed_type nxFrameFixed_t(ushort payld)
            {
            }/* */

            /*
                 struct { \
                        nxTimestamp_t       Timestamp; \
                        u32                 Identifier; \
                        u8                  Type; \
                        u8                  Flags; \
                        u8                  Info; \
                        u8                  PayloadLength; \
                        u8                  Payload[ nxInternal_PadPayload(payld) ]; \
                     }/* */
            //}

            // -----------------------------------------------------------------------------
            // If you are using CVI version 2009 or earlier, you may see a compile error for
            // this line. Upgrade to CVI version 2010 or later for the fix, disable the
            // "Build with C99 extensions" compiler option in the "Build Options" dialog of
            // CVI or edit your copy of the header file to resolve the error.
            // -----------------------------------------------------------------------------

            //typedef nxFrameFixed_t(8) nxFrameCAN_t;
            //typedef nxFrameFixed_t(8) nxFrameLIN_t;
            //typedef nxFrameFixed_t(1) nxFrameVar_t;

            public const int nxSizeofFrameHeader = (16);

            /*
            public ushort nxFrameSize(ushort payload)
            {
                return (nxSizeofFrameHeader + nxInternal_PadPayload(payload) );
            } /* */

            /* Use this macro to iterate through variable-length frames.
            You call this macro as a function, as if it used the following prototype:
               nxFrameVar_t * nxFrameIterate(nxFrameVar_t * frameptr);
            The input parameter must be initialized to point to the header of a valid frame.
            The macro returns a pointer to the header of the next frame in the buffer.
            In other words, the macro will iterate from one variable-length frame to
            the next variable-length frame.
            */
            /*
            unsafe public System.IntPtr nxFrameIterate(byte *frameptr)
            {
                return (System.IntPtr) ( (byte *)(frameptr) + nxFrameSize((frameptr)->PayloadLength) );
            }/* */
        } // class xNETConstants

        private class PInvoke
        {
            const string niXNETdll = "nixnet.dll";
            /* S E S S I O N:  F U N C T I O N S */

            /*nxCreateSession (const char * DatabaseName,
                               const char * ClusterName,
                               const char * List,
                               const char * Interface,
                               u32 Mode,
                               nxSessionRef_t * SessionRef)/**/
            [DllImport(niXNETdll, EntryPoint = "nxCreateSession", CallingConvention = CallingConvention.Cdecl)]
            public static extern int CreateSession(string DatabaseName, string ClusterName, string List, string Interface, uint Mode, out System.IntPtr sessionRef);

            /*nxStatus_t _NXFUNC nxCreateSessionByRef (
                               u32 NumberOfDatabaseRef,
                               nxDatabaseRef_t * ArrayOfDatabaseRef,
                               const char * Interface,
                               u32 Mode,
                               nxSessionRef_t * SessionRef);/* */
            [DllImport(niXNETdll, EntryPoint = "nxCreateSessionByRef", CallingConvention = CallingConvention.Cdecl)]
            public static extern int createSessionByRef(uint NumberOfDatabaseRef, uint[] ArrayOfDatabaseRef, string Interface, uint Mode, out System.IntPtr sessionRef);

            /*nxStatus_t _NXFUNC nxGetProperty (
                                       nxSessionRef_t SessionRef,
                                       u32 PropertyID,
                                       u32 PropertySize,
                                       void * PropertyValue); f64, u32[16], u32[], boolean, double, cstr, nxDatabaseRef_t[] /* */
            [DllImport(niXNETdll, EntryPoint = "nxGetProperty", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_getProperty(System.IntPtr sessionRef, uint PropertyID, uint PropertySize, out uint PropertyValue);

            [DllImport(niXNETdll, EntryPoint = "nxGetProperty", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_getProperty(System.IntPtr sessionRef, uint PropertyID, uint PropertySize, out uint[] PropertyValue);

            [DllImport(niXNETdll, EntryPoint = "nxGetProperty", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_getProperty(System.IntPtr sessionRef, uint PropertyID, uint PropertySize, out double PropertyValue);

            [DllImport(niXNETdll, EntryPoint = "nxGetProperty", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_getProperty(System.IntPtr sessionRef, uint PropertyID, uint PropertySize, System.Text.StringBuilder PropertyValue);

            /*nxStatus_t _NXFUNC nxGetPropertySize (
                                      nxSessionRef_t SessionRef,
                                      u32 PropertyID,
                                      u32 * PropertySize);/* */
            [DllImport(niXNETdll, EntryPoint = "nxGetPropertySize", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_getPropertySize(System.IntPtr sessionRef, uint PropertyID, out uint PropertySize);

            /*nxStatus_t _NXFUNC nxSetProperty (
                                       nxSessionRef_t SessionRef,
                                       u32 PropertyID,
                                       u32 PropertySize,
                                       void * PropertyValue);/* */
            [DllImport(niXNETdll, EntryPoint = "nxSetProperty", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_setProperty(System.IntPtr sessionRef, uint PropertyID, uint PropertySize, IntPtr PropertyValue);

            [DllImport(niXNETdll, EntryPoint = "nxSetProperty", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_setProperty(System.IntPtr sessionRef, uint PropertyID, uint PropertySize, ref uint PropertyValue);

            /*nxStatus_t _NXFUNC nxGetSubProperty (
                                       nxSessionRef_t SessionRef,
                                       u32 ActiveIndex,
                                       u32 PropertyID,
                                       u32 PropertySize,
                                       void * PropertyValue);/* */
            //[DllImport(niXNETdll, EntryPoint = "nxGetSubProperty", CallingConvention = CallingConvention.Cdecl)]
            //public static extern unsafe int nx_getSubProperty(System.IntPtr sessionRef, uint ActiveIndex, uint PropertyID, uint PropertySize, void* PropertyValue);

            /*nxStatus_t _NXFUNC nxGetSubPropertySize (
                                       nxSessionRef_t SessionRef,
                                       u32 ActiveIndex,
                                       u32 PropertyID,
                                       u32 * PropertySize);/* */
            [DllImport(niXNETdll, EntryPoint = "nxGetSubPropertySize", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_getSubPropertySize(System.IntPtr sessionRef, uint ActiveIndex, uint PropertyID, out uint PropertySize);

            /*nxStatus_t _NXFUNC nxSetSubProperty (
                                       nxSessionRef_t SessionRef,
                                       u32 ActiveIndex,
                                       u32 PropertyID,
                                       u32 PropertySize,
                                       void * PropertyValue);/* */
            //[DllImport(niXNETdll, EntryPoint = "nxSetSubProperty", CallingConvention = CallingConvention.Cdecl)]
            //public static extern unsafe int nx_setSubProperty(System.IntPtr sessionRef, uint ActiveIndex, uint PropertyID, uint PropertySize, void* PropertyValue);

            /*nxStatus_t _NXFUNC nxReadFrame (
                                       nxSessionRef_t SessionRef,
                                       void * Buffer,
                                       u32 SizeOfBuffer,
                                       f64 Timeout,
                                       u32 * NumberOfBytesReturned);/* */
            [DllImport(niXNETdll, EntryPoint = "nxReadFrame", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_readFrame(System.IntPtr sessionRef, [MarshalAs(UnmanagedType.LPArray)] byte[] Buffer, uint sizeOfBuffer, double timeOut, out uint NumberOfBytesReturned);

            /*nxStatus_t _NXFUNC nxReadSignalSinglePoint (
                                       nxSessionRef_t SessionRef,
                                       f64 * ValueBuffer,
                                       u32 SizeOfValueBuffer,
                                       nxTimestamp_t * TimestampBuffer,
                                       u32 SizeOfTimestampBuffer);/* */
            [DllImport(niXNETdll, EntryPoint = "nxReadSignalSinglePoint", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_readSignalSinglePoint(System.IntPtr sessionRef, [MarshalAs(UnmanagedType.LPArray)] double[] ValueBuffer, uint SizeOfValueBuffer, [MarshalAs(UnmanagedType.LPArray)] ulong[] TimestampBuffer, uint SizeOfTimestampBuffer);

            /*nxStatus_t _NXFUNC nxReadSignalWaveform (
                                       nxSessionRef_t SessionRef,
                                       f64 Timeout,
                                       nxTimestamp_t * StartTime,
                                       f64 * DeltaTime,
                                       f64 * ValueBuffer,
                                       u32 SizeOfValueBuffer,
                                       u32 * NumberOfValuesReturned);/* */
            [DllImport(niXNETdll, EntryPoint = "nxReadSignalWaveform", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_readSignalWaveform(System.IntPtr sessionRef, double Timeout, out ulong StartTime, out double DeltaTime, uint SizeOfValueBuffer, out uint NumberOfValuesReturned);

            /*nxStatus_t _NXFUNC nxReadSignalXY (
                                       nxSessionRef_t SessionRef,
                                       nxTimestamp_t * TimeLimit,
                                       f64 * ValueBuffer,
                                       u32 SizeOfValueBuffer,
                                       nxTimestamp_t * TimestampBuffer,
                                       u32 SizeOfTimestampBuffer,
                                       u32 * NumPairsBuffer,
                                       u32 SizeOfNumPairsBuffer);/* */
            [DllImport(niXNETdll, EntryPoint = "nxReadSignalXY", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_readSignalXY(System.IntPtr SessionRef, ulong TimeLimit, [MarshalAs(UnmanagedType.LPArray)] double[,] ValueBuffer, uint SizeOfValueBuffer, [MarshalAs(UnmanagedType.LPArray)] ulong[,] TimestampBuffer, uint SizeOfTimestampBuffer, [MarshalAs(UnmanagedType.LPArray)] uint[] NumPairsBuffer, uint SizeOfNumPairsBuffer);

            /*nxStatus_t _NXFUNC nxReadState (
                                       nxSessionRef_t SessionRef,
                                       u32 StateID,
                                       u32 StateSize,
                                       void * StateValue,
                                       nxStatus_t * Fault);/* */
            [DllImport(niXNETdll, EntryPoint = "nxReadState", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_readState(System.IntPtr sessionRef, uint StateID, uint StateSize,out uint StateValue, out int Fault);

			[DllImport(niXNETdll, EntryPoint = "nxReadState", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_readState(System.IntPtr sessionRef, uint StateID, uint StateSize, System.IntPtr StateValue, out int Fault);

            /*nxStatus_t _NXFUNC nxWriteFrame (
                                       nxSessionRef_t SessionRef,
                                       void * Buffer,
                                       u32 NumberOfBytesForFrames,
                                       f64 Timeout);/* */
            [DllImport(niXNETdll, EntryPoint = "nxWriteFrame", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_writeFrame(System.IntPtr sessionRef, byte[] buffer, uint NumberOfBytesForFrames, double timeOut);

            /*nxStatus_t _NXFUNC nxWriteSignalSinglePoint (
                                       nxSessionRef_t SessionRef,
                                       f64 * ValueBuffer,
                                       u32 SizeOfValueBuffer);/* */
            [DllImport(niXNETdll, EntryPoint = "nxWriteSignalSinglePoint", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_writeSignalSinglePoint(System.IntPtr sessionRef, double[] ValueBuffer, uint SizeOfValueBuffer);

            /*nxStatus_t _NXFUNC nxWriteState (
                                       nxSessionRef_t SessionRef,
                                       u32 StateID,
                                       u32 StateSize,
            //                           void * StateValue);/* */
            //[DllImport(niXNETdll, EntryPoint = "nxWriteState", CallingConvention = CallingConvention.Cdecl)]
            //public static extern unsafe int nx_writeState(System.IntPtr sessionRef, uint StateID, uint StateSize, void* StateValue);

            /*nxStatus_t _NXFUNC nxWriteSignalWaveform (
                                       nxSessionRef_t SessionRef,
                                       f64 Timeout,
                                       f64 * ValueBuffer,
                                       u32 SizeOfValueBuffer);/* */
            [DllImport(niXNETdll, EntryPoint = "nxWriteSignalWaveform", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_writeSignalWaveform(System.IntPtr sessionRef, double timeOut, double[,] ValueBuffer, uint SizeOfValueBuffer);

            /*nxStatus_t _NXFUNC nxWriteSignalXY (
                                       nxSessionRef_t SessionRef,
                                       f64 Timeout,
                                       f64 * ValueBuffer,
                                       u32 SizeOfValueBuffer,
                                       nxTimestamp_t * TimestampBuffer,
                                       u32 SizeOfTimestampBuffer,
                                       u32 * NumPairsBuffer,
                                       u32 SizeOfNumPairsBuffer);/* */
            [DllImport(niXNETdll, EntryPoint = "nxWriteSignalXY", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_writeSignalXY(System.IntPtr sessionRef, double timeOut, double[,] ValueBuffer, uint SizeOfValueBuffer, ulong[,] TimestampBuffer, uint SizeOfTimestampBuffer, uint[] NumPairsBuffer, uint SizeOfNumPairsBuffer);

            /*nxStatus_t _NXFUNC nxConvertFramesToSignalsSinglePoint (
                                       nxSessionRef_t SessionRef,
                                       void * FrameBuffer,
                                       u32 NumberOfBytesForFrames,
                                       f64 * ValueBuffer,
                                       u32 SizeOfValueBuffer,
                                       nxTimestamp_t * TimestampBuffer,
                                       u32 SizeOfTimestampBuffer);/* */
            //[DllImport(niXNETdll, EntryPoint = "nxConvertFramesToSignalsSinglePoint", CallingConvention = CallingConvention.Cdecl)]
            //public static extern unsafe int nx_convertFramesToSignalsSinglePoint(System.IntPtr sessionRef, void* FrameBuffer, uint NumberOfBytesForFrames, out double ValueBuffer, uint SizeOfValueBuffer, out ulong TimestampBuffer, uint SizeOfTimestampBuffer);

            /*nxStatus_t _NXFUNC nxConvertSignalsToFramesSinglePoint (
                                       nxSessionRef_t SessionRef,
                                       f64 * ValueBuffer,
                                       u32 SizeOfValueBuffer,
                                       void * Buffer,
                                       u32 SizeOfBuffer,
                                       u32 * NumberOfBytesReturned);/* */
            //[DllImport(niXNETdll, EntryPoint = "nxConvertSignalsToFramesSinglePoint", CallingConvention = CallingConvention.Cdecl)]
            //public static extern unsafe int nx_convertSignalsToFramesSinglePoint(System.IntPtr sessionRef, out double ValueBuffer, uint SizeOfValueBuffer, void* buffer, uint SizeOfBuffer, out uint NumberOfBytesReturned);

            /*nxStatus_t _NXFUNC nxBlink (
                                       nxSessionRef_t InterfaceRef,
                                       u32 Modifier);/* */
            [DllImport(niXNETdll, EntryPoint = "nxBlink", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_blink(System.IntPtr sessionRef, uint Modifier);

            /*nxStatus_t _NXFUNC nxClear (
                                       nxSessionRef_t SessionRef);/* */
            [DllImport(niXNETdll, EntryPoint = "nxClear", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_clear(System.IntPtr sessionRef);

            /*nxStatus_t _NXFUNC nxConnectTerminals (
                                       nxSessionRef_t SessionRef,
                                       const char * source,
                                       const char * destination);/* */
            [DllImport(niXNETdll, EntryPoint = "nxConnectTerminals", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_connectTerminals(System.IntPtr sessionRef, string source, string destiniation);

            /*nxStatus_t _NXFUNC nxDisconnectTerminals (
                                       nxSessionRef_t SessionRef,
                                       const char * source,
                                       const char * destination);/* */
            [DllImport(niXNETdll, EntryPoint = "nxDisconnectTerminals", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_disconnectTerminals(System.IntPtr sessionRef, string source, string destiniation);

            /*nxStatus_t _NXFUNC nxFlush (
                                       nxSessionRef_t SessionRef);/* */
            [DllImport(niXNETdll, EntryPoint = "nxFlush", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_flush(System.IntPtr sessionRef);

            /*nxStatus_t _NXFUNC nxStart (
                                       nxSessionRef_t SessionRef,
                                       u32 Scope);/* */
            [DllImport(niXNETdll, EntryPoint = "nxStart", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_start(System.IntPtr sessionRef, uint Scope);

            /*nxStatus_t _NXFUNC nxStop (
                                       nxSessionRef_t SessionRef,
                                       u32 Scope);/* */
            [DllImport(niXNETdll, EntryPoint = "nxStop", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_stop(System.IntPtr sessionRef, uint Scope);

            /*void _NXFUNC nxStatusToString (
                                       nxStatus_t Status,
                                       u32 SizeofString,
                                       char * StatusDescription);/* */
            [DllImport(niXNETdll, EntryPoint = "nxStatusToString", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_statusToString(int Status, uint SizeOfString, System.Text.StringBuilder StatusDescription);

            /*nxStatus_t _NXFUNC nxSystemOpen (
                                       nxSessionRef_t * SystemRef);/* */
            [DllImport(niXNETdll, EntryPoint = "nxSystemOpen", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_systemOpen(out System.IntPtr sessionRef);

            /*nxStatus_t _NXFUNC nxSystemClose (
                                       nxSessionRef_t SystemRef);/* */
            [DllImport(niXNETdll, EntryPoint = "nxSystemClose", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_systemClose(System.IntPtr sessionRef);

            /*nxStatus_t _NXFUNC nxWait (
                                       nxSessionRef_t SessionRef,
                                       u32 Condition,
                                       u32 ParamIn,
                                       f64 Timeout,
                                       u32 * ParamOut);/* */
            [DllImport(niXNETdll, EntryPoint = "nxWait", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nx_wait(System.IntPtr sessionRef, uint Condition, uint ParamIn, double timeOut, out uint ParamOut);

            /*************************************************************************************
            *                                                                                   *
            *                     D A T A B A S E: F U N C T I O N S                            *
            *                                                                                   *
            *************************************************************************************/

            /*nxStatus_t _NXFUNC nxdbOpenDatabase (
                               const char * DatabaseName,
                               nxDatabaseRef_t * DatabaseRef);/* */
            [DllImport(niXNETdll, EntryPoint = "nxdbOpenDatabase", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nxdb_openDatabase(string DatabaseName, out uint DatabaseRef);

            /*nxStatus_t _NXFUNC nxdbCloseDatabase (
                               nxDatabaseRef_t DatabaseRef,
                               u32 CloseAllRefs); /* */
            [DllImport(niXNETdll, EntryPoint = "nxdbCloseDatabase", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nxdb_closeDatabase(uint DatabaseRef, uint CloseAllRefs);

            /*nxStatus_t _NXFUNC nxdbCreateObject (
                               nxDatabaseRef_t ParentObjectRef,
                               u32 ObjectClass,
                               const char * ObjectName,
                               nxDatabaseRef_t * DbObjectRef); /* */
            [DllImport(niXNETdll, EntryPoint = "nxdbCreateObject", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nxdb_createObject(uint ParentObjectRef, uint ObjectClass, string ObjectName, out uint DbObjectRef);

            /*nxStatus_t _NXFUNC nxdbFindObject (
                               nxDatabaseRef_t ParentObjectRef,
                               u32 ObjectClass,
                               const char * ObjectName,
                               nxDatabaseRef_t * DbObjectRef);/* */
            [DllImport(niXNETdll, EntryPoint = "nxdbFindObject", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nxdb_findObject(uint ParentObjectRef, uint ObjectClass, string ObjecName, out uint DbObjectRef);

            /*nxStatus_t _NXFUNC nxdbDeleteObject (
                                       nxDatabaseRef_t DbObjectRef);/* */
            [DllImport(niXNETdll, EntryPoint = "nxdbDeleteObject", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nxdb_deleteObject(uint DbObjectRef);

            /*nxStatus_t _NXFUNC nxdbSaveDatabase (
                                       nxDatabaseRef_t DatabaseRef,
                                       const char * DbFilepath); /* */
            [DllImport(niXNETdll, EntryPoint = "nxdbSaveDatabase", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nxdb_saveDatabase(uint DatabaseRef, string DbFilepath);

            /*nxStatus_t _NXFUNC nxdbGetProperty (
                                       nxDatabaseRef_t DbObjectRef,
                                       u32 PropertyID,
                                       u32 PropertySize,
                                       void * PropertyValue); f64, u32[16], u32[], boolean, double, cstr, nxDatabaseRef_t[] /* */
            //[DllImport(niXNETdll, EntryPoint = "nxdbGetProperty", CallingConvention = CallingConvention.Cdecl)]
            //public static extern unsafe int nxdb_getProperty(uint DbObjectRef, uint PropertyID, uint PropertySize, void* PropertyValue);

            /*nxStatus_t _NXFUNC nxdbGetPropertySize (
                                       nxDatabaseRef_t DbObjectRef,
                                       u32 PropertyID,
                                       u32 * PropertySize);/* */
            [DllImport(niXNETdll, EntryPoint = "nxdbGetPropertySize", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nxdb_getPropertySize(uint DbObjectRef, uint PropertyID, out uint PropertySize);

            /*nxStatus_t _NXFUNC nxdbSetProperty (
                                       nxDatabaseRef_t DbObjectRef,
                                       u32 PropertyID,
                                       u32 PropertySize,
                                       void * PropertyValue);/* */
            //[DllImport(niXNETdll, EntryPoint = "nxdbSetProperty", CallingConvention = CallingConvention.Cdecl)]
            //public static extern unsafe int nxdb_setProperty(uint DbObjectRef, uint PropertyID, uint PropertySize, void* PropertyValue);

            /*nxStatus_t _NXFUNC nxdbGetDBCAttributeSize (
                           nxDatabaseRef_t DbObjectRef,
                           u32 Mode,
                           const char* AttributeName,
                           u32 *AttributeTextSize);/* */
            [DllImport(niXNETdll, EntryPoint = "nxdbGetDBCAttributeSize", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nxdb_getDBCAttributeSize(uint DbObjectRef, uint Mode, string AttributeName, out uint AttributeTextSize);

            /*nxStatus_t _NXFUNC nxdbGetDBCAttribute (
                                       nxDatabaseRef_t DbObjectRef,
                                       u32 Mode,
                                       const char* AttributeName,
                                       u32 AttributeTextSize,
                                       char* AttributeText,
                                       u32 * IsDefault);/* */
            [DllImport(niXNETdll, EntryPoint = "nxdbGetDBCAttribute", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nxdb_getDBCAttribute(uint DbObjectRef, uint Mode, string AttributeName, uint AttributeTextSize, out string AttributeText, out uint IsDefault);

            /*nxStatus_t _NXFUNC nxdbAddAlias (
                                       const char * DatabaseAlias,
                                       const char * DatabaseFilepath,
                                       u32          DefaultBaudRate);/* */
            [DllImport(niXNETdll, EntryPoint = "nxdbAddAlias", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nxdb_addAlias(string DatabaseAlias, string DatabaseFilepath, uint DefaultBaudRate);

            /*nxStatus_t _NXFUNC nxdbRemoveAlias (
                                       const char * DatabaseAlias);/* */
            [DllImport(niXNETdll, EntryPoint = "nxdbRemoveAlias", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nxdb_removeAlias(string DatabaseAlias);

            /*nxStatus_t _NXFUNC nxdbDeploy (
                                       const char * IPAddress,
                                       const char * DatabaseAlias,
                                       u32 WaitForComplete,
                                       u32 * PercentComplete);/* */
            [DllImport(niXNETdll, EntryPoint = "nxdbDeploy", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nxdb_deploy(string IPAddress, string DatabaseAlias, uint WaitForComplete, out uint PercentComplete);

            /*nxStatus_t _NXFUNC nxdbUndeploy (
                                       const char * IPAddress,
                                       const char * DatabaseAlias);/* */
            [DllImport(niXNETdll, EntryPoint = "nxdbUndeploy", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nxdb_undeploy(string IPAddress, string DatabaseAlias);

            /*nxStatus_t _NXFUNC nxdbGetDatabaseList (
                                       const char * IPAddress,
                                       u32 SizeofAliasBuffer,
                                       char * AliasBuffer,
                                       u32 SizeofFilepathBuffer,
                                       char * FilepathBuffer,
                                       u32 * NumberOfDatabases);/* */
            [DllImport(niXNETdll, EntryPoint = "nxdbGetDatabaseList", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nxdb_getDatabaseList(string IPAddress, uint SizeofAliasBuffer, out string AliasBuffer, uint SizeofFilepathBuffer, out string FilepathBuffer, out uint NumberOfDatabases);

            /*nxStatus_t _NXFUNC nxdbGetDatabaseListSizes (
                                       const char * IPAddress,
                                       u32 * SizeofAliasBuffer,
                                       u32 * SizeofFilepathBuffer);/* */
            [DllImport(niXNETdll, EntryPoint = "nxdbGetDatabaseListSizes", CallingConvention = CallingConvention.Cdecl)]
            public static extern int nxdb_getDatabaseListSizes(string IPAddress, out uint SizeofAliasBuffer, out uint SizeofFilepathBuffer);

            
            public static int TestForError(System.IntPtr handle, int status)
            {
                if ((status < 0))
                {
                    PInvoke.ThrowError(handle, status);
                }
                return status;
            }

            public static int ThrowError(System.IntPtr handle, int errorCode)
            {
               
                //according to the user guide, 2048 should be enough for the messages
                uint size = 2048;

           
                System.Text.StringBuilder errorMsg = new System.Text.StringBuilder();
                errorMsg.Capacity = 2048;
                //the xnet dll does not have a way to get the size before getting the message
                PInvoke.nx_statusToString(errorCode, size, errorMsg);
                
                throw new System.Runtime.InteropServices.ExternalException(errorMsg.ToString(), errorCode);
            }

        } // PInvoke
    } // xnet class
} // namespace