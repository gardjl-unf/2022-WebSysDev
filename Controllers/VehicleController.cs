using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using COP3855_Project.Models;

namespace COP3855_Project.Controllers
{
    public class VehicleController : Controller
    {
        private IVehicleRepository repository;
        public VehicleController(IVehicleRepository repo)
        {
            repository = repo;
        }
        public ViewResult List() => View(repository.Vehicles);

    }
}
