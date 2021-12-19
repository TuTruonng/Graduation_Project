using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Service
{
    public interface IRealEstateApiClient
    {
        //Task<PageResponse<RealEstateModel>> GetProductAsync(RealEstateCriteria realCriteria);

        Task<IEnumerable<RealEstateModel>> GetProducts();

        Task<RealEstateModel> GetProductById(string id);

        Task<IEnumerable<RealEstatefromCategory>> GetProductByCategory(string category);

        Task<bool> CreateRealEstates(RealEstateCreateRequest realEstateModel);

        Task<IList<RateResponse>> GetListRatings();

        Task<bool> Rating(string productId, int values);

     //   Task<IEnumerable<RealEstateModel>> Search(string query);


    }
}
