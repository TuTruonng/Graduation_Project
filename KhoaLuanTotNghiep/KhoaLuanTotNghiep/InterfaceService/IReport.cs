using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.InterfaceService
{
    public interface IReport
    {
        Task<ICollection<ReportExcel>> ExportReportAsync(ReportExcel reportRequest);

        Task<ICollection<ReportModel>> GetReportByUserNameAsync(string userName);

        Task<CreateReport> CreateReportAsync(CreateReport reportModel);

        Task<bool> DeleteReportAsync(string id);
    }
}
