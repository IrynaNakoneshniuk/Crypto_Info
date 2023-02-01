using System.Windows.Input;

namespace Crypto_Info
{
    public class MainPageVM:BaseVM
    {
        public BaseVM _selectedViewModel { get; set; }
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
        public MainPageVM()
        {
            _selectedViewModel = new BaseVM();
            SelectedView = new UpdateViewCommand(this);
        }
    }
}
