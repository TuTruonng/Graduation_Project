using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel
{
    public class RealEstateCreateRequest
    {
        public string RealEstateID { get; set; }

        public string CategoryID { get; set; }

        public string UserID { get; set; }

        public string ReportID { get; set; }

        public string Title { get; set; }

        public string Price { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Acgreage { get; set; }

        public bool Approve { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public bool Status { get; set; }


        public string Location { get; set; }


    }
}
