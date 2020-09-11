using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.Contracts.DALContracts
{
    public abstract class OrderDALBase
    {
        
        //collections
        public static List<Order> orders = new List<Order>() { 
        new Order() { OrderID = Guid.Parse("f6b1b23a-bbb0-4532-9bd5-04cbcbe33fb0"), CustomerID = Guid.Parse("2523c11a-6c1d-4ff0-bc18-1f301bf4a8cb"), OrderedItems = new List<Product>()
        {
             new Product ( Guid.Parse("9465d16d-80e6-4a63-a14e-2711bc7a9438"),101,  "Shoes",  "Nike Sport shoes, small", 2000, "In Stock" ),
            new Product(Guid.Parse("84231d4d-29c2-4810-b502-0d1e91d53cee"), 102,  "Ball", "Tennis ball", 200, "In Stock" )
        },
            
            OrderNumber = "10001"},


        new Order(){OrderID= Guid.Parse("7e5ab634-adbc-482e-b9e7-1cf6cc4cafaf"), CustomerID = Guid.Parse("548589fe-158e-4cd2-8eb9-4479605a2853"), OrderedItems = new List<Product>()
        { 
            new Product ( Guid.Parse("84231d4d-29c2-4810-b502-0d1e91d53cee"), 102, "Ball",  "Tennis ball",200, "In Stock" ),
            new Product ( Guid.Parse("1d06bc6c-bc63-45a0-b175-aa2538ffdce2"),  103, "Gloves", "Polyester, regular", 500,  "In Stock" ),
            new Product(  Guid.Parse("8609e866-5f02-47c1-ba8e-7f45cec3af66"), 104, "Wallet", "Men's wallet, leather", 1500, "In Stock" )
        },
            OrderNumber = "10002"}
        };

        //methods
        public abstract bool CreateOrderDAL(Order newOrder);
        public abstract List<Order> ViewAllOrdersDAL();
        public abstract Order ViewOrderByOrderIDDAL(Guid OrderID);
        public abstract Order ViewOrderByCustomerIDDAL(Guid CustomerID);
        public abstract string ViewOrderStatusForCustomerDAL(string OrderNumber, Guid customerID);
        public abstract List<Product> ViewOrderedItemsDAL(Guid CustomerID);
        

    }
}
