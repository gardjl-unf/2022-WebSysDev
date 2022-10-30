using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COP3855_Project.Models

{
    public class EFVehicleRepository : IVehicleRepository
    {
        private ApplicationDbContext context;
        public EFVehicleRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Vehicle> Vehicles => context.Vehicles;
        public IEnumerable<ModelS> ModelSs => context.ModelSs;
        public IEnumerable<Model3> Model3s => context.Model3s;
        public IEnumerable<ModelX> ModelXs => context.ModelXs;
        public IEnumerable<ModelY> ModelYs => context.ModelYs;
        public void SaveVehicle(Vehicle vehicle)
        {
            if (vehicle.ID == 0)
            {
                context.Vehicles.Add(vehicle);
            }
            else
            {
                Vehicle dbEntry = context.Vehicles.FirstOrDefault(v => v.ID == vehicle.ID); 
                if (dbEntry != null)
                {
                    dbEntry.Type = vehicle.Type; dbEntry.Description = vehicle.Description; dbEntry.BasePrice = vehicle.BasePrice; dbEntry.Category = vehicle.Category;
                }
            }
            context.SaveChanges();
        }
        public Vehicle DeleteVehicle(int ID)
        {
            Vehicle dbEntry = context.Vehicles.FirstOrDefault(v => v.ID == ID);
            if (dbEntry != null)
            {
                context.Vehicles.Remove(dbEntry); 
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
