using KhoaLuanTotNghiep_CustomerSite.Service;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderApiClient _orderApiClient;

        public OrderController(IOrderApiClient orderApiClient)
        {
            _orderApiClient = orderApiClient;
        }


        [HttpPost]
        public async Task<IActionResult> Ordering(string id)
        {
            if (!ModelState.IsValid || id is null)
            {
                return NotFound();
            }

            var result = await _orderApiClient.Order(id);
            TempData["SuccessMessage"] = "Giao dịch thành công";
            return RedirectToAction("Details", "RealEstate", new { id = id });
        }
    }
}
