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
        IEnumerable<Model3> Model3s { get; }
        IEnumerable<ModelX> ModelXs { get; }
        IEnumerable<ModelY> ModelYs { get; }
        void SaveVehicle(Vehicle vehicle);
        Vehicle DeleteVehicle(int ID);
    }
}