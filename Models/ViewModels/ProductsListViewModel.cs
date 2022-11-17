using System.Collections.Generic;
using Tuskla.Models;

namespace Tuskla.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductModelView> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }    
    }
}
