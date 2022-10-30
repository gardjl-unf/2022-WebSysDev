using System.Linq;
using Microsoft.AspNetCore.Mvc;
using COP3855_Project.Models;
using COP3855_Project.Models.ViewModels;

namespace COP3855_Project.Controllers
{
    public class CartController : Controller
    {
        private IVehicleRepository repository; private Cart cart;
        public CartController(IVehicleRepository repo, Cart cartService)
        {
            repository = repo; cart = cartService;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToActionResult AddToCart(int vehicleID, string returnUrl)
        {
            Vehicle vehicle = repository.Vehicles.FirstOrDefault(v => v.ID == vehicleID);
            if (vehicle != null)
            {
                cart.AddItem(vehicle, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int vehicleId, string returnUrl)
        {
            Vehicle vehicle = repository.Vehicles.FirstOrDefault(v => v.ID == vehicleId);
            if (vehicle != null)
            {
                cart.RemoveLine(vehicle);
            }
            return RedirectToAction("Index", new { returnUrl });
        } 
    }
}