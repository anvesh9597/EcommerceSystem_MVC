using Ecommerce.System.Ecommerce.Helpers.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.Entities
{
    public interface IProduct
    {
        public Guid ProductID { get; set; }
        public int ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double PriceOfProduct { get; set; }
        public string Stock { get; set; }

    }
    public class Product : IProduct
    {
        [Required("Product ID cannot be blank")]
        public Guid ProductID { get; set; }

        [Required("Product Number cannot be blank")]
        [RegExp(@"\+?[0-9]{5}", "please enter valid product number")]
        public int ProductNumber { get; set; }

        [Required("Product Name cannot be blank")]
        [RegExp("[a-zA-Z]$", "name format is wrong, should not contain numbers or special characters")]
        public string ProductName { get; set; }

        [Required("Product Description cannot be blank")]
        [RegExp("[a-zA-Z]$", "name format is wrong, should not contain numbers or special characters")]
        public string ProductDescription { get; set; }

        [Required("Product Price cannot be zero")]
        public double PriceOfProduct { get; set; }
        public string Stock { get; set; }

        //constructor
        public Product()
        {

        }
        public Product(Guid productID, int productNumber, string productName, string productDescription, double priceOfProduct, string stock)
        {
            ProductID = productID;
            ProductNumber = productNumber;
            ProductName = productName;
            ProductDescription = productDescription;
            PriceOfProduct = priceOfProduct;
            Stock = stock;
        }
  
    }

   

}
