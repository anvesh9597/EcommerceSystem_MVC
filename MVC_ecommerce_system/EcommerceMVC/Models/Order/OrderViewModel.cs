using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/*View Model for Orders*/


namespace EcommerceMVC.Models
{
    public class OrderViewModel
    {
        public Guid OrderID { get; set; }
        public Guid CustomerID { get; set; }

        [Required(ErrorMessage = "Order No. can't be empty")]
        [RegularExpression("^([0-9])$", ErrorMessage = "Order No. should be valid")]
        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }
        public List<Product> OrderedItems { get; set; }
        public DateTime OrderDateCreated { get; set; }
        public double TotalCost { get; set; }

        [Required(ErrorMessage = "Please provide Order status")]
        public string OrderStatus { get; set; }
    }
}
