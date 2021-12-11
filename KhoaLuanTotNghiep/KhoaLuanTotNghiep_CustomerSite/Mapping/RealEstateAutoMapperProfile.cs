using AutoMapper;
using KhoaLuanTotNghiep_CustomerSite.ViewModel;
using KhoaLuanTotNghiep_CustomerSite.ViewModel.RealEstate;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Mapping
{
    public class RealEstateAutoMapperProfile : Profile
    {
        public RealEstateAutoMapperProfile()
        {
            CreateMap<RealEstateCreateRequest, RealEstateViewModel>().ReverseMap();
            CreateMap<BaseQueryCriteriaDto, BaseQueryCriteriaVM>().ReverseMap();
            CreateMap<PageResponse<RealEstateModel>, PagedResponseVM<RealEstateViewModel>>().ReverseMap();
        }
    }
}
