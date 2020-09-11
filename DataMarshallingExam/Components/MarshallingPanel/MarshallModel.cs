using DataMarshallingExam.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataMarshallingExam.Components.MarshallingPanel
{
    public class MarshallModel : ModelBase
    {
        MarshallView _view = null;

        public MarshallModel(MarshallView _view)
        {
            this._view = _view;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        unsafe public struct MessageItemData
        {
            public int _num;
            public double _dnum;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public double[] _todo;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public String strTest;
            [MarshalAs(UnmanagedType.I1)]
            public bool isRun;
        }

        public delegate void ReceiveDelegate(MessageItemData s, bool b);
    }
}
