using GiphyWebApi.Data;
using GiphyWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GiphyWebApi.Controllers
{
    public class GiphyController : ApiController
    {
        private static ConcurrentDictionary<string, List<string>> cache = new ConcurrentDictionary<string, List<string>>();

        [HttpGet]
        [Route("gifs/{searchTerm}")]
        public async Task<List<string>> SearchGifs(string searchTerm)
        {
            if(cache.ContainsKey(searchTerm))
            {
                return cache[searchTerm];
            }
            var data = await Giphy.FetchSearchData(searchTerm);
            List<string> urlList = new List<string>();
            foreach (var item in data.Data)
            {
                urlList.Add(item.Url);
            }
            cache.TryAdd(searchTerm, urlList);
            return urlList;
        }

        [HttpGet]
        [Route("gifs/trending")]
        public async Task<List<string>> TrendingGifs()
        {
            var data = await Giphy.FetchTrendingData();
            List<string> urlList = new List<string>();
            foreach (var item in data.Data)
            {
                urlList.Add(item.Url);
            }
            return urlList;
        }        

    }
}
