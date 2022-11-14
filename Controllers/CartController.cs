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

        public ViewResult Index2(string returnUrl)
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

            return RedirectToAction("IndexModelStart", "Product");

        }

        public RedirectToActionResult AddToCartItems(int productId, string returnUrl)
        {
            ProductModelView product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
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
                        return RedirectToAction("Index2", "Cart");
                        break;


                }

                return RedirectToAction("AddVehicleItem", "Product", new { category = category });

            }
            return RedirectToAction("Index2", "Cart");

        }
        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            ProductModelView product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
 
}
