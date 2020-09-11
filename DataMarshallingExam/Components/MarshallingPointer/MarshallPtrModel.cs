using DataMarshallingExam.BaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D.Converters;

namespace DataMarshallingExam.Components.MarshallingPointer
{
    public class MarshallPtrModel : ModelBase
    {
        public static readonly byte MAX_COUNT = 5;

        public MarshallPtrModel() { }

        private ObservableCollection<TransData> _Data = new ObservableCollection<TransData>();
        public ObservableCollection<TransData> Data { get { return this._Data; } set { this._Data = value; OnPropertyChanged(); } }
    }


    public class TransData : BaseClasses.Object
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class TransDataItem
        {
            public int _IntValue;
            public double _DoubleValue;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string _StringValue;
            [MarshalAs(UnmanagedType.I1)]
            public bool _BoolValue;

            public int IntValue { get => _IntValue; set => _IntValue = value; }
            public double DoubleValue { get => _DoubleValue; set => _DoubleValue = value; }
            public string StringValue { get => _StringValue; set => _StringValue = value; }
            public bool BoolValue { get => _BoolValue; set => _BoolValue = value; }
        }

        public TransDataItem Item { get; set; }

        public TransData(IntPtr ptr)
                        : base(ptr, NativeMethods.Delete) 
        {
            Item = Marshal.PtrToStructure<TransDataItem>(Handle);
        }

    }



    

}
