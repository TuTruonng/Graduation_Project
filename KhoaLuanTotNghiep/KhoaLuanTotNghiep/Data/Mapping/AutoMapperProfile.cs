using AutoMapper;
using KhoaLuanTotNghiep_BackEnd.Models;
using ShareModel;

namespace KhoaLuanTotNghiep_BackEnd.Data.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RealEstate, RealEstateModel>();
            //CreateMap<Rating, RatingDto>();
            //CreateMap<Category, CategoryDto>();
        }
    }
}
