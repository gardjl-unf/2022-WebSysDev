using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace COP3855_Project.Models
{
    public class ModelY : Vehicle
    {
        public bool YPerformancePackage { get; set; }
        public bool TowHitch { get; set; }
        public int Seating { get; set; }
    }
}
