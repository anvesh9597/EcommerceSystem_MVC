using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*View Model for Shopping Cart */


namespace EcommerceMVC.Models
{
    public class ShoppingCartViewModel
    {
        public Guid CartID { get; set; }
       
       /* CustomerViewModel Customer { get; set; }*/
       /* List<ProductViewModel> ShoppingCartProducts { get; set; }*/
       public  List<Product> ShoppingCartProducts { get; set; }
    }
}
