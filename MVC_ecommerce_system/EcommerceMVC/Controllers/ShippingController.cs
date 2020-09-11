using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.BusinessLayer;
using Ecommerce.Entities;
using EcommerceMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class ShippingController : Controller
    {
        public ActionResult ShippingIndex()
        {
            List<ShippingViewModel> shippingViewModelList = new List<ShippingViewModel>();
            ShippingBL shippingBL = new ShippingBL();
            List<Shipping> shippingsList = shippingBL.GetAllShipingsBL();

            foreach (var shipping in shippingsList)
            {
                ShippingViewModel shipingView = new ShippingViewModel()
                {
                    OrderID = shipping.OrderID,
                    ShippingStatus = shipping.ShippingStatus
                   
                };
                shippingViewModelList.Add(shipingView);
            }

            

            //calling view and passing viewmodel object to view
            return View(shippingViewModelList);

           
        }

        //admin-------------------
        public ActionResult CreateShipping(Guid OrderID)
        {
            bool isCreated = false;
            ShippingBL shippingBL = new ShippingBL();
            isCreated = shippingBL.CreateShippingBL(OrderID);
            if (isCreated)
                return RedirectToAction("ShippingIndex", "Shipping");
            else
                return Content("Shipping was not created");

        }

        public ActionResult UpdateShipping(Guid OrderID)
        {
            bool isUpdated = false;
            ShippingBL shippingBL = new ShippingBL();
            isUpdated = shippingBL.UpdateShippingDetailBL(OrderID);
            if (isUpdated)
                return RedirectToAction("ShippingIndex", "Shipping");
            else
                return Content("Shipping was not updated");
        }




        //customer----------------------

        public ActionResult TrackShippingIndex(Guid OrderID)
        {
            ShippingViewModel shippingViewModel = new ShippingViewModel();
            ShippingBL shippingBL = new ShippingBL();
            string shippingStatus = shippingBL.TrackShippingBL(OrderID);
            shippingViewModel.ShippingStatus = shippingStatus;
            return View(shippingViewModel);
        }
    }
}
