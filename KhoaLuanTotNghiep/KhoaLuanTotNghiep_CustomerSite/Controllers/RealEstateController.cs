using AutoMapper;
using KhoaLuanTotNghiep_CustomerSite.Service;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly IRealEstateApiClient _realestateApiClient;


        public RealEstateController(IRealEstateApiClient productApiClient)
        {
            _realestateApiClient = productApiClient;

        }

        [Route("/RealEstate")]
        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _realestateApiClient.GetProducts();
            if (result == null)
                return NotFound();
            return View(result);
        }



        [Route("/RealEstate/Create")]
        public async Task<IActionResult> Create([FromForm] RealEstateCreateRequest realEstateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(realEstateModel);
            }

            var result = await _realestateApiClient.CreateRealEstates(realEstateModel);
            if (result == false)
                return NotFound();
            return View(result);
        }



        [Route("/RealEstate/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            if (!ModelState.IsValid && string.IsNullOrEmpty(id))
            {
                return BadRequest(id);
            }

            var result = await _realestateApiClient.GetProductById(id);
            if (result == null)
                return NotFound();
            return View(result);
        }

        [Route("/RealEstate/category{categoryName}")]
        public async Task<IActionResult> CategoryById(string categoryName)
        {
            if (!ModelState.IsValid && string.IsNullOrEmpty(categoryName))
            {
                return BadRequest();
            }

            var result = await _realestateApiClient.GetProductByCategory(categoryName);
            if (result == null)
                return NotFound();
            return View(result);
        }
        //[HttpPost]
        //public async Task<IActionResult> Ordering(string RealEstateId)
        //{
        //    if (!ModelState.IsValid || RealEstateId is null)
        //    {
        //        return NotFound();
        //    }

        //    var result = await _realestateApiClient.Ordering(RealEstateId);

        //    if (result is false)
        //    {
        //        return Content("false");
        //    }
        //    return RedirectToAction("Details", "RealEstate", new { id = RealEstateId });
        //}

        public async Task<IActionResult> Voting(string ProductID, int rating)
        {
            if (!ModelState.IsValid || ProductID is null)
            {
                return NotFound();
            }

            string uri_Redirect = Request.Headers["Referer"].ToString();
            var result = await _realestateApiClient.Rating(ProductID, rating);

            if (result is false)
            {
                return Content("false");
            }
            return Redirect(uri_Redirect);
        }

        [Route("/RealEstate/cart")]
        public async Task<IActionResult> addProductToCart(string id, int qty)
        {
            List<CardSessionModel> cart = HttpContext.Session.Get<List<CardSessionModel>>("UserCart");
            if (cart == null)
            {
                cart = new List<CardSessionModel>();
            }

            foreach (var item in cart)
            {
                if (item.RealEstateID == id)
                {
                    item.Quality += qty;
                    HttpContext.Session.Set<List<CardSessionModel>>("UserCart", cart);
                    Task.WaitAll(Task.Delay(2000));
                    return RedirectToAction("Details", "RealEstate", new { id = id });
                }
            }

            var product = await _realestateApiClient.GetProductById(id);
            var productItem = new CardSessionModel
            {
                RealEstateID = product.RealEstateID,
                Title = product.Title,
                Price = product.Price,
                Quality = qty,
                Image = product.Image,
                CategoryName = product.CategoryName,
                Location = product.Location,

            };

            cart.Add(productItem);
            HttpContext.Session.Set<List<CardSessionModel>>("UserCart", cart);

            Task.WaitAll(Task.Delay(2000));
            TempData["SuccessMessage"] = "Đăng tin thành công";
            return RedirectToAction("Details", "RealEstate", new { id = id });
        }

    }
}
