using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Service
{
    public interface INewsApiClient
    {
        Task<IEnumerable<NewsModel>> GetNews();

        Task<NewsModel> GetNewsById(string id);
    }
}
