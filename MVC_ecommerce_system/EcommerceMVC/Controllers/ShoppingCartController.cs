using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.System.Ecommerce.BusinessLayer;
using Ecommerce.System.Ecommerce.Entities;
using EcommerceMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        public ActionResult ShoppingCartIndex()
        {
            ShoppingCartBL shoppingCartBL = new ShoppingCartBL();
            ShoppingCart shoppingCart = shoppingCartBL.GetShoppingCartByCustomerIDBL(Guid.Parse(HttpContext.Session.GetString("customerID")));
            List<Product> productsInCart = new List<Product>();
            productsInCart = shoppingCart.ShoppingCartProducts;

            List<ProductViewModel> productViewModelList = new List<ProductViewModel>();
            foreach (var product in productsInCart)
            {
                ProductViewModel productView = new ProductViewModel()
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    ProductNumber = product.ProductNumber,
                    ProductDescription = product.ProductDescription,
                    PriceOfProduct = product.PriceOfProduct,
                    Stock = product.Stock
                };
                productViewModelList.Add(productView);
            }

            if (productViewModelList.Count == 0)
            {
                return RedirectToAction("SeeAllProductsIndex", "Product");
            }

            //calling view and passing viewmodel object to view
            return View(productViewModelList);

        }


        public ActionResult Add(Guid productID, Guid customerID)
        {
            bool isAdded = false;

            ShoppingCartBL shoppingCartBL = new ShoppingCartBL();

            isAdded = shoppingCartBL.AddProductToShoppingCartBL(productID, customerID);

            if (isAdded)
                return RedirectToAction("SeeAllProductsIndex", "Product");
            else
                return Content("Product was not added");
        }

        public ActionResult Remove(Guid productID, Guid customerID)
        {
            bool isRemoved = false;
            ShoppingCartBL shoppingCartBL = new ShoppingCartBL();
            isRemoved = shoppingCartBL.RemoveProductFromShoppingCartBL(productID, customerID);
            if (isRemoved)
                return RedirectToAction("ShoppingCartIndex", "ShoppingCart");
            else
                return Content("Product was not removed");
        }
    }
}
