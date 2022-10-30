using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace COP3855_Project.Models
{
    public class ModelY : Vehicle
    {
        public void Vehicle()
        {
            this.Category = "Model Y";
            this.BasePrice = 67990;
            this.YPerformancePackagePrice = 4000;
        }
        public bool YPerformancePackage { get; set; }
        public decimal YPerformancePackagePrice { get; set; }
        public bool TowHitch { get; set; }
        public decimal TowHitchPrice { get; set; }
        public int Seating { get; set; }
        public decimal SeatingPrice { get; set; }
    }
}
