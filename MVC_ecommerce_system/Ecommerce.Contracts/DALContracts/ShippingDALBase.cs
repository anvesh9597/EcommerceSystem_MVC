using Ecommerce.Entities;
using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Contracts.DALContracts
{
    public abstract class ShippingDALBase
    {
        //collections
        public static List<Order> shippedOrders = new List<Order>();
        public static List<Shipping> shippings = new List<Shipping>() { 
        
            new Shipping () {ShippingID = Guid.Parse("65fb54ae-e78e-4c6d-b07f-478eaeaa9c99"), CustomerID = Guid.Parse("2523c11a-6c1d-4ff0-bc18-1f301bf4a8cb"), OrderID = Guid.Parse("f6b1b23a-bbb0-4532-9bd5-04cbcbe33fb0"), ShippingStatus = "Shipped"},

            new Shipping () {ShippingID = Guid.Parse("e98edd7c-379c-46da-95b3-f514ac6769d6"), CustomerID = Guid.Parse("548589fe-158e-4cd2-8eb9-4479605a2853"), OrderID= Guid.Parse("7e5ab634-adbc-482e-b9e7-1cf6cc4cafaf"), ShippingStatus = "In process"}
        
        };

        //methods 
        public abstract List<Shipping> GetAllShippingsDAL();
        public abstract bool CreateShippingDAL(Guid OrderID);
        public abstract bool UpdateShippingDetailDAL(Guid OrderID);
        public abstract string TrackShippingDAL(Guid OrderID);


    }
}
