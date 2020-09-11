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
    public class OrderController : Controller
    {

        // GET: Orders
        //URL: Order/OrderIndex
        //function called by admin
        public ActionResult OrderIndex()
        {

            //creating and initializing viewmodel object
            List<OrderViewModel> orderViewModelList = new List<OrderViewModel>();



            OrderBL orderBL = new OrderBL();
            List<Order> ordersList = orderBL.ViewAllOrdersBL();

            foreach (var order in ordersList)
            {
                OrderViewModel orderView = new OrderViewModel()
                {
                    OrderID = order.OrderID,
                    CustomerID = order.CustomerID,
                    OrderNumber = order.OrderNumber,
                    OrderedItems = order.OrderedItems,
                    /*TotalCost = order.TotalCost,*/
                    OrderDateCreated = order.OrderDateCreated,
                    OrderStatus = order.OrderStatus
                };
                orderViewModelList.Add(orderView);
            }

            if (orderViewModelList.Count == 0)
            {
                return RedirectToAction("OrderIndex", "Order");
            }

            //calling view and passing viewmodel object to view
            return View(orderViewModelList);
        }


       

        //called by customer to place order
        //Order/Add
        public ActionResult Add()
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            return View(orderViewModel);
        }


        [HttpPost]
        public ActionResult Add(OrderViewModel orderViewModel)
        {
            // Create object of OrderBL
            OrderBL orderBL = new OrderBL();

            //Creating object of Order EntityModel
            Order order = new Order();
            order.CustomerID = orderViewModel.CustomerID;
            order.OrderNumber = orderViewModel.OrderNumber;
            order.OrderedItems = orderViewModel.OrderedItems;
            order.OrderDateCreated = orderViewModel.OrderDateCreated;
            /*order.TotalCost = orderViewModel.TotalCost;*/
            order.OrderStatus = orderViewModel.OrderStatus;

            //Invoke the AddProduct method BL
            bool isAdded = orderBL.CreateOrderBL(order);

            if (isAdded)
            {
                //Go to Index action method of Product Controller
                return RedirectToAction("CustomerIndex", "CustomerHome");
            }
            else
            {
                //Return plain html / plain string
                return Content("Order was not placed");
            }
        }


        //called by customer
        public ActionResult OrderedItemsIndex(Guid CustomerID)
        {

            //creating and initializing viewmodel object
            OrderViewModel orderViewModelList = new OrderViewModel();
            OrderBL orderBL = new OrderBL();
            //Order order = new Order();
            List<Product> orderedItems = new List<Product>();

            orderedItems = orderBL.ViewOrderedItemsBL(Guid.Parse(HttpContext.Session.GetString("customerID")));
            List<ProductViewModel> productViewModelList = new List<ProductViewModel>();
            foreach (var product in orderedItems)
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
                return Content("No items");
            }

            //calling view and passing viewmodel object to view
            return View(productViewModelList);
        }

    }
}
