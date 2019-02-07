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

namespace DataMarshallingExam.Components.MarshallingPanel
{
    /// <summary>
    /// MarshallView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MarshallView : UserControl
    {
        public MarshallView()
        {
            InitializeComponent();
            this.DataContext = new MarshallViewModel(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((MarshallViewModel)this.DataContext).Run();
        }
    }
}
