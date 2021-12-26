using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ShareModel;
using ShareModel.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Service
{
    public class OrderApiClient : IOrderApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IConfiguration _configuration;

        public OrderApiClient(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            //_configuration = configuration;
        }

        public async Task<IEnumerable<OrderModel>> GetOrders(string name)
        {
            var client = _httpClientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
            var response = await client.GetAsync($"{EndpointConstants.GET_REALESTATES}\\{"Order/=" + name}");
            response.EnsureSuccessStatusCode();
            var list = await response.Content.ReadAsAsync<IEnumerable<OrderModel>>();
            return list;
        }

        public async Task<bool> Order(string RealEstateId, string name)
        {
            var Request = new OrderModel
            {
                RealEstateID = RealEstateId,
                UserName = name,
            };
            var json = JsonConvert.SerializeObject(Request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
            var response = await client.PostAsync($"{EndpointConstants.GET_REALESTATES}\\{"RealEstateId=" + RealEstateId}", data);
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.InternalServerError)
            {
                return await Task.FromResult(false);
            }
            response.EnsureSuccessStatusCode();

            return await Task.FromResult(true);
        }
    }
}
