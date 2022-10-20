using System.Collections.Generic;
using COP3855_Project.Models;

namespace COP3855_Project.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Vehicle> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}