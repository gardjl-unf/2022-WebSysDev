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

        public ViewResult DisplayCarCart(string returnUrl)
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

        public RedirectToActionResult AddToCartItems(int productId, string returnUrl)
        {
            ProductModelView product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("DisplayCart", new { returnUrl });
        }


        public RedirectToActionResult AddToCartVehicleItems(int productId, string returnUrl)
        {
            ProductModelView product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);


            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            string category = product.Name;
            string nextItem;

            if (!String.IsNullOrEmpty(product.Name))
            {

                if (product.Name.Substring(0, 3) == "Mod")
                {
                    nextItem = product.Name.Substring(0, 5);
                }

                else
                {
                    nextItem = category;

                }

                switch (nextItem)

                {
                    case "Model":
                        category = "Paint";
                        break;

                    case "Paint":
                        category = "Interior";
                        break;

                    case "Interior":
                        category = "Rims";
                        break;

                    case "Rims":
                        category = "AutoPilot";
                        break;

                    case "AutoPilot":
                        category = "FullSelfDriving";
                        break;



                    case "FullSelfDriving":
                        return RedirectToAction("DisplayCarCart", "Cart");
                        break;


                }

                return RedirectToAction("AddVehicleItem", "Product", new { category = category });

            }
            return RedirectToAction("DisplayCarCart", "Cart");

        }
        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            ProductModelView product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.RemoveItem(product);
            }
            return RedirectToAction("DisplayCart", new { returnUrl });
        }
    }
 
}
