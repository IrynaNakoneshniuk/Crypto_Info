using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Info.ApiData.RatesF
{
    public class Rates
    {
        public string ? id { get; set; }
        public string ? symbol { get; set; }
        public string? currencySymbol { get; set; }
        public decimal ? rateUsd { get; set; }
        public string ? type { get; set; }
    }
}
