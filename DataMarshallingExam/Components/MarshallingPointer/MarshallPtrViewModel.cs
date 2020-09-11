using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataMarshallingExam.Components.MarshallingPointer
{
    public class MarshallPtrViewModel
    {
        private MarshallPtrModel _model = null;
        public MarshallPtrModel Model { get { return this._model; } }

        public MarshallPtrViewModel()
        {
            this._model = new MarshallPtrModel();

            
        }

        public void findList()
        {
            //List<TransData> datalist = new List<TransData>();

            IntPtr[] pdatalist = new IntPtr[MarshallPtrModel.MAX_COUNT];
            int numfound = 0;

            NativeMethods.CheckError(NativeMethods.Find(pdatalist, (int)MarshallPtrModel.MAX_COUNT, out numfound));

            this.Model.Data.Clear();

            for(int i = 0; i < MarshallPtrModel.MAX_COUNT; ++i)
            {
                TransData item = new TransData(pdatalist[i]);

                this.Model.Data.Add(item);
            }
        }

        internal void testMethod()
        {
            IntPtr num = Marshal.AllocHGlobal(13);
            bool bRet = NativeMethods.GetText(num, 13U);
            string stringAnsi = Marshal.PtrToStringAnsi(num);
            Marshal.FreeHGlobal(num);

            MessageBox.Show("stringAnsi = " + stringAnsi);

            float[] floatarray = new float[5];

            GCHandle gcHandle = new GCHandle();
            IntPtr pfloatarray = IntPtr.Zero;

            gcHandle = GCHandle.Alloc((object)floatarray, GCHandleType.Pinned);
            pfloatarray = gcHandle.AddrOfPinnedObject();

            NativeMethods.GetFloatArray(pfloatarray, floatarray.Length);

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < floatarray.Length; ++i)
            {
                sb.Append(i.ToString() + " idx :: " + floatarray[i] + Environment.NewLine);
            }

            MessageBox.Show(sb.ToString());


        }
    }
}
