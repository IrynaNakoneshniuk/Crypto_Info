using Crypto;
using Crypto_Info.ApiData;
using Crypto_Info.ApiData.ApiClient;
using Crypto_Info.ApiData.MarketsF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Crypto_Info
{
    public static class FasadApi
    {
        public static List<Assets> ListAssets { get; set; }=new List<Assets>();
        public static List<Icon> IconAssets { get; set; }=new List<Icon>() { };
        public static List<PopularAssets> PopularAssets { get; set; } = new List<PopularAssets>();
        public static List<Markets> Marketplace { get; set; }= new List<Markets>();
        public static ApiRestClientCoincapcs  Coincapcs { get; set; } =new ApiRestClientCoincapcs();
        public static ApiRestClient ApiRestClient { get; set; } = new ApiRestClient();

        public static async Task IniLists()
        {
            ListAssets = await Coincapcs.GetAssetsAsync();
            IconAssets = await  ApiRestClient.List_Assets_IconsAsync(32);
            Marketplace = await Coincapcs.GetMarketsAsync();
        }

        public static List<PopularAssets> GetListIconAssetsPopular()
        {
            Task t=Task.Run(async () => { await IniLists(); });
            t.Wait();   
            for (int i = 0; i < ListAssets.Count; i++)
            {
                var tmp = (from k in IconAssets
                           where k.asset_id == ListAssets[i].symbol
                           select k).FirstOrDefault();
                if (tmp != null)
                {
                    Brush solid = (ListAssets[i].changePercent24Hr < 0) ? Brushes.Red : Brushes.GreenYellow;

                    PopularAssets.Add(new PopularAssets(ListAssets[i].name, ListAssets[i].changePercent24Hr, tmp.url, solid));
                }
            }
            return PopularAssets;
        }
    }
}
