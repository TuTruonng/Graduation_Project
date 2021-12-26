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
        Task<RealEstateCreateRequest> CreateRealEstatesAsync(RealEstateCreateRequest realEstateModel);
        Task<ListApprove> UpdateRealEstateAsync(string id, ListApprove realEstateModel);
        Task<bool> DeleteRealEstateModelAsync(string id);
        Task<IEnumerable<RealEstatefromCategory>> GetByCategoryAsync(string categoryname);
        Task<RealEstateDetail> GetByIdAsync(string id);
        Task<OrderModel> OrderAsync(OrderModel order);
        Task<IEnumerable<OrderModel>> GetOrderAsync();
        Task<IEnumerable<OrderModel>> GetOrderWaitingAcceptAsync(string username);
        Task<ICollection<RealEstateModel>> Search(string query);
        Task<AcceptOrder> UpdateOrderAsync(string id, AcceptOrder orderModel);
        Task<ICollection<OrderExcel>> ExportOrderAcceptedAsync();
        Task<ICollection<OrderExcel>> ExportOrderNotAcceptedAsync();

    }

}
