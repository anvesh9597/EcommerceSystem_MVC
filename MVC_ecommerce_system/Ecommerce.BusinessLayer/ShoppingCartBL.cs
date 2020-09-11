using Ecommerce.System.Ecommerce.Contracts.BLContracts;
using Ecommerce.System.Ecommerce.Contracts.DALContracts;
using Ecommerce.System.Ecommerce.DataAccessLayer;
using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.BusinessLayer
{
    public class ShoppingCartBL : IShoppingCartBL
    {

        ShoppingCartDALBase ShoppingCartDALBase;
        public ShoppingCartBL()
        {
            this.ShoppingCartDALBase = new ShoppingCartDAL();
        }



        //add
        public bool AddProductToShoppingCartBL(Guid ProductID, Guid CustomerID)
        {
            bool productAdded = false;
            try
            {
                productAdded = this.ShoppingCartDALBase.AddProductToShoppingCartDAL(ProductID, CustomerID);
            }
            catch (Exception)
            {

                throw;
            }
            return productAdded;
        }


        //calculate total price of items in cart 
        public double CalculatePriceOfItemsBL(ShoppingCart shoppingCart)
        {
            double totalPrice = 0.0;
            try
            {
                for(int i=0; i<shoppingCart.ShoppingCartProducts.Count; i++)
                {
                    totalPrice += shoppingCart.ShoppingCartProducts[i].PriceOfProduct;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return totalPrice;
        }



        //get by customer id
        public ShoppingCart GetShoppingCartByCustomerIDBL(Guid customerID)
        {
            ShoppingCart shoppingCart = null;
            try
            {
                shoppingCart = this.ShoppingCartDALBase.GetShoppingCartByCustomerIDDAL(customerID);
            }
            catch (Exception)
            {

                throw;
            }
            return shoppingCart;
        }



        //remove product from cart
        public bool RemoveProductFromShoppingCartBL(Guid ProductID, Guid CustomerID)
        {
            bool productRemoved = false;
            try
            {
                productRemoved = this.ShoppingCartDALBase.RemoveProductFromShoppingCartDAL(ProductID, CustomerID);
            }
            catch (Exception)
            {

                throw;
            }
            return productRemoved;
        }
       
    }
}
