using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Tuskla.Models;
using Tuskla.Models.ViewModels;

namespace Tuskla.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private Cart cart;
        public CartController(IProductRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public ViewResult DisplayCart(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToActionResult DeleteAllCart()
        {

            cart.Clear();

            return RedirectToAction("Index", "Vehicle");

        }

        public RedirectToActionResult AddItem(int productId, string returnUrl)
        {
            ProductModelView product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            ProductModelView product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.RemoveItem(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
 
}
