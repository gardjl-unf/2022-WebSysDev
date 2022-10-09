using Microsoft.AspNetCore.Mvc;

namespace COP3855_Project.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string HomeImagePath { get; set; }
    }
}
