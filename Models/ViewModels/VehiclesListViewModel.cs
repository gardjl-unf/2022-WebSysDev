using System.Collections.Generic;
using COP3855_Project.Models;

namespace COP3855_Project.Models.ViewModels
{
    public class VehiclesListViewModel
    {
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}