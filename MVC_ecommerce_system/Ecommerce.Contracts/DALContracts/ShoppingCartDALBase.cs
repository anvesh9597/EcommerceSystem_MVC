using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.Contracts.DALContracts
{
    public abstract class ShoppingCartDALBase
    {
        //COLLECTION
        public static List<ShoppingCart> shoppingCart = new List<ShoppingCart>() { 
        new ShoppingCart(){CartID = Guid.NewGuid(), CustomerID = Guid.Parse("2523c11a-6c1d-4ff0-bc18-1f301bf4a8cb"), ProductId = null, ShoppingCartProducts =  new List<Product>()
        {
            new Product( Guid.Parse("9465d16d-80e6-4a63-a14e-2711bc7a9438"),101, "Shoes", "Nike Sport shoes, small",2000, "In Stock" ),
            new Product ( Guid.Parse("84231d4d-29c2-4810-b502-0d1e91d53cee"), 102, "Ball", "Tennis ball",200,  "In Stock" )
        }},


        new ShoppingCart(){CartID = Guid.NewGuid(), CustomerID =  Guid.Parse("457c83a6-ffdf-44b9-a992-0637f53477fc"), ProductId = null, ShoppingCartProducts = new List<Product>()
        { 
            new Product (Guid.Parse("8609e866-5f02-47c1-ba8e-7f45cec3af66"), 104,  "Wallet",  "Men's wallet, leather",1500,  "In Stock"),
            new Product ( Guid.Parse("2c4613c9-f1f7-4459-93a2-74fadca3a376"),  105,  "Bag",  "Wildcraft, medium, blue", 2200,  "In Stock" )
        } },



        new ShoppingCart(){CartID = Guid.NewGuid(), CustomerID =  Guid.Parse("548589fe-158e-4cd2-8eb9-4479605a2853"), ProductId = null, ShoppingCartProducts = new List<Product>()
        { 
            new Product ( Guid.Parse("84231d4d-29c2-4810-b502-0d1e91d53cee"),  102,"Ball",  "Tennis ball",200, "In Stock") ,
            new Product ( Guid.Parse("1d06bc6c-bc63-45a0-b175-aa2538ffdce2"), 103, "Gloves",  "Polyester, regular",500,  "In Stock") ,
            new Product (  Guid.Parse("8609e866-5f02-47c1-ba8e-7f45cec3af66"),  104, "Wallet", "Men's wallet, leather",1500,  "In Stock") 
        } }


        };

        //METHODS
       /* public abstract List<ShoppingCart> GetShoppingCartDAL();*/
        public abstract bool AddProductToShoppingCartDAL(Guid ProductID, Guid CustomerID);
        public abstract bool RemoveProductFromShoppingCartDAL(Guid productID, Guid CustomerID);
        public abstract ShoppingCart GetShoppingCartByCustomerIDDAL(Guid customerID);
        
       



    }
}
