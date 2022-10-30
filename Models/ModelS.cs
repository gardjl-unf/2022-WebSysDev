using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace COP3855_Project.Models
{
    public class ModelS : Vehicle
    {
        public void Vehicle()
        {
            this.Category = "Model S";
            this.BasePrice = 109490;
            this.SPerformancePackagePrice = 31000;
        }
        public bool SPerformancePackage { get; set; }
        public decimal SPerformancePackagePrice { get; set; }
    }
}
