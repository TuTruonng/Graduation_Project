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
    public class ReportApiClient : IReportApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IConfiguration _configuration;

        public ReportApiClient(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            //_configuration = configuration;
        }
        public async Task<bool> CreateReport(CreateReport reportModel)
        {
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(reportModel), Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
            var response = await client.PostAsync(EndpointConstants.GET_REPORT, httpContent);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return await Task.FromResult(false);
            }
            response.EnsureSuccessStatusCode();

            return await Task.FromResult(true);
        }
    }
}
