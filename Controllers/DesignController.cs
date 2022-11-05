using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace COP3855_Project.Controllers
{
    public class DesignController : Controller
    {
        public ViewResult Index()
        {
            return View("Index");
        }
    }
}
