using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Service
{
    public interface IReportApiClient
    {
        Task<bool> CreateReport(CreateReport reportModel);
    }
}
