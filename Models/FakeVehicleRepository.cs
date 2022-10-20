using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COP3855_Project.Models
{
    public class FakeVehicleRepository : IVehicleRepository
    {
        public IEnumerable<Vehicle> Vehicles => new List<Vehicle> {
             new Vehicle { Name = "Car", Price = 25 },
             new Vehicle { Name = "Other Car", Price = 179 },
             new Vehicle { Name = "Car Car Car", Price = 95 }
        };
    }
}
