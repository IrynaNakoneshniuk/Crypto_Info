using System;

namespace Crypto
{
    public static class ApiEndpointUrls
    {
        public static string Assets() => "/v2/assets";
        public static string AssestsIcons(int iconSize) => ($"/v1/assets/icons/{iconSize}");
        public static string AssetsById(string id)=>($"/v2/assets/{id}");
        public static string HistoryAssets(string period, string idAssets) => ($"/v2/assets/{idAssets}/history?interval={period}");
        public static string Rates() => ("/v2/rates");
        public static string RatesById(string IdAssets) => ($"/v2/rates/{IdAssets}");
        public static string Exchange() => ("/v2/exchanges");
        public static string ExchangeById(string idExchange) => ($"/v2/exchanges/{idExchange}");
        public static string Markets() => ("/v2/markets");
        public static string AssetsMarkets(string IdAssets) => ($"/v2/assets/{IdAssets}/markets");
        public static string Candles(string exchange, string interval, string baseId, string quoteId) => ($"/v2/candles?exchange={exchange}&interval={interval}&baseId={baseId}&quoteId={quoteId}");
        public static string ExchangeRateSpecific(string baseId, string quoteId) => string.Format("/v1/exchangerate/{0}/{1}", baseId, quoteId);
    }
}

