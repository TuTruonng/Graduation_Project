using KhoaLuanTotNghiep_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.InterfaceService
{
    public interface IRealEstate
    {
        Task<ICollection<RealEstateModel>> GetAllAsync();

        Task<ICollection<RealEstateModel>> GetByUserNameAsync(string userName);

        //Task<ActionResult<PageResponse<RealEstateModel>>> Getproduct(
        // [FromQuery] RealEstateCriteria productCriteriaDto,
        // CancellationToken cancellationToken);

        Task<RealEstateCreateRequest> CreateRealEstatesAsync(RealEstateCreateRequest realEstateModel);

        Task<ListApprove> UpdateRealEstateAsync(string id, ListApprove realEstateModel);

        Task<bool> DeleteRealEstateModelAsync(string id);

        Task<IEnumerable<RealEstatefromCategory>> GetByCategoryAsync(string categoryname);

        Task<RealEstateModel> GetByIdAsync(string id);
    }
}
