using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;

namespace COP3855_Project.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
        public string Wheels { get; set; }
        public bool EnhancedAutopilot { get; set; }
        public bool FullSelfDriving { get; set; }
        public string AccWallConnect { get; set; }
        public string AccMobileConnect { get; set; }
        public string ImagePath { get; set; }
    }
}
