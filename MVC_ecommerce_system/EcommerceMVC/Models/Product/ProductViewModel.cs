using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


/*Product View Model*/


namespace EcommerceMVC.Models
{
    public class ProductViewModel
    {
        public Guid ProductID { get; set; }

        [Required(ErrorMessage = "Name can't be blank")]
        [MinLength(2, ErrorMessage = "Name should contain atleast 2 characters")]
        [MaxLength(40, ErrorMessage = "Name can contain atmost 40 characters")]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "Name should contain only alphabets")]
        public string ProductName { get; set; }

        //Product Number 
        [Required(ErrorMessage = "Product Number should not be blank")]
        [RegularExpression(@"\+?[0-9]{5}", ErrorMessage = "please enter valid product number")]
        public int ProductNumber { get; set; }


        // Stock of the product
        [Required(ErrorMessage = "Please provide status of stock")]
        public string Stock { get; set; }

        //Technical Specifications of product with required validation
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description can't be blank")]
        public string ProductDescription { get; set; }

        //Cost of the product with validation for non-decimal values
        [Display(Name = "Price")]
        [RegularExpression("^[0-9.]*$", ErrorMessage = "Please enter only decimal values")]
        public double PriceOfProduct { get; set; }


    }
}
