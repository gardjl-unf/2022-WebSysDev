using Microsoft.AspNetCore.Mvc;

namespace COP3855_Project.Models
{
    public class Vehicle : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
