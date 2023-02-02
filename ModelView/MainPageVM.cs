using Crypto_Info.Command;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace Crypto_Info
{
    public class MainPageVM:BaseVM
    {
        public BaseVM _selectedViewModel { get; set; }
        private string _symbolSearching;
        public string SymbolSearching
        {
            get { return _symbolSearching; }
            set { _symbolSearching = value;
                OnPropertyChanged(nameof(SymbolSearching));
            }
        }
        private List<PopularAssets> _popularAssets;
        private PopularAssets _selectedItem;
        public PopularAssets SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public List<PopularAssets> popularAssets
        {

            get { return _popularAssets; }
            set {
                _popularAssets = value; 
            OnPropertyChanged(nameof(popularAssets));}
        }
        public ICommand SelectedView { get; set; }
        public ICommand SearchingAssets { get; set; }
        public ICommand SelectedAssets { get; set; }
        public BaseVM SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public  MainPageVM()
        {
            _selectedViewModel = this;
            _popularAssets = new List<PopularAssets>();
            SelectedView = new UpdateViewCommand(this);
            SearchingAssets= new SearchingAssetCommand(this);
            SelectedAssets=new SelectedCurrencyCommand(this);   
            _popularAssets = FasadApi.GetListIconAssetsPopular();
        }
    }
}
