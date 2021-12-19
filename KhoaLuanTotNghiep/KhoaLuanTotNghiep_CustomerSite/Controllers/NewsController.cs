using KhoaLuanTotNghiep_CustomerSite.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsApiClient _newsApiClient;

        public NewsController(INewsApiClient newsApiClient)
        {
            _newsApiClient = newsApiClient;
        }

        [Route("/News")]
        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _newsApiClient.GetNews();
            if (result == null)
                return NotFound();
            return View(result);
        }

        [Route("/News/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            if (!ModelState.IsValid && string.IsNullOrEmpty(id))
            {
                return BadRequest(id);
            }

            var result = await _newsApiClient.GetNewsById(id);
            if (result == null)
                return NotFound();
            return View(result);
        }
    }
}
