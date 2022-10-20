using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COP3855_Project.Models
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> Vehicles { get; }
        IEnumerable<ModelS> ModelSs { get; }
    }
}