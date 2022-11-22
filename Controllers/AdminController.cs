using Microsoft.AspNetCore.Mvc;
using Tuskla.Models;
using Microsoft.AspNetCore.Authorization;

namespace Tuskla.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;
        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View("Index");
        }
    }
}
