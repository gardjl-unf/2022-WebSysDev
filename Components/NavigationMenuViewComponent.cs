using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using COP3855_Project.Models;

namespace COP3855_Project.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IVehicleRepository repository;
        public NavigationMenuViewComponent(IVehicleRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x));
        }

    }
}
