using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace COP3855_Project.Models
{
    public class ModelX : Vehicle
    {
        public void Vehicle()
        {
            this.Category = "Model X";
            this.BasePrice = 126490;
            this.XPerformancePackagePrice = 18000;
        }
        public bool XPerformancePackage { get; set; }
        public decimal XPerformancePackagePrice { get; set; }
        public int Seating { get; set; }
        public decimal SeatingPrice { get; set; }
    }
}
