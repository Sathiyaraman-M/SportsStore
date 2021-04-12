using System.Collections.Generic;

namespace SportsStore.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo pagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}