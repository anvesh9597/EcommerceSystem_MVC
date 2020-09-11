using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.Entities
{
    public interface IShoppingCart
    {
        public Guid CartID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid? ProductId { get; set; }
        public List<Product> ShoppingCartProducts { get; set; }
       
    }
    public class ShoppingCart : IShoppingCart
    {
        public Guid CartID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid? ProductId { get; set; }
        public List<Product> ShoppingCartProducts { get; set; }
        


        //constructor
        public ShoppingCart()
        {
            CartID = default(Guid);
        }
    }
}