using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace COP3855_Project.Models
{
    public class Model3 : Vehicle
    {
        public void Vehicle()
        {
            this.Category = "Model 3";
            this.BasePrice = 48490;
            this.ThreePerformancePackagePrice = 16390;
        }
        public bool ThreePerformancePackage { get; set; }
        public decimal ThreePerformancePackagePrice { get; set; }
    }
}
