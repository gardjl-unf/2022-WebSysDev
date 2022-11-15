using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Tuskla.Controllers
{
    public class Vehicle : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult Index(string model)
        {

            ViewBag.Logo = "..//img//home-" + model.Substring(6, 1) + ".jpg";
            ViewBag.ModelType = model.Substring(0, 7);
            ViewBag.ModelButtonText = model.Split(' ').Last();
            
            return View("Design");
        }
    }
}
