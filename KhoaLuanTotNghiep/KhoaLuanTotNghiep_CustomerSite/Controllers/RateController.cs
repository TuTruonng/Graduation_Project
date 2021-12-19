using KhoaLuanTotNghiep_CustomerSite.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Controllers
{
    public class RateController : Controller
    {
        private readonly IRealEstateApiClient _realEstateApiClient;

        public RateController(IRealEstateApiClient realEstateApiClient)
        {
            _realEstateApiClient = realEstateApiClient;
        }

       
    }
}
