using KhoaLuanTotNghiep_CustomerSite.Service;
using Microsoft.AspNetCore.Http;
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


        [Route("Order/OrderWaitingAccept")]
        public async Task<IActionResult> Orders()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            if (HttpContext.Session.GetString("JWToken") == null)
            {
                return RedirectToAction("Login", "Authen");

            }
            var name = HttpContext.Session.GetString("Username");
            var result = await _orderApiClient.GetOrders(name);
            //TempData["SuccessMessage"] = "Gửi thông tin đơn hàng thành công";
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Ordering(string id, string name)
        {
            if (!ModelState.IsValid || id is null)
            {
                return NotFound();
            }
            if (HttpContext.Session.GetString("JWToken") == null)
            {
                return RedirectToAction("Login", "Authen");

            }
            name = HttpContext.Session.GetString("Username");
            var result = await _orderApiClient.Order(id, name);
            if (result == false)
            {
                TempData["FailMessage"] = "Giao dịch đã được thực hiện!";
                return RedirectToAction("Details", "RealEstate");
            }
            TempData["SuccessMessage"] = "Gửi thông tin đơn hàng thành công";
            return RedirectToAction("Index", "Home");
        }
    }
}
