using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto_Info
{
    public class SearchingAssetCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private MainPageVM mainPageVM;
        public SearchingAssetCommand(MainPageVM mainPageVM)
        {
            this.mainPageVM = mainPageVM;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }
        private List<PopularAssets> FilterCurrencyList()
        {
            List<PopularAssets> filtered = mainPageVM.popularAssets.Where(source => source.Name.StartsWith(mainPageVM.SymbolSearching.ToUpper())).ToList<PopularAssets>();
            return filtered;
        }
        public void Execute(object? parameter)
        {
            var filtered = FilterCurrencyList();
            mainPageVM.popularAssets= filtered;
        }
    }
}
