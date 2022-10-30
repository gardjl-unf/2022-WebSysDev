using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace COP3855_Project.Models
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ModelS> ModelSs { get; set; }
        public DbSet<Model3> Model3s { get; set; }
        public DbSet<ModelX> ModelXs { get; set; }
        public DbSet<ModelY> ModelYs { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
