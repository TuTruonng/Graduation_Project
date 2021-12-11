using KhoaLuanTotNghiep_CustomerSite.ViewModel.RealEstate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.ViewModel
{
    public class searchModel
    {
        public PagedResponseVM<RealEstateViewModel> Products { get; set; }
    }
}
