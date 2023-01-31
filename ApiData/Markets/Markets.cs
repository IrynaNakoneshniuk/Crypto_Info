using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Info.ApiData.Markets
{
    public class Markets
    {
        public string ? exchangeId { get; set; }
        public int ? rank { get; set; }
        public string?  baseSymbol { get; set; }
        public string ? baseId { get; set; }
        public string? quoteSymbol { get; set; }
        public string? quoteId { get; set;}
        public decimal priceQuote { get; set; }
        public decimal priceUsd { get; set; }
        public int ? tradesCount24Hr { get; set; }
        public TimeSpan ? updated { get; set; } 
    }
}
