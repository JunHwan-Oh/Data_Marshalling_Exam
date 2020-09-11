using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static DataMarshallingExam.Components.MarshallingPanel.MarshallModel;

namespace DataMarshallingExam.Components
{
    internal static class NativeMethods
    {
#if DEBUG
        private const string dllName = "LIB//DataMarshallingCommd";
#else
        private const string dllName = "LIB//DataMarshallingComm";
#endif

        #region MarshallingPanel

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Boolean Send(IntPtr pItemsData);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool Init(ReceiveDelegate del);

        #endregion



        #region MarshallingPointer

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern eError Find(
                        IntPtr[] datalist, int length, out int numfound);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Delete(
                        IntPtr data);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool GetText(
                        IntPtr data, uint length);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool GetFloatArray(
                        IntPtr data, int length);


        #endregion

        internal enum eError
        {
            eNONE = 0,
            eNULLED = 1,
        }

        internal static void CheckError(eError e)
        {
            switch (e)
            {
                case eError.eNULLED:
                    throw new ArgumentNullException("NativeMethod has NULL.");

            }

        }
    }
}
