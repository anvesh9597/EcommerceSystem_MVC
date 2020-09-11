using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.Contracts.DALContracts
{
    public abstract class ProductDALBase
    {
        //collections
        
        public static List<Product> products = new List<Product>() {
         new Product { ProductID = Guid.Parse("9465d16d-80e6-4a63-a14e-2711bc7a9438"), ProductNumber = 101, ProductName = "Shoes", ProductDescription = "Nike Sport shoes, small",PriceOfProduct= 2000, Stock= "In Stock" },
         new Product { ProductID = Guid.Parse("84231d4d-29c2-4810-b502-0d1e91d53cee"), ProductNumber = 102, ProductName = "Ball", ProductDescription = "Tennis ball",PriceOfProduct= 200, Stock= "In Stock" },
         new Product{ ProductID = Guid.Parse("1d06bc6c-bc63-45a0-b175-aa2538ffdce2"), ProductNumber = 103, ProductName = "Gloves", ProductDescription = "Polyester, regular",PriceOfProduct= 500, Stock= "In Stock" },
         new Product { ProductID = Guid.Parse("8609e866-5f02-47c1-ba8e-7f45cec3af66"), ProductNumber = 104, ProductName = "Wallet", ProductDescription = "Men's wallet, leather",PriceOfProduct= 1500, Stock= "In Stock" },
         new Product { ProductID = Guid.Parse("2c4613c9-f1f7-4459-93a2-74fadca3a376"), ProductNumber = 105, ProductName = "Bag", ProductDescription = "Wildcraft, medium, blue",PriceOfProduct= 2200, Stock= "In Stock" }

        };


        //methods
        public abstract Product GetProductByProductIDDAL(Guid searchProductID);
        public abstract Product GetProductByProductNameDAL(string productName);
        public abstract Product GetProductByProductNumberDAL(int productNumber);
        public abstract List<Product> GetAllProductsDAL();       
        public abstract bool AddProductDAL(Product newProduct);        
        public abstract bool RemoveProductDAL(Guid productID);
        public abstract bool UpdateProductDAL(Product updateProduct);

        
    }

   
}
