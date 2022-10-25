using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EVehiclesB.Models
{
    public interface IProductRepository
    {
        IEnumerable<ProductModelView> Products { get; }
        void SaveProduct(ProductModelView product);
        ProductModelView DeleteProduct(int productID);
    }
}
