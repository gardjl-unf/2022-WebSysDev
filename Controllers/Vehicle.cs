using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections;
using Tuskla.Models;
using Tuskla.Models.ViewModels;
using System.Data.Common;

namespace Tuskla.Controllers
{
    public class VehicleController : Controller
    {
        private IProductRepository repository;
        public VehicleController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(string Model)
        {
            ViewBag.Logo = "../img/home/model-" + Model.Substring(6, 1).ToLower() + ".jpg";
            ViewBag.ModelType = Model.Substring(0, 7);
            ViewBag.ModelStandard = ViewBag.ModelType + " Standard";
            ViewBag.ModelPlaid = ViewBag.ModelType + " Plaid";

            return View("Index");
        }
        public ViewResult Design(string Model)
        {
            ViewBag.ModelImage = "../img/" + Model.Substring(6, 1).ToLower() + "/ext/18/white/front.jpg";
            ViewBag.ModelType = Model.Substring(0, 7);
            ViewBag.ModelButtonText = Model.Split(' ').Last();
            ViewBag.ModelName = Model;


            return View(new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => p.Category.StartsWith("Car") && p.isActive == true)
                    .OrderBy(p => p.ProductID)
            });
        }
        [HttpPost]
        public ViewResult Order(string Model)
        {
            Cart.AddItem(repository.Products.Where(p => p.Name == Model), 1);
            foreach (int productID in Request.Query.ToArray)
            {
                foreach (Product product in repository.Products.Where(p => p.ProductID == productID))
                {
                    Cart.AddItem(product, 1);
                }
            }

            return View(Design(Model));
        }
    }
}
