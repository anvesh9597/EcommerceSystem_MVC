using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.Contracts.BLContracts
{
    public interface IShoppingCartBL
    {
       
        public ShoppingCart GetShoppingCartByCustomerIDBL(Guid customerID);
        public bool AddProductToShoppingCartBL(Guid ProductID, Guid CustomerID);
        public bool RemoveProductFromShoppingCartBL(Guid ProductID, Guid CustomerID);
        public abstract double CalculatePriceOfItemsBL(ShoppingCart shoppingCart);
    }
}
