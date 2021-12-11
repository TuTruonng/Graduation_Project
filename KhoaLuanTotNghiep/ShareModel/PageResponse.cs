using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel
{
    public class PageResponse<Tmodel> : BaseQueryCriteriaDto
    {
        public int TotalItems { get; set; }
        public IEnumerable<Tmodel> Items { get; set; }
    }
}
