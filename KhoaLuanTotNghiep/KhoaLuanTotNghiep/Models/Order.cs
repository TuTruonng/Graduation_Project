using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public string RealestateId { get; set; }
        public string UserId { get; set; }
        public string AdminId { get; set; }

        public virtual User user { get; set; }
        public virtual User admin { get; set; }
        public virtual RealEstate realEstate { get; set; }

    }
}
