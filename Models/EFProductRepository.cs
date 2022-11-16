using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuskla.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext context;
        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<ProductModelView> Products => context.Products;
        public void SaveProduct(ProductModelView product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                ProductModelView dbEntry = context.Products
                    .FirstOrDefault(p => p.ProductID == product.ProductID);
                if (dbEntry != null)
                {
                    
                dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                    dbEntry.isActive = true;
                }
            }
            context.SaveChanges();
        }
        public ProductModelView DeleteProduct(int productID)
        {
            ProductModelView dbEntry = context.Products
                .FirstOrDefault(p => p.ProductID == productID);
            if (dbEntry != null)
            {
                dbEntry.isActive = false;
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
