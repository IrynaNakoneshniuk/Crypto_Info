using System;


namespace Crypto_Info.ApiData.MarketsF
{
    public class Candles
    {
        public decimal ? open { get; set; }
        public decimal? high { get; set; }
        public decimal? low  { get; set; }
        public decimal? close { get; set; }
        public decimal? volume { get; set; }
        public long? period { get; set; }
    }
}
