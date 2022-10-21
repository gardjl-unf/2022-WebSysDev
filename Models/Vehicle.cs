using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;

namespace COP3855_Project.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public Color ExteriorColor { get; set; }
        public Color InteriorColor { get; set; }
        public string Wheels { get; set; }
        public bool EnhancedAutopilot { get; set; }
        public bool FullSelfDriving { get; set; }
        public string WallConnect { get; set; }
        public string MobileConnect { get; set; }
        public string HomeImagePath { get; set; }
    }
}
