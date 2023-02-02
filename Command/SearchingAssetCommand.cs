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

        public void Execute(object? parameter)
        {
            List<PopularAssets> filtered = mainPageVM.popularAssets.
                Where(source => source.Id.StartsWith(mainPageVM.SymbolSearching)).ToList<PopularAssets>();
            if (filtered != null)
            {
                mainPageVM.popularAssets = filtered;
            }
            else
            {
                mainPageVM.popularAssets = FasadApi.GetListIconAssetsPopular();
            }
        }
    }
}
