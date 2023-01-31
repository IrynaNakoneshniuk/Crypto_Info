using System.Reflection.Emit;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;
namespace Crypto_Info.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private string[] _labels;
        public UserControl1()
        {
            InitializeComponent();


            _labels = new string[] { "10", "40", "60", "70" };
        }
       
    }
}
