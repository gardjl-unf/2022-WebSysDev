using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tuskla.Models
{
    public class VehicleData
    {
        public string name { get; set; }
        public string delivery { get; set; }
        public decimal price { get; set; }
        public int speed { get; set; }
        public decimal acceleration { get; set; }
        public decimal range { get; set; }
        public VehicleData()
        {
            
        }
        public VehicleData GetData(string objectName)
        {
            List<VehicleData> vehicles = JsonConvert.DeserializeObject<List<VehicleData>>(File.ReadAllText(Directory.GetCurrentDirectory() + @"/wwwroot/data/vehicles.json"));
            var vehicle = vehicles.Where(v => v.name == objectName).FirstOrDefault();
            name = vehicle.name;
            delivery = vehicle.delivery;
            price = vehicle.price;
            speed = vehicle.speed;
            acceleration = vehicle.acceleration;
            range = vehicle.range;

            return this;
        }
    }
    
}