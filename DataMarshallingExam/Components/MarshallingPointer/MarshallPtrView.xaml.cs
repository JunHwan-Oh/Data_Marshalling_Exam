using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataMarshallingExam.Components.MarshallingPointer
{
    /// <summary>
    /// MarshallingPtrView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MarshallPtrView : UserControl
    {
        public MarshallPtrView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as MarshallPtrViewModel).findList();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            (this.DataContext as MarshallPtrViewModel).testMethod();
        }
    }
}
