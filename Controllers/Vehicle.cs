using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections;
using Tuskla.Models;
using Tuskla.Models.ViewModels;

namespace Tuskla.Controllers
{
    public class Vehicle : Controller
    {
        ArrayList vehicleItems = new ArrayList();
        private IProductRepository repository;
        public Vehicle(IProductRepository repo)
        {
            repository = repo;
        }
        public void AddItem(Product product) => vehicleItems.Add(product);
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


            return View(new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => p.Category.StartsWith("Car") && p.isActive == true)
                    .OrderBy(p => p.ProductID)
            });
        }
    }
}
