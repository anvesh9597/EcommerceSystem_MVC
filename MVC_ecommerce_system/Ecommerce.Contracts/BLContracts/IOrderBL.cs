using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.Contracts.BLContracts
{
    public interface IOrderBL
    {
        //customer
        public bool CreateOrderBL(Order newOrder);

        //admin
        public List<Order> ViewAllOrdersBL();

        //admin
        public Order ViewOrderByOrderIDBL(Guid OrderID);

        //admin
        public Order ViewOrderByCustomerIDBL(Guid CustomerID);

        //customer
        public string ViewOrderStatusForCustomerBL(string OrderNumber, Guid customerID);

        //customer
        public List<Product> ViewOrderedItemsBL(Guid CustomerID);
    }
}
