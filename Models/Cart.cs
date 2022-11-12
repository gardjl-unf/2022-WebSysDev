using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Tuskla.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public virtual void AddItem(ProductModelView product, int quantity)
        {
            CartLine line = lineCollection
            .Where(p => p.Product.ProductID == product.ProductID)
            .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(ProductModelView product) => lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        public virtual decimal ComputeTotalValue() => lineCollection.Sum(e => e.Product.Price * e.Quantity);
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;


    }
 
    
    public class CartLine
    {
        public int CartLineID { get; set; }
        public ProductModelView Product { get; set; }
        public int Quantity { get; set; }
    }
}