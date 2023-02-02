using Crypto_Info.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto_Info
{
    public class ExchangerateVM : BaseVM
    {
        private ExchangeCurrentrate exchangeCurrentrate;
        public ICommand UpdateRates { get; set; }
        public ExchangeCurrentrate Exchange { get { return exchangeCurrentrate; } 
            set { exchangeCurrentrate = value; 
                OnPropertyChanged(nameof(Exchange));
          } }

        public ExchangerateVM()
        {
            this.exchangeCurrentrate = new ExchangeCurrentrate();
            UpdateRates = new UpdateExchageCommand(this);
        }
    }
}
