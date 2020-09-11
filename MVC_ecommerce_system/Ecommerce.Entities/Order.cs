using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.Entities
{
    public interface Iorder
    {
        public Guid OrderID { get; set; }
        public Guid CustomerID { get; set; }
        public string OrderNumber { get; set; }
        public List<Product> OrderedItems { get; set; }
        public DateTime OrderDateCreated { get; set; }
       /* public double TotalCost { get; set; }*/
        public string OrderStatus { get; set; }
    }
    public class Order:Iorder
    {
        public Guid OrderID { get; set; }
        public Guid CustomerID { get; set; }
        public string OrderNumber { get; set; }
        public List<Product> OrderedItems { get; set; }
        public DateTime OrderDateCreated { get; set; }
       /* public double TotalCost { get; set; }*/
        public string OrderStatus { get; set; }


        /* Constructor */
        public Order()
        {
            OrderID = default(Guid);
            OrderDateCreated = default(DateTime);
            OrderStatus = "Created";
        }
    }

    
}
