using Crypto_Info.ApiData;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto_Info.Command
{
    public class SelectedCurrencyCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private MainPageVM mainPageVM;
        public SelectedCurrencyCommand (MainPageVM mainPageVM)
        {
            this.mainPageVM = mainPageVM;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
          Mediator._Name = mainPageVM.SelectedItem.Id;
           Assets assets = FasadApi.ListAssets.Where(i=>i.name== Mediator._Name).FirstOrDefault();  
            if (assets != null)
            {
                Mediator.Supply = assets.supply;
                Mediator.Price = assets.priceUsd;
            }
        }
    }
}
