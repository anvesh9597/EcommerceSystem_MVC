using Ecommerce.Contracts.BLContracts;
using Ecommerce.Contracts.DALContracts;
using Ecommerce.DataAccessLayer;
using Ecommerce.Entities;
using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BusinessLayer
{
    public class ShippingBL:IShippingBL
    {

        ShippingDALBase shippingDALBase;
        public ShippingBL()
        {
            this.shippingDALBase = new ShippingDAL();
        }



        //create shipping
        public bool CreateShippingBL(Guid OrderID)
        {
            bool shippingCreated = false;
            try
            {
                shippingCreated = this.shippingDALBase.CreateShippingDAL(OrderID);
            }
            catch (Exception)
            {

                throw;
            }
            return shippingCreated;
        }

        public List<Shipping> GetAllShipingsBL()
        {
            List<Shipping> shippings = null;
            try
            {
                shippings = this.shippingDALBase.GetAllShippingsDAL();
            }
            catch (Exception)
            {

                throw;
            }
            return shippings;
        }



        //track shipping by customer 
        public string TrackShippingBL(Guid OrderID)
        {
            string shippingTracked = "";
            try
            {
                shippingTracked = this.shippingDALBase.TrackShippingDAL(OrderID);

            }
            catch (Exception)
            {

                throw;
            }
            return shippingTracked;
        }



        //update shipping 
        public bool UpdateShippingDetailBL(Guid OrderID)
        {
            bool shippingUpdated = false;
            try
            {
                shippingUpdated = this.shippingDALBase.UpdateShippingDetailDAL(OrderID);
            }
            catch (Exception)
            {

                throw;
            }
            return shippingUpdated;
        }
    }
}
