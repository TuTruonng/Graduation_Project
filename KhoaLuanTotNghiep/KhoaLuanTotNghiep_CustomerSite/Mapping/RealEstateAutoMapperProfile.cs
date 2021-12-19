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

            //CreateMap<CreateUserDto, User>() // <Source, Dest>
            //    .ForMember(dst => dst.FullName, opt => opt.MapFrom(
            //        src => string.Format("{0} {1}", src.FirstName, src.LastName)))
            //    .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.FirstName))
            //    .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
            //    .ForMember(dst => dst.DOB, opt => opt.MapFrom(src => src.DateOfBirth))
            //    .ForMember(dst => dst.JoinedDate, opt => opt.MapFrom(src => src.JoinedDate))
            //    .ForMember(dst => dst.Gender, opt => opt.MapFrom(src => src.Gender))
            //    .ForMember(dst => dst.Location, opt => opt.MapFrom(src => src.Location))
            //    .ForMember(dst => dst.Status, opt => opt.MapFrom(src => true)) // True - Not disable
            //    .ForMember(dst => dst.ChangePassword, opt => opt.MapFrom(src => false)) // False - Require to change password after login
            //    .ForAllOtherMembers(opt => opt.Ignore());
            CreateMap<BaseQueryCriteriaDto, BaseQueryCriteriaVM>().ReverseMap();
            CreateMap<PageResponse<RealEstateModel>, PagedResponseVM<RealEstateViewModel>>().ReverseMap();
        }
    }
}
