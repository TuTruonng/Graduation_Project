using KhoaLuanTotNghiep_CustomerSite.Service;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Controllers
{
    public class CartSessionController : Controller
    {
        [Route("Cart/cart")]
        public IActionResult Index()
        {
            var result = HttpContext.Session.Get<List<CardSessionModel>>("UserCart");
            if (result == null)
            {
                result = new List<CardSessionModel>();
            }
            return View(result);
        }

        public IActionResult Delete(int id)
        {
            List<CardSessionModel> cart = HttpContext.Session.Get<List<CardSessionModel>>("UserCart");

            var deleteMe = cart.Find(x => x.RealEstateID == id.ToString());

            cart.Remove(deleteMe);
            HttpContext.Session.Set("UserCart", cart);
            Task.WaitAll(Task.Delay(2000));
            return RedirectToAction("Index", "CartSession");
        }

    }
}
