using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EVehiclesB.Models
{
    public class FakeProductRepository /* : IProductRepository*/
    {
        public IEnumerable<ProductModelView> Products => new List<ProductModelView> {
 new ProductModelView { Name = "Football", Price = 25 },
 new ProductModelView { Name = "Surf board", Price = 179 },
 new ProductModelView { Name = "Running shoes", Price = 95 }
 };
    }
}