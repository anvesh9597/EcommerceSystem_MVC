using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Ecommerce.Entities
{
    public interface IShipping
    {
        public Guid ShippingID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid OrderID { get; set; }
        public string ShippingStatus { get; set; }
    }
    public class Shipping:IShipping
    {
        public Guid ShippingID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid OrderID { get; set; }
        public string ShippingStatus { get; set; }


        //constructor
        public Shipping()
        {
           
            
        }

    }
}
