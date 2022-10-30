using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SportsStore.Infrastructure;
namespace COP3855_Project.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart(); cart.Session = session; 
            return cart;
        }
        [JsonIgnore] public ISession Session { get; set; }
        public override void AddItem(Vehicle vehicle, int quantity)
        {
            base.AddItem(vehicle, quantity); Session.SetJson("Cart", this);
        }
        public override void RemoveLine(Vehicle vehicle)
        {
            base.RemoveLine(vehicle); Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear(); Session.Remove("Cart");
        }
    }
}