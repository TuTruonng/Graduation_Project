using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.ViewModel
{
    public class BaseQueryCriteriaVM
    {
        public string Search { get; set; }
        public int Limit { get; set; } = 9;
        public int Page { get; set; } = 1;
    }
}
