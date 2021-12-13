using System;
using System.Collections.Generic;

namespace KhoaLuanTotNghiep_BackEnd.Models
{
    public class RealEstate
    {
        public string RealEstateID { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Acgreage { get; set; }
        public bool Approve { get; set; }
        public bool Status { get; set; }
        public string Location { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public string UserID { get; set; }
        public string AdminID { get; set; }
        public string CategoryID { get; set; }
        public string ReportID { get; set; }

        public virtual Category category { get; set; }
        public virtual User user { get; set; }
        public virtual User admin { get; set; }
        public virtual List<Report> reports { get; set; }

    }
}
