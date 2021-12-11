using AutoMapper;
using KhoaLuanTotNghiep_CustomerSite.Models;
using KhoaLuanTotNghiep_CustomerSite.Service;
using KhoaLuanTotNghiep_CustomerSite.ViewModel;
using KhoaLuanTotNghiep_CustomerSite.ViewModel.RealEstate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShareModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRealEstateApiClient _realestateApiClient;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IRealEstateApiClient productApiClient, IMapper mapper)
        {
            _logger = logger;
            _realestateApiClient = productApiClient;
            _mapper = mapper;
            _configuration = configuration;
        }

        //public async Task<IActionResult> Index(string currentFilter, string? searchString)
        //{
        //    var productCriteriaDto = new RealEstateCriteria()
        //    {
        //        Search = searchString,
        //    };
        //    var pagedProducts = await _realestateApiClient.GetProductAsync(productCriteriaDto);
        //    // var Products = new PagedResponseVM<RealEstateViewModel>();
        //    var pro = new searchModel()
        //    {
        //        Products = _mapper.Map<PagedResponseVM<RealEstateViewModel>>(pagedProducts)
        //    };

        //    //var results = await _realestateApiClient.GetProducts();
        //    return View(pro);
        //}

        public async Task<IActionResult> Index(string cate)
        {

            var pagedProducts = await _realestateApiClient.GetProducts();
            // var Products = new PagedResponseVM<RealEstateViewModel>();
            //var pro = new searchModel()
            //{
            //    Products = _mapper.Map<PagedResponseVM<RealEstateViewModel>>(pagedProducts)
            //};

            //var results = await _realestateApiClient.GetProducts();
            return View(pagedProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
