using Ecommerce.System.Ecommerce.Contracts.DALContracts;
using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.DataAccessLayer
{
    public class ShoppingCartDAL : ShoppingCartDALBase
    {
        //add to shopping cart
        public override bool AddProductToShoppingCartDAL(Guid ProductID, Guid CustomerID)
        {
            bool productAdded = false;
            try
            {
                Product matchingProduct = null;
                ShoppingCart shoppingCart = null;
                matchingProduct = ProductDALBase.products.Find(
                    (item) => { return item.ProductID == ProductID; }
                    );

                shoppingCart.CustomerID = CustomerID;
                shoppingCart.ProductId = ProductID;
                shoppingCart.ShoppingCartProducts.Add(matchingProduct);

                ShoppingCartDALBase.shoppingCart.Add(shoppingCart);

                productAdded = true;
            }
            catch (Exception)
            {

            }
            return productAdded;
        }



        //get cart by customer id
        public override ShoppingCart GetShoppingCartByCustomerIDDAL(Guid customerID)
        {
            ShoppingCart matchingCart = null;
            try
            {
                matchingCart = ShoppingCartDALBase.shoppingCart.Find(
                    (item) => { return item.CustomerID == customerID; }
                );
            }
            catch (Exception)
            {

                throw;
            }
            return matchingCart;
        }


        //remove from shopping cart
        public override bool RemoveProductFromShoppingCartDAL(Guid productID,Guid CustomerID)
        {
            bool productRemoved = false;
            try
            {
                ShoppingCart matchingCart = null;
                matchingCart = ShoppingCartDALBase.shoppingCart.Find(
                   (item) => { return item.CustomerID == CustomerID; }
               );

                Product matchingProduct = null;
                matchingProduct = ProductDALBase.products.Find(
                   (item) => { return item.ProductID == productID; }
               );

                matchingCart.ShoppingCartProducts.Remove(matchingProduct);

                productRemoved = true;
            }
            catch (Exception)
            {

            }
            return productRemoved;
        }


    }
}
