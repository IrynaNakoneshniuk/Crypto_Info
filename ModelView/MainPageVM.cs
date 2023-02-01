using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace Crypto_Info
{
    public class MainPageVM:BaseVM
    {
        public BaseVM _selectedViewModel { get; set; }
        private List<PopularAssets> _popularAssets;
        public List<PopularAssets> PopularAssets
        {

            get { return _popularAssets; }
            set {
                _popularAssets = value; 
            OnPropertyChanged(nameof(PopularAssets));}
        }
        public ICommand SelectedView { get; set; }
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
            _selectedViewModel = new BaseVM();
            _popularAssets = new List<PopularAssets>();
            SelectedView = new UpdateViewCommand(this);
            _popularAssets = new List<PopularAssets>();
            _popularAssets = FasadApi.GetListIconAssetsPopular().Result;



        }
    }
}
