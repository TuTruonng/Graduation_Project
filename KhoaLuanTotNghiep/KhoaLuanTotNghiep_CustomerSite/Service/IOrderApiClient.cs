using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Service
{
    public interface IOrderApiClient
    {
        Task<bool> Order(string RealEstateId, string name);
        Task<IEnumerable<OrderModel>> GetOrders(string name);
    }
}
