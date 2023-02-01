using System;
using System.Data;

namespace Crypto_Info.ApiData.MarketsF
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
        public long? updated { get; set; } 
    }
}
