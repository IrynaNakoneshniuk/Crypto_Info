using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Info.ApiData.AssetsF
{
    public class AssetsMarkets
    {
        public string ? exchangeId { get; set; }
        public string ? baseId { get; set; }
        public string ?quoteId { get; set; }
        public string ? baseSymbol { get; set; }
        public string ? quoteSymbol { get; set; }
        public decimal ? volumeUsd24Hr { get; set; }
        public decimal? priceUsd { get; set; }
        public decimal? volumePercent { get; set; }
    }
}
