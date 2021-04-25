using GiphyWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GiphyWebApi.Data
{
    public class Giphy
    {
        private static readonly HttpClient HttpClient;
        private const string ApiKey = "D4bW8des8yJ1Nw9ZphmqXawD218osoXj";
        private const string GiphyUrl = "http://api.giphy.com/v1/gifs";

        static Giphy()
        {
            HttpClient = new HttpClient();
        }

        public static async Task<GiphyResult> FetchSearchData(string query)
        {
            var searchUrl = new Uri($"{GiphyUrl}/search?api_key={ApiKey}&q={query}");
            return await FetchData(searchUrl);
        }

        public static async Task<GiphyResult> FetchTrendingData()
        {
            var trendingUrl = new Uri($"{GiphyUrl}/trending?api_key={ApiKey}");
            return await FetchData(trendingUrl);
        }

        private static async Task<GiphyResult> FetchData(Uri uri)
        {
            try
            {
                string responseBody = await HttpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<GiphyResult>(responseBody);
            }
            catch (HttpRequestException e)
            {
                throw new WebException($"Failed to fetch GIFs data: {e.Message}");
            }
        }

    }
}