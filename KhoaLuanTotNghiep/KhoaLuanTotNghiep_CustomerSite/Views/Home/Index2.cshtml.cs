
using System.Threading.Tasks;
using AutoMapper;
using KhoaLuanTotNghiep_CustomerSite.Service;
using KhoaLuanTotNghiep_CustomerSite.ViewModel;
using KhoaLuanTotNghiep_CustomerSite.ViewModel.Brand;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using ShareModel;
using ShareModel.Constant;

namespace KhoaLuanTotNghiep_CustomerSite.Views.Home
{
    public class IndexModel : PageModel
    {
        private readonly IRealEstateApiClient _realEstateService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public IndexModel(
            IRealEstateApiClient realEstateService,
            IConfiguration config,
            IMapper mapper)
        {
            _realEstateService = realEstateService;
            _config = config;
            _mapper = mapper;
        }

        public PagedResponseVM<RealEstateModel> realEstates { get; set; }
        //public async Task OnGetAsync(string sortOrder,
        //    string currentFilter, string searchString, int? pageIndex)
        //{
        //    var realEstateCriteriaDto = new RealEstateCriteriaDto()
        //    {
        //        Search = searchString,
        //        SortOrder = SortOrderEnum.Accsending,
        //        Page = pageIndex ?? 1,
        //        Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
        //    };
        //    var pagedBrands = await _realEstateService.GetProducts(realEstateCriteriaDto);
        //    realEstates = _mapper.Map<PagedResponseVM<RealEstateModel>>(pagedBrands);
        //}
    }
}
