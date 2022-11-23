using Tuskla.Models;
namespace Tuskla.Models.ViewModels
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public virtual void ClearCart() => Cart.Clear();
    }
}