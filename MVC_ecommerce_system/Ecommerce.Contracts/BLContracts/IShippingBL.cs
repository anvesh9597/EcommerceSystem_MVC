using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Contracts.BLContracts
{
    public interface IShippingBL
    {
        public List<Shipping> GetAllShipingsBL();
        public bool CreateShippingBL(Guid OrderID);
        public bool UpdateShippingDetailBL(Guid OrderID);
        public string TrackShippingBL(Guid OrderID);
    }
}
