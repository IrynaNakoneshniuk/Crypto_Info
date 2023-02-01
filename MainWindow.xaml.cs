using Crypto_Info.ApiData;
using Crypto_Info.ApiData.ApiClient;
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
using Crypto_Info.ApiData;
using Crypto_Info.ApiData.MarketsF;
using Crypto_Info.ApiData.ExchangesF;

namespace Crypto_Info
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ApiRestClientCoincapcs ap = new ApiRestClientCoincapcs();
        List<Candles> assets = new List<Candles>();
        public MainWindow()
        {
           
            InitializeComponent();
            
            
            
           

        }

        private async void Window_MouseDoubleClickAsync(object sender, MouseButtonEventArgs e)
        {
            assets = await ap.GetCandlesAsync("poloniex", "h8", "ethereum", "bitcoin");


        }        
    }
}
