using Microsoft.AspNetCore.Mvc;
using COP3855_Project.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace COP3855_Project.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IVehicleRepository repository;
        public AdminController(IVehicleRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index() => View(repository.Vehicles);
        public ViewResult Edit(int ID) => View(repository.Vehicles.FirstOrDefault(v => v.ID == ID));
        [HttpPost]
        public IActionResult Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                repository.SaveVehicle(vehicle); TempData["message"] = $"{vehicle.Type} has been saved"; 
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values return View(product);
                return View(vehicle);
            }
        }
        public ViewResult Create() => View("Edit", new Vehicle());
        [HttpPost]
        public IActionResult Delete(int ID)
        {
            Vehicle deletedVehicle = repository.DeleteVehicle(ID); 
            if (deletedVehicle != null)
            {
                TempData["message"] = $"{deletedVehicle.Type} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}