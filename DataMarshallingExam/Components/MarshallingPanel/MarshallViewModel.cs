using System;
using System.Runtime.InteropServices;
using static DataMarshallingExam.Components.MarshallingPanel.MarshallModel;

namespace DataMarshallingExam.Components.MarshallingPanel
{
    public class MarshallViewModel
    {
        static ReceiveDelegate receive_delegate;

        MarshallView _view = null;
        MarshallModel _model = null;

        public MarshallModel Model { get { return this._model; } }

        public MarshallViewModel(MarshallView _view)
        {
            this._view = _view;
            this._model = new MarshallModel(_view);
        }

        // 보내기 위한 함수    cpp 속성 -> C/C++ -> 고급 -> 호출 규칙 (StdCall) 로 설정해야 함.
        [DllImport("LIB\\DataMarshallingComm.dll")]
        public static extern Boolean Send(IntPtr pItemsData);


        // 받기 위한 함수      cpp 속성 -> C/C++ -> 고급 -> 호출 규칙 (StdCall) 로 설정해야 함.
        [DllImport("LIB\\DataMarshallingComm.dll")]
        public static extern bool Init(ReceiveDelegate del);

        




        // 텍스트 전송 함수
        static bool _Send(MessageItemData messageitem)
        {
            bool bRet = false;

            int iSizeOfStruct = Marshal.SizeOf(typeof(MessageItemData));
            IntPtr pmipout_itemdata = Marshal.AllocCoTaskMem(iSizeOfStruct);
            Marshal.StructureToPtr(messageitem, pmipout_itemdata, true);


            bRet = Send(pmipout_itemdata);

            Console.WriteLine("\n---------- C# 에서 받은 구조체 ----------");


            Marshal.FreeHGlobal(pmipout_itemdata);
            
            return bRet;
        }

        static bool _Init(ReceiveDelegate del)
        {
            bool bRet = false;

            bRet = Init(del);

            return bRet;
        }


        void _Receive(MessageItemData item, bool b)
        {
            //Console.WriteLine(item._num.ToString() + " 의 값이 들어왔습니다!");

            this._view.result_int.Text = item._num.ToString();
            this._view.result_double.Text = item._dnum.ToString();
            this._view.result_double1.Text = item._todo[0].ToString();
            this._view.result_double2.Text = item._todo[1].ToString();
            this._view.result_double3.Text = item._todo[2].ToString();
            this._view.result_string.Text = item.strTest.ToString();
            this._view.result_boolean.Text = item.isRun.ToString();

        }
        

        public void Run()
        {
            MessageItemData msgitem;

            try
            {
                msgitem._num = int.Parse(this._view.prev_int.Text);
                msgitem._dnum = double.Parse(this._view.prev_double.Text);
                msgitem._todo = new double[3];
                msgitem._todo[0] = double.Parse(this._view.prev_double1.Text);
                msgitem._todo[1] = double.Parse(this._view.prev_double2.Text);
                msgitem._todo[2] = double.Parse(this._view.prev_double3.Text);
                msgitem.strTest = this._view.prev_string.Text;
                msgitem.isRun = Boolean.Parse(this._view.prev_boolean.Text);

                Boolean bRet = _Send(msgitem);

                if (bRet)
                {
                    Console.WriteLine("\n\n--------- C# 전송한 결과값 성공적으로 리턴됨 -----------\n\n\n");
                }
                else
                {
                    Console.WriteLine("\n\n\n--------- C# 마샬링 실패함. -----------\n\n\n");
                }

                receive_delegate += _Receive;

                _Init(receive_delegate);

            } catch(Exception e)
            {
                Console.WriteLine(e);
                System.Windows.MessageBox.Show("정확한 데이터를 입력하십시오!");
            }
        }
    }
}
