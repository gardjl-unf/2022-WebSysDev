using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Runtime.CompilerServices;

namespace COP3855_Project.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter a product type")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal BasePrice { get; set; }
        public string ExteriorColor { get; set; }
        public decimal ExteriorPrice { get; set; }
        public string InteriorColor { get; set; }
        public decimal InteriorPrice { get; set; }
        public string Wheels { get; set; }
        public decimal WheelsPrice { get; set; }
        public bool EnhancedAutopilot { get; set; }
        public decimal EnhancedAutopilotPrice { get; set; }
        public bool FullSelfDriving { get; set; }
        public decimal FullSelfDrivingPrice { get; set; }
        public string AccWallConnect { get; set; }
        public decimal AccWallConnectPrice { get; set; }
        public string AccMobileConnect { get; set; }
        public decimal AcMobileConnectPrice { get; set; }
        public decimal DestinationFee { get; set; }
        public string ImagePath { get; set; }
    }
}
