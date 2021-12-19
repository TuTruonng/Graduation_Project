using ShareModel;
using ShareModel.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Service
{
    public class NewsApiCLient : INewsApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        //private readonly IConfiguration _configuration;

        public NewsApiCLient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            // _configuration = configuration;

        }

        public async Task<IEnumerable<NewsModel>> GetNews()
        {
            var client = _httpClientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
            var response = await client.GetAsync(EndpointConstants.GET_NEWS);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<NewsModel>>();

        }

        public async Task<NewsModel> GetNewsById(string id)
        {
            var client = _httpClientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
            var response = await client.GetAsync($"{EndpointConstants.GET_NEWS}\\{id}");
            response.EnsureSuccessStatusCode();
            var news= await response.Content.ReadAsAsync<NewsModel>();
            return news;
        }
    }
}
