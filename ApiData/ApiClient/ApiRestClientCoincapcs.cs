using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Crypto;
using Crypto_Info.ApiData.AssetsF;
using Crypto_Info.ApiData.ExchangesF;
using Crypto_Info.ApiData.RatesF;
using Crypto_Info.ApiData.MarketsF;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Crypto_Info.ApiData.ApiClient
{
    public class ApiRestClientCoincapcs
    {
        private string _url;

        public ApiRestClientCoincapcs()
        {
            _url = "https://api.coincap.io";
        }

        private async Task<T> GetData<T>(string url)
        {
            try
            {
                using (var handler = new HttpClientHandler())
                {
                    handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                    using (var client = new HttpClient(handler, false))
                    {

                        HttpResponseMessage response = await client.GetAsync(_url + url).ConfigureAwait(false);

                        return await DeserializeAsync<T>(response).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Unexpected error", e);
            }
        }
        private static async Task<T> DeserializeAsync<T>(HttpResponseMessage responseMessage)
        {
            try
            {
                var responseString = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                JObject Search = JObject.Parse(responseString);
                string jstr = Search["data"].ToString();
                return JsonConvert.DeserializeObject<T>(@jstr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }
        public  async Task<List<Assets>> GetAssetsAsync() => await GetData<List<Assets>>(ApiEndpointUrls.Assets());
        public async Task <Assets> GetAssetsByIdAsync(string idAssets)=> await GetData<Assets>(ApiEndpointUrls.AssetsById(idAssets));
        public async Task<List<Rates> > GetRatesAsync() => await GetData<List<Rates>>(ApiEndpointUrls.Rates());
        public async Task <Rates> GetRatesByIdAsync(string idRates)=>await GetData<Rates>(ApiEndpointUrls.RatesById(idRates));
        public async Task  <List<AssetsHistory>> GetHistoryAssetsAsync(string idAssets,string period) => await GetData<List<AssetsHistory>>(ApiEndpointUrls.HistoryAssets(idAssets, period));
        public async Task <List<AssetsMarkets>> GetInfoMarketsAsync(string idAssets)=>await GetData<List<AssetsMarkets>>(ApiEndpointUrls.AssetsMarkets(idAssets));
        public async Task <List<Exchanges>> ExchangesAsync()=> await GetData<List<Exchanges>>(ApiEndpointUrls.Exchange());
        public async Task <Exchanges> GetExchangesByIdAsync(string idExchanges) =>await GetData<Exchanges>(ApiEndpointUrls.ExchangeById(idExchanges));
        public async Task <List<Markets>> GetMarketsAsync()=> await GetData<List<Markets>>(ApiEndpointUrls.Markets());
        public async Task <List<Candles>> GetCandlesAsync(string exchange, string interval, string baseId, string quoteId)=> await GetData<List<Candles>>(ApiEndpointUrls.Candles(exchange,interval, baseId, quoteId));

    }
}
