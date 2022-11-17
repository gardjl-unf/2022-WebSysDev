using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Data;
using Tuskla.Models;
using Tuskla.Models.ViewModels;
using System;

namespace Tuskla.Controllers
{
    public class VehicleController : Controller
    {
        private IProductRepository repository;
        private Cart cart;
        public static string currentModel;
        public VehicleController(IProductRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }
        public ViewResult Index(string Model)
        {
            currentModel = Model;
            ViewBag.Logo = "../img/home/model-" + currentModel.Substring(6, 1).ToLower() + ".jpg";
            ViewBag.ModelType = currentModel.Substring(0, 7);
            ViewBag.ModelStandard = ViewBag.ModelType + " Standard";
            ViewBag.ModelPlaid = ViewBag.ModelType + " Plaid";

            return View("Index");
        }
        public ViewResult Design()
        {
            ViewBag.ModelImage = "../img/" + currentModel.Substring(6, 1).ToLower() + "/ext/18/white/front.jpg";
            ViewBag.ModelType = currentModel.Substring(0, 7);
            ViewBag.ModelName = currentModel;


            return View(new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => p.Category.StartsWith("Car") && p.isActive == true)
                    .OrderBy(p => p.ProductID)
            });
        }
        [HttpPost]
        public ActionResult Order()
        {
            ProductModelView product = new ProductModelView();

            cart.AddItem(product = repository.Products
                .FirstOrDefault(p => p.Name == currentModel), 1);
            int[] products = new int[] { 
                Int32.Parse(Request.Form["vehiclePaint"]), 
                Int32.Parse(Request.Form["vehicleInterior"]), 
                Int32.Parse(Request.Form["vehicleRims"]), 
                Int32.Parse(Request.Form["vehicleAutopilot"]), 
                Int32.Parse(Request.Form["vehicleFullSelfDriving"]) 
            };
            foreach (int productID in products)
            {
                cart.AddItem(product = repository.Products
                    .FirstOrDefault(p => p.ProductID == productID), 1);
            }

            return RedirectToAction("Index", "Vehicle", new { Model = currentModel });
        }
    }
}
