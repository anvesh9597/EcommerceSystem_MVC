using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.System.Ecommerce.BusinessLayer;
using Ecommerce.System.Ecommerce.Entities;
using EcommerceMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Products
        //URL: Product/ProductIndex
        public ActionResult ProductIndex()
        {

            //creating and initializing viewmodel object
            List<ProductViewModel> productViewModelList = new List<ProductViewModel>();

         
            
                ProductBL productBL = new ProductBL();
                List<Product> productsList = productBL.GetAllProductsBL();

                foreach (var product in productsList)
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
                    return RedirectToAction("Add", "Product");
                }
            
            //calling view and passing viewmodel object to view
            return View(productViewModelList);
        }

        public ActionResult Delete(Guid productID)
        {
            bool isDeleted = false;
            ProductBL productBL = new ProductBL();
            Product product = new Product();
            product = productBL.GetProductByProductIDBL(productID);

            isDeleted = productBL.RemoveProductBL(product.ProductID);
            if (isDeleted)
                return RedirectToAction("Index", "Product");
            else
                return Content("Product was not deleted");
        }


        public ActionResult Add()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            return View(productViewModel);
        }


        [HttpPost]
        public ActionResult Add(ProductViewModel productViewModel)
        {
            // Create object of ProductBL
            ProductBL productBL = new ProductBL();

            //Creating object of Product EntityModel
            Product product = new Product();
            product.ProductName = productViewModel.ProductName;
            product.ProductNumber = productViewModel.ProductNumber;
            product.ProductDescription = productViewModel.ProductDescription;
            product.PriceOfProduct = productViewModel.PriceOfProduct;
            product.Stock = productViewModel.Stock;

            //Invoke the AddProduct method BL
            bool isAdded = productBL.AddProductBL(product);

            if (isAdded)
            {
                //Go to Index action method of Product Controller
                return RedirectToAction("Index", "Product");
            }
            else
            {
                //Return plain html / plain string
                return Content("Product was not added");
            }
        }

        public ActionResult Edit(Guid productID)
        {
            ProductBL productBL = new ProductBL();
            Product product = new Product()
            {
                ProductID = productID
            };

            product = productBL.GetProductByProductIDBL(productID);
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.ProductID = product.ProductID;
            productViewModel.ProductName = product.ProductName;
            productViewModel.ProductNumber = product.ProductNumber;
            productViewModel.ProductDescription = product.ProductDescription;
            productViewModel.PriceOfProduct = product.PriceOfProduct;
            productViewModel.Stock = product.Stock;

            return View(productViewModel);
        }


        [HttpPost]
        public ActionResult Edit(ProductViewModel productViewModel)
        {
            // Create object of ProductBL
            ProductBL productBL = new ProductBL();

            //Creating object of Product EntityModel
            Product product = new Product();
            product.ProductName = productViewModel.ProductName;
            product.ProductNumber = productViewModel.ProductNumber;
            product.ProductDescription = productViewModel.ProductDescription;
            product.PriceOfProduct = productViewModel.PriceOfProduct;
            product.Stock = productViewModel.Stock;

            //Invoke the AddProduct method BL
            bool isUpdated = productBL.UpdateProductBL(product);

            if (isUpdated)
            {
                //Go to Index action method of Product Controller
                return RedirectToAction("Index", "Product");
            }
            else
            {
                //Return plain html / plain string
                return Content("Product was not updated");
            }
        }

        //called by customer to see all the products
        public ActionResult SeeAllProductsIndex()
        {

            //creating and initializing viewmodel object
            List<ProductViewModel> productViewModelList = new List<ProductViewModel>();



            ProductBL productBL = new ProductBL();
            List<Product> productsList = productBL.GetAllProductsBL();

            foreach (var product in productsList)
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
   
            //calling view and passing viewmodel object to view
            return View(productViewModelList);
        }
    }
}
