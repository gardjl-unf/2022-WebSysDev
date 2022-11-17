﻿using System;
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