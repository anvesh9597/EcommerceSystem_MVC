using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/*View Model for Shipping */

namespace EcommerceMVC.Models
{
    public class ShippingViewModel
    {
        public Guid ShippingID { get; set; }

        [Required]
        public Guid CustomerID { get; set; }

        [Required]
        public Guid OrderID { get; set; }

        [Required(ErrorMessage = "Please provide shipping status")]
        public string ShippingStatus { get; set; }
    }
}
