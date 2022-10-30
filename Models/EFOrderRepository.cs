using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace COP3855_Project.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext context; 
        public EFOrderRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Order> Orders => context.Orders.Include(o => o.Lines).ThenInclude(l => l.Vehicle);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Vehicle)); 
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}