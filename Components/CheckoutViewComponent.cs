using Microsoft.AspNetCore.Mvc;
using Tuskla.Models;

namespace Tuskla.Components
{
    public class CheckoutViewComponent : ViewComponent
    {
        private Cart cart;
        public CheckoutViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}