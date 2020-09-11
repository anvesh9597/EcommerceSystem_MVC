using Ecommerce.System.Ecommerce.Contracts.BLContracts;
using Ecommerce.System.Ecommerce.Contracts.DALContracts;
using Ecommerce.System.Ecommerce.DataAccessLayer;
using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.BusinessLayer
{
    public class OrderBL : IOrderBL
    {
        OrderDALBase orderDALBAse;
        public OrderBL()
        {
            this.orderDALBAse = new OrderDAL();
        }


        //create order
        public bool CreateOrderBL(Order newOrder)
        {
            bool orderCreated = false;
            try
            {
                orderCreated = this.orderDALBAse.CreateOrderDAL(newOrder);
            }
            catch (Exception)
            {

                throw;
            }
            return orderCreated;
        }


        //view order by customer id 
        public Order ViewOrderByCustomerIDBL(Guid CustomerID)
        {
            Order order = null;
            try
            {
                order = this.orderDALBAse.ViewOrderByCustomerIDDAL(CustomerID);
            }
            catch (Exception)
            {

                throw;
            }
            return order;
        }



        //view order by order id
        public Order ViewOrderByOrderIDBL(Guid OrderID)
        {
            Order order = null;
            try
            {
                order = this.orderDALBAse.ViewOrderByOrderIDDAL(OrderID);
            }
            catch (Exception)
            {

                throw;
            }
            return order;
        }



        public List<Order> ViewAllOrdersBL()
        {
            List<Order> orders = null;
            try
            {
                orders = this.orderDALBAse.ViewAllOrdersDAL();
            }
            catch (Exception)
            {

                throw;
            }
            return orders;
        }


        //view order status for customer 
        public string ViewOrderStatusForCustomerBL(string OrderNumber, Guid customerID)
        {
            string orderStatus = "";
            try
            {
                orderStatus = this.orderDALBAse.ViewOrderStatusForCustomerDAL(OrderNumber, customerID);
            }
            catch (Exception)
            {

                throw;
            }
            return orderStatus;
        }


        //view ordered items
        public List<Product> ViewOrderedItemsBL(Guid CustomerID)
        {
            List<Product> orderedItems = null;
            try
            {
                orderedItems = this.orderDALBAse.ViewOrderedItemsDAL(CustomerID);
            }
            catch (Exception)
            {

                throw;
            }
            return orderedItems;
        }
    }
}
