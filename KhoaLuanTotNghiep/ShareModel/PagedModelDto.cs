using System.Collections.Generic;

namespace ShareModel
{
    public class PagedModelDto<TModel>
    {
        public IList<TModel> Items { get; set; }

        public PagedModelDto()
        {
            Items = new List<TModel>();
        }
    }
}
