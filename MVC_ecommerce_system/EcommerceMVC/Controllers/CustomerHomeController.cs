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
    public class CustomerHomeController : Controller
    {
        // GET: CustomerHome/CustomerIndex
        public ActionResult CustomerIndex(Guid? customerID)
        {
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer();
            CustomerViewModel customerViewModel = new CustomerViewModel();

            customer = customerBL.GetCustomerByCustomerIDBL(Guid.Parse(HttpContext.Session.GetString("customerID")));
            
            customerViewModel.CustomerName = customer.CustomerName;
            customerViewModel.Email = customer.Email;
            customerViewModel.CustomerMobile = customer.CustomerMobile;
            customerViewModel.DefaultShippingAddress = customer.DefaultShippingAddress;
            

            TempData["cusotmerID"] = customerViewModel.CustomerID;

            return View(customerViewModel);
        }


        //URL: CustomerHome/Edit
        public ActionResult Edit(Guid cusotmerID)
        {
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer()
            {
                CustomerID = cusotmerID
            };

            customer = customerBL.GetCustomerByCustomerIDBL(cusotmerID);
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.CustomerID = customer.CustomerID;
            customerViewModel.CustomerName = customer.CustomerName;
            customerViewModel.Email = customer.Email;
            customerViewModel.CustomerMobile = customer.CustomerMobile;
            customerViewModel.DefaultShippingAddress = customer.DefaultShippingAddress;

            return View(customerViewModel);


        }


        [HttpPost]
        public ActionResult Edit(CustomerViewModel customerViewModel)
        {
            bool isUpdated = false;
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer();

            customer.CustomerID = Guid.Parse(HttpContext.Session.GetString("customerID"));
            customer.CustomerName = customerViewModel.CustomerName;
            customer.Email = customerViewModel.Email;
            customer.CustomerMobile = customerViewModel.CustomerMobile;
            customer.DefaultShippingAddress = customerViewModel.DefaultShippingAddress;

            isUpdated = customerBL.UpdateCustomerByCustomerIDBL(customer);
            if (isUpdated == true)
                return RedirectToAction("CustomerIndex", "CustomerHome", new { customerID = TempData["customerID"] });
            else
                return Content("Your details were not updated");

        }



        public ActionResult EditPassword(Guid? cusotmerID)
        {
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer();

            customer = customerBL.GetCustomerByCustomerIDBL((Guid)cusotmerID);

            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.CustomerID = customer.CustomerID;
            customerViewModel.Email = customer.Email;
            customerViewModel.CustomerPassword = customer.Password;

            TempData["cusotmerEmail"] = customerViewModel.Email;

            return View(customerViewModel);
        }


        [HttpPost]
        public ActionResult EditPassword(CustomerViewModel customerViewModel)
        {
           /* System.Diagnostics.Debug.WriteLine(TempData["employeeEmail"]);
            System.Diagnostics.Debug.WriteLine(employeeHomeModel.EmployeePassword);*/

            bool isUpdated = false;
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer();

            Customer isCorrectCustomer = new Customer();

            customer.CustomerID = Guid.Parse(HttpContext.Session.GetString("customerID"));
            customer.Password = customerViewModel.ConfirmNewPassword;

            isCorrectCustomer = customerBL.GetCustomerByEmailAndPasswordBL(Convert.ToString(TempData["customerEmail"]), customerViewModel.CustomerPassword);
            if (isCorrectCustomer != null)
            {
                isUpdated = customerBL.UpdateCustomerPasswordBL(customer);
                if (isUpdated)
                    return RedirectToAction("CustomerIndex", "CustomerHome", new { customerID = TempData["customerID"] });
                else
                    return Content("Your password was not updated");

            }
            else
            {
                return RedirectToAction("DisplayMessage", "ShowMessage", new { Message = "Previous password entered is incorrect!" });
                //Response.Write("<script>alert('Previous password entered is incorrect!')</script>");
                //return RedirectToAction("EditPassword","EmployeeHome", new { employeeID = TempData["employeeID"] });
            }
        }


        public ActionResult Register()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult Register(CustomerViewModel customerViewModel)
        {
            // Create object of CustomerBL
            CustomerBL customerBL = new CustomerBL();

            //Creating object of Customer EntityModel
            Customer customer = new Customer();
            customer.CustomerName = customerViewModel.CustomerName;
            customer.CustomerMobile = customerViewModel.CustomerMobile;
            customer.DefaultShippingAddress = customerViewModel.DefaultShippingAddress;
            customer.Email = customerViewModel.Email;
            customer.Password = customerViewModel.CustomerPassword;
            customer.Password = customerViewModel.ConfirmNewPassword;

            //Invoke the AddProduct method BL
            bool isAdded = customerBL.AddCustomerBL(customer);

            if (isAdded)
            {
                //Go to Index action method of Product Controller
                return RedirectToAction("Index", "Login");
            }
            else
            {
                //Return plain html / plain string
                return Content("Sorry you were not registered");
            }
        }

    }
}
