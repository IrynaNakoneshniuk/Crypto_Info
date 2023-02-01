using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace Crypto_Info
{
    public class UpdateViewCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
 
        private MainPageVM viewModel { get; set; }

        public UpdateViewCommand(MainPageVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await Task.Run(() =>
            {
                try
                {
                    if (parameter.ToString() == CommandParameters.CommandParam.ElementAt(0))
                    {
                        viewModel.SelectedViewModel = new MarketplaceVM();
                    }
                    else if (parameter.ToString() == CommandParameters.CommandParam.ElementAt(1))
                    {
                        viewModel.SelectedViewModel = new ExchangerateVM();
                    }
                    else if (parameter.ToString() == CommandParameters.CommandParam.ElementAt(2))
                    {
                        viewModel.SelectedViewModel = new MainPageVM();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }
    }
}
