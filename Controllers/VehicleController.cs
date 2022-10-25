using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using COP3855_Project.Models;
using COP3855_Project.Models.ViewModels;

namespace COP3855_Project.Controllers
{
    public class VehicleController : Controller
    {
        private IVehicleRepository repository;
        public int PageSize = 4;
        public VehicleController(IVehicleRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string category, int page = 1)
            => View(new VehiclesListViewModel {
            Vehicles = repository.Vehicles
            .Where(p=> category == null || p.Category == category)
            .OrderBy(p => p.ID)
            .Skip((page - 1) * PageSize)
            .Take(PageSize),PagingInfo = new PagingInfo
             {
                 CurrentPage = page,
                 ItemsPerPage = PageSize,
                 TotalItems = repository.Vehicles.Count()
             },
            CurrentCategory = category
        });
    }
}
