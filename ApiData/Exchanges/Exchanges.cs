using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Info.ApiData.Exchanges
{
    public class Exchanges
    {
        public string ? id { get; set; }
        public string? name { get; set; }
        public int ? rank { get; set; }
        public decimal? percentTotalVolume { get; set; }
        public decimal? volumeUsd { get; set;}
        public int ? tradingPairs { get; set; }
        public bool? socket { get; set; }
        public string ? exchangeUrl { get; set; }
        public TimeSpan? updated { get; set; }

    }
}
