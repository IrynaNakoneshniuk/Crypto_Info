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
       public MarketplaceVM marketplaceVM { get; set; }
        public MarketView()
        {
            InitializeComponent();
            marketplaceVM=new MarketplaceVM();
            this.DataContext=marketplaceVM;
        }
       
    }
}
