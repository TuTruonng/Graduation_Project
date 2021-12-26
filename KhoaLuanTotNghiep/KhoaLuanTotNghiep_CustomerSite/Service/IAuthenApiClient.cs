
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Service
{
    public interface IAuthenApiClient
    {
        Task<TokenModel> Login(LoginModel loginRequest);

        Task<bool> Register(RegisterRequest registerRequest);
    }
}
