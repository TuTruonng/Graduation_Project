using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel
{
    public class OrderDetail
    {
        public string OrderId { get; set; }
        public string UserID { get; set; }
        public string AdminID { get; set; }
        public string RealEatateID { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
