using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto_Info.Command
{
    public class UpdateExchageCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private ExchangerateVM exchangerateVM;
        public UpdateExchageCommand(ExchangerateVM exchangerateVM)
        {
            this.exchangerateVM = exchangerateVM;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            exchangerateVM.Exchange = FasadApi.ExchangeCurrentrateList;
        }
    }
}
