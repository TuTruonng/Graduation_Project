using KhoaLuanTotNghiep_CustomerSite.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchApiClient _searchApiClient;

        public SearchController(ISearchApiClient searchApiClient)
        {
            _searchApiClient = searchApiClient;
        }


        [HttpGet]
        public async Task<IActionResult> SearchRealEstate(string query)
        {
            if (query == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var result = await _searchApiClient.Search(query);
            if (result == null)
                return NotFound();
            return View(result);
        }
    }
}
