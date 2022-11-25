using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Tuskla.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [BindNever]
        public bool Shipped { get; set; }
        [Required(ErrorMessage = "Please Enter a Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter the First Address Line")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage = "Please Enter a City Name")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Enter a State Name")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "Please Enter a Country NHame")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please Enter an E-Mail Address")]
        public string Email { get; set; }
        public bool GiftWrap { get; set; }
    }
}
