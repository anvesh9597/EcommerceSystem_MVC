using Ecommerce.Contracts.DALContracts;
using Ecommerce.Entities;
using Ecommerce.System.Ecommerce.Contracts.DALContracts;
using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.DataAccessLayer
{
    public class ShippingDAL : ShippingDALBase
    {

        //create new shipping by admin
        public override bool CreateShippingDAL(Guid OrderID)
        {
            bool shippingCreated = false;
            try
            {
                Order matchingOrder = null;
                matchingOrder = OrderDALBase.orders.Find(
                    (item) => { return item.OrderID == OrderID; }
                    );
                Shipping newShipping = null;
                newShipping.OrderID = matchingOrder.OrderID;
                newShipping.CustomerID = matchingOrder.CustomerID;

                shippings.Add(newShipping);
                shippingCreated = true;
            }
            catch (Exception)
            {

                throw;
            }
            return shippingCreated;
        }

        public override List<Shipping> GetAllShippingsDAL()
        {
            return shippings;
        }



        //track shipping by customer
        public override string TrackShippingDAL(Guid OrderID)
        {
            string shippingTracked = "";
            try
            {
                Order matchingOrder = null;
                matchingOrder = ShippingDALBase.shippedOrders.Find(
                    (item) => { return item.OrderID == OrderID; }
                    );

                Shipping matchingShipping = null;
                matchingShipping = ShippingDALBase.shippings.Find(
                    (item) => { return item.OrderID == OrderID; }
                    );

                if (matchingOrder != null)
                    shippingTracked = matchingShipping.ShippingStatus;

            }
            catch (Exception)
            {

                throw;
            }
            return shippingTracked;
        }




        //update shipping status by admin
        public override bool UpdateShippingDetailDAL(Guid OrderID)
        {
            bool shippingUpdated = false;
            try
            {
                Order matchingOrder = null;
                matchingOrder = OrderDALBase.orders.Find(
                    (item) => { return item.OrderID == OrderID; }
                    );

                shippedOrders.Add(matchingOrder);

                Shipping matchingShipping = null;
                matchingShipping = ShippingDALBase.shippings.Find(
                    (item) => { return item.OrderID == OrderID; }
                    );

                matchingShipping.ShippingStatus = "Shipped";
            }
            catch (Exception)
            {

                throw;
            }
            return shippingUpdated;
        }
    }
}
