using Crypto_Info.ApiData.AssetsF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto_Info
{
    public class MarketplaceVM:BaseVM
    {
        private List<AssetsMarkets> _assetsMarkets;
        public ICommand SelectedMarket { get; set; }
        public List<AssetsMarkets> AssetsMarkets
        {
            get { return _assetsMarkets; } 
            set { _assetsMarkets = value; 
            OnPropertyChanged(nameof(AssetsMarkets));}
        }
        public MarketplaceVM()
        {
            _assetsMarkets = new List<AssetsMarkets>();
            _assetsMarkets = FasadApi.AssetsMarket;
            SelectedMarket = new SelectMarketForAssetcCommand(this);
        }
    }
}
