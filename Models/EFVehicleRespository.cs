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
    }
}
