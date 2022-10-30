using COP3855_Project.Controllers;
using COP3855_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COP3855_Project.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public virtual void AddItem(Vehicle vehicle, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Vehicle.ID == vehicle.ID).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Vehicle = vehicle,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        } 
        public virtual void RemoveLine(Vehicle vehicle) => lineCollection.RemoveAll(l => l.Vehicle.ID == vehicle.ID);
        public virtual decimal ComputeTotalValue() => lineCollection.Sum(e => e.Vehicle.BasePrice * e.Quantity);
        public virtual void Clear() => lineCollection.Clear(); public virtual IEnumerable<CartLine> Lines => lineCollection;
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Vehicle Vehicle { get; set; }
        public int Quantity { get; set; }
    }
}