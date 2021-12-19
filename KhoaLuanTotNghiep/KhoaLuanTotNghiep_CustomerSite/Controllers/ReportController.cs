using KhoaLuanTotNghiep_CustomerSite.Service;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;

namespace KhoaLuanTotNghiep_CustomerSite.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportApiClient _reportApiClient;

        public ReportController(IReportApiClient reportApiClient)
        {
            _reportApiClient = reportApiClient;
        }

        [HttpPost]
        public async Task<IActionResult> Reporting(string id, string status)
        {
            var commentCreateRequest = new CreateReport
            {
                RealEstateID = id,
                Status = status,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
            };

            await _reportApiClient.CreateReport(commentCreateRequest);
            TempData["SuccessMessage"] = "Gửi đánh giá thành công";
            return RedirectToAction("Details", "RealEstate", new { id = commentCreateRequest.RealEstateID });
        }
    }
}
