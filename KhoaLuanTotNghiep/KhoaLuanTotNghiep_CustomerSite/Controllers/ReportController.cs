using KhoaLuanTotNghiep_CustomerSite.Service;
using Microsoft.AspNetCore.Http;
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

            if (HttpContext.Session.GetString("JWToken") == null)
            {
                return RedirectToAction("Login", "Authen");

            }
            //name = HttpContext.Session.GetString("Username");

            var result = await _reportApiClient.CreateReport(commentCreateRequest);
            if (result == false)
            {
                TempData["FailMessage"] = "Gửi đánh giá thành công";
                return RedirectToAction("Details", "RealEstate");
            }
            TempData["SuccessMessage"] = "Gửi đánh giá thành công";
            return RedirectToAction("Details", "RealEstate", new { id = commentCreateRequest.RealEstateID });
        }
    }
}
