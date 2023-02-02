using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Crypto
{
    public class ApiRestClient
    {
        private string apikey;
        public string DateFormat => "yyyy-MM-ddTHH:mm:ss.fff";
        private string WebUrl = "https://rest.coinapi.io";
  
        public ApiRestClient(bool sandbox = true)
        {
            this.apikey = "BF221201-766D-4A57-8853-E5083DF93D2C";
            if (sandbox)
            {
                WebUrl = "https://rest-sandbox.coinapi.io";
            }
            this.WebUrl = WebUrl.TrimEnd('/');
        }

        public ApiRestClient(string apikey, string url)
        {
            this.apikey = apikey;
            this.WebUrl = url.TrimEnd('/');
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
                        client.DefaultRequestHeaders.Add("X-CoinAPI-Key", this.apikey);

                        HttpResponseMessage response = await client.GetAsync(WebUrl + url).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)

                        return await DeserializeAsync<T>(response).ConfigureAwait(false);
                        else
                        {
                            throw new Exception(response.StatusCode.ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Unexpected error", e);
            }
        }

        public async Task <List<Icon>> List_Assets_IconsAsync(int sizeIcon)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (var client = new RestClient("https://rest.coinapi.io"))
                    {
                        return DeserializeIcon(client, sizeIcon);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Unexpected error", e);
                }
            });
        }

        private List<Icon> DeserializeIcon(RestClient client, int iconSize)
        {
            List<Icon>? icons = new List<Icon>();
            try
            {
                var request = new RestRequest(ApiEndpointUrls.AssestsIcons(iconSize));
                request.AddHeader("X-CoinAPI-Key", "BF221201-766D-4A57-8853-E5083DF93D2C");
                RestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string jsonStr = response.Content;
                    icons = JsonConvert.DeserializeObject<List<Icon>>(jsonStr);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Unexpected error", e);
            }
            return icons;
        }
        private static async Task<T> DeserializeAsync<T>(HttpResponseMessage responseMessage)
        {
            try
            {
                var responseString = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<T>(responseString);
            }catch(Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        public async Task<Exchangerate> ExchangeRateAsync(string baseId, string qouteId)
        {
            try
            {
                var url = ApiEndpointUrls.ExchangeRateSpecific(baseId, qouteId);
                return await GetData<Exchangerate>(url);
            }catch(Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }
        public Task<ExchangeCurrentrate> ExchangeRatesGetAll(string baseId, bool invert = false)
        {
            var url = ApiEndpointUrls.ExchangeRate(baseId, invert);
            return GetData<ExchangeCurrentrate>(url);
        }
    }

}
    
