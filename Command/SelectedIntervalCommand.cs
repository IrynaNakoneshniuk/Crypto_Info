using Crypto_Info.ApiData;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LiveCharts.Defaults;
using System.Drawing;
using System.Reflection;
using System.Windows;
using System.Diagnostics;

namespace Crypto_Info.Command
{
    public class SelectedIntervalCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private MainVM mainVM;
        public SelectedIntervalCommand(MainVM mainVM)
        {
            this.mainVM = mainVM;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Mediator._Interval = parameter.ToString();
            List<AssetsHistory> list = null;
            Task < List < AssetsHistory >> task= Task.Run(async()=> list=await FasadApi.Coincapcs.GetHistoryAssetsAsync(Mediator._Interval, Mediator._Name));
            task.Wait();
            mainVM.Supplay = Mediator.Supply;
            mainVM.Price = Mediator.Price;
            try
            {
                if (parameter.ToString() != null)
                {
                    ChartValues<decimal> line2 = new ChartValues<decimal>();
                    foreach (AssetsHistory assets in list)
                    {
                        line2.Add(assets.priceUsd);

                    }
                    mainVM.Series = new SeriesCollection()
            {
                new LineSeries()
                { DataLabels = true, Values = line2, Title="Price" }
                  };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
