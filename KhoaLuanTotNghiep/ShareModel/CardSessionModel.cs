using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel
{
  public  class CardSessionModel
    {
        public string RealEstateID { get; set; }

        public string CategoryName { get; set; }

        public string Title { get; set; }

        public string Price { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public DateTime CreateTime { get; set; }

        public int Quality { get; set; }

        public string Location { get; set; }

    }
}
