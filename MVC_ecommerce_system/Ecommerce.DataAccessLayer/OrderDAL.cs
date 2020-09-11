using Ecommerce.System.Ecommerce.Contracts.DALContracts;
using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ecommerce.System.Ecommerce.DataAccessLayer
{
    public class OrderDAL : OrderDALBase
    {
        //create order
        public override bool CreateOrderDAL(Order newOrder)
        {
            bool orderCreated = false;
            try
            {
                orders.Add(newOrder);
                orderCreated = true;
            }
            catch (Exception)
            {

            }
            return orderCreated;
        }

        //view orders by order id
        public override Order ViewOrderByOrderIDDAL(Guid OrderID)
        {
            Order matchingOrder = null;
            try
            {
                //Find Order based on OrderID
                matchingOrder = OrderDALBase.orders.Find(
                   (item) => { return item.OrderID == OrderID; }
               );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingOrder;
        }

        //view all orders
        public override List<Order> ViewAllOrdersDAL()
        {
            return orders;
        }


        //view order by customer id
        public override Order ViewOrderByCustomerIDDAL(Guid CustomerID)
        {
            Order matchingOrder = null;
            try
            {
                matchingOrder = OrderDALBase.orders.Find(
                    (item) => { return item.CustomerID == CustomerID; }
                    );
            }
            catch (Exception)
            {

                throw;
            }
            return matchingOrder;
        }


        //view order status for customer
        public override string ViewOrderStatusForCustomerDAL(string OrderNumber, Guid customerID)
        {
            string status = "";
            Order matchingOrder = null;
            try
            {
                matchingOrder = OrderDALBase.orders.Find(
                    (item) => { return item.OrderNumber.Equals(OrderNumber) && item.CustomerID.Equals(customerID); }
                );
                status = matchingOrder.OrderStatus;
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }


        //view items ordered
        public override List<Product> ViewOrderedItemsDAL(Guid CustomerID)
        {
            List<Product> orderedItems = null;
            Order matchingOrder = null;
            try
            {
                //Find Order based on OrderID
                matchingOrder = OrderDALBase.orders.Find(
                   (item) => { return item.CustomerID == CustomerID; }
               );

                orderedItems = matchingOrder.OrderedItems;
            }
            catch (Exception)
            {
                throw;
            }
            return orderedItems;
        }
    }
}
