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
    }
}
