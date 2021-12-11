using KhoaLuanTotNghiep_CustomerSite.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.ViewComponents
{
    public class DropdownViewComponent : ViewComponent
    {
        private readonly ICategoryApiClient _categoryApiClient;

        public DropdownViewComponent(ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryApiClient.GetCategories();

            return View(categories);
        }

    }
}
