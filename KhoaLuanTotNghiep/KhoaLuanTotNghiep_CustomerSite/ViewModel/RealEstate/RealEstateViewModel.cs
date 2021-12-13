
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.ViewModel.RealEstate
{
    public class RealEstateViewModel
    {
        public string RealEstateID { get; set; }

        public string CategoryID { get; set; }

        public string UserID { get; set; }
        public string CategoryName { get; set; }

        public string ReportID { get; set; }

        public string Title { get; set; }

        public string Price { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Acgreage { get; set; }

        public string Slug { get; set; }

        public int Approve { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public string Status { get; set; }

        public int PhoneNumber { get; set; }

        public string Location { get; set; }


    }
}
