using Microsoft.AspNetCore.Mvc;
namespace COP3855_Project.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("Index");
        }
    }
}