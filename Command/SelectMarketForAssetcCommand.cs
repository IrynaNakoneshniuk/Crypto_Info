using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto_Info
{
    public class SelectMarketForAssetcCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private MarketplaceVM MarketplaceVM;
        public SelectMarketForAssetcCommand(MarketplaceVM marketplaceVM)
        {
            this.MarketplaceVM = marketplaceVM;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }
        public void Execute(object? parameter)
        {
            this.MarketplaceVM.AssetsMarkets = FasadApi.AssetsMarket;
        }
    }
}
