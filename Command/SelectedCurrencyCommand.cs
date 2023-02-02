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
            Task taskMark = Task.Factory.StartNew(async () => { FasadApi.AssetsMarket = await FasadApi.Coincapcs.GetInfoMarketsAsync(Mediator._Name); });
            taskMark.Wait();
            Assets assets = null;
            Task task = Task.Run(async () => { assets = await FasadApi.Coincapcs.GetAssetsByIdAsync(mainPageVM.SelectedItem.Id);}) ;
            task.Wait();
            Task rate = Task.Factory.StartNew(async () => { FasadApi.ExchangeCurrentrateList = await FasadApi.ApiRestClient.ExchangeRatesGetAll(assets.symbol); });
            rate.Wait();
            if (assets != null)
            {
                Mediator.Supply = assets.supply;
                Mediator.Price = assets.priceUsd;
            }
        }
    }
}
