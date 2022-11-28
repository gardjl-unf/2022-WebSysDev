using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public virtual void RemoveItem(ProductModelView product)
        {
            if (product.Category == "Car")
            {
                lineCollection.RemoveAll(l => l.Product.Category == product.Category);
            }
            else
            {
                lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
            }
        }
        public virtual decimal ComputeSubtotalValue() => lineCollection.Sum(e => e.Product.Price * e.Quantity);
        public virtual decimal ComputeShippingValue() => ComputeSubtotalValue() > 40000M ? 2500M : ComputeSubtotalValue() > 50M ? 10M : 0;
        public virtual decimal ComputeTaxValue() => ComputeSubtotalValue() * 0.07M;
        public virtual decimal ComputeTotalValue() => ComputeSubtotalValue() * 1.07M + ComputeShippingValue();
        public virtual List<decimal> ComputePaymentOption()
        {
            bool containsCar = false;
            // Total with Deposit, Remaining Balance
            List<decimal> totals = new List<decimal> { 0.0M, 0.0M };
            decimal shippingSubtotal = 0.0M;
            foreach (var line in lineCollection)
            {
                if (line.Product.Category == "Car")
                {
                    if (!containsCar)
                    {
                        containsCar ^= true;
                        totals[0] += 250M;
                        totals[1] += line.Product.Price * 1.07M - 250M;
                    }
                    else
                    {
                        totals[1] += line.Product.Price * 1.07M;
                    }
                }
                else
                {
                    totals[0] += line.Product.Price * 1.07M;
                    shippingSubtotal += line.Product.Price;
                }
            }
            totals[0] += containsCar ? 0.0M : ComputeShippingValue();
            if(containsCar) { totals[1] += 2500M; }
            else { totals[1] += shippingSubtotal > 50M ? 10M : 0M; }
            return totals;
        }
        public virtual int CartItems() { return lineCollection.Count; }
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