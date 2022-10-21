using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace COP3855_Project.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ModelS> ModelSs { get; set; }
        public DbSet<Model3> Model3s { get; set; }
        public DbSet<ModelX> ModelXs { get; set; }
        public DbSet<ModelY> ModelYs { get; set; }
    }
}
