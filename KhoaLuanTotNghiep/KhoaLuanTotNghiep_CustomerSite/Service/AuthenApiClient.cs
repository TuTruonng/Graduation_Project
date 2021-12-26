
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
    public class AuthenApiClient : IAuthenApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IConfiguration _configuration;

        public AuthenApiClient(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            //_configuration = configuration;
        }
        public async Task<TokenModel> Login(LoginModel Request)
        {
            var loginRequest = new LoginModel
            {
                Username = Request.Username,
                Password = Request.Password,
            };
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
            var response = await client.PostAsync($"{EndpointConstants.GET_AUTHEN}\\{"login/request"}", httpContent);
            // if (response.StatusCode == HttpStatusCode.BadRequest)
            if (response.Content == null)
            {
                //var token = await response.Content.ReadAsAsync<string>();
                return null;
                //return await Task.FromResult(false);
            }
            response.EnsureSuccessStatusCode();
            var token = await response.Content.ReadAsAsync<TokenModel>();
            return token;
            //return await Task.FromResult(true);
        }


        public async Task<bool> Register(RegisterRequest registerRequest)
        {
            var request = new RegisterRequest
            {
                UserName = registerRequest.UserName,
                Email = registerRequest.Email,
                FullName = registerRequest.FullName,
                PhoneNumber = registerRequest.PhoneNumber,
                Password = registerRequest.Password,
            };
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
            var response = await client.PostAsync($"{EndpointConstants.GET_AUTHEN}\\{"register/request"}", httpContent);
            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                return await Task.FromResult(false);
            }
            response.EnsureSuccessStatusCode();

            return await Task.FromResult(true);
        }
    }
}
