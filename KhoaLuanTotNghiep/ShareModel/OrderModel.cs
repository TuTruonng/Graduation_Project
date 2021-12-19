using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel
{
    public class OrderModel
    {
        public string OrderId { get; set; }
        public string RealEstateId { get; set; }
        public string UserName { get; set; }
        public string AdminName { get; set; }
        public string Title { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
