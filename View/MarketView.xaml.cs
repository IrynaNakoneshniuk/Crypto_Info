using System.Reflection.Emit;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;
namespace Crypto_Info
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MarketView : UserControl
    {
        private string[] _labels;
        public MarketView()
        {
            InitializeComponent();


            _labels = new string[] { "10", "40", "60", "70" };
        }
       
    }
}
