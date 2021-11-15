using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Interface
{
    public interface IReports
    {
        Task<IEnumerable<ReportModel>> GetAllReportAsync();

        Task<ReportModel> CreateReportAsync(ReportModel reportModel);

        Task<bool> DeleteReportAsync(string id);
    }
}
