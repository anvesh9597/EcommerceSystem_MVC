using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.System.Ecommerce.BusinessLayer;
using Ecommerce.System.Ecommerce.Entities;
using EcommerceMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class LoginController : Controller
    {

        

        // GET: 
        //URL: Login/Index
        public ActionResult Index()
        {
           

            //creating login view model
            LoginViewModel loginViewModel = new LoginViewModel();

            //passing view model object to view
            return View(loginViewModel);
        }


        //POST 
        //URL: Login/Index
        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            //if user type is selected as admin
            if (loginViewModel.UserType == "Admin")
            {
                AdminBL adminBL = new AdminBL();
                Admin admin = new Admin();

                //aasigning view model object details to entity model object
                admin.Email = loginViewModel.Email;
                admin.Password = loginViewModel.Password;

                //admin object returned from the database
                Admin loginAdmin = adminBL.GetAdminByEmailAndPasswordBL(admin.Email, admin.Password);
                if (loginAdmin != null)
                {
                    //admin home page    
                    HttpContext.Session.SetString("adminID", loginAdmin.AdminID.ToString());
                    //Session["adminID"] = loginAdmin.AdminID;
                    return RedirectToAction("AdminIndex", "AdminHome", new { adminID = loginAdmin.AdminID });
                }
                else
                {
                    return Content("Admin not found.");
                }
            }

            //if user type is selected as customer
            if (loginViewModel.UserType == "Customer")
            {
                CustomerBL customerBL = new CustomerBL();
                Customer customer = new Customer();

                //aasigning view model object details to entity model object
                customer.Email = loginViewModel.Email;
                customer.Password = loginViewModel.Password;

                //cusotmer object returned from the database
                Customer loginCustomer =  customerBL.GetCustomerByEmailAndPasswordBL(customer.Email, customer.Password);
                if (loginCustomer != null)
                {
                    //cusotmer home page
                    // Session["customerID"] = loginCustomer.CustomerID;
                    HttpContext.Session.SetString("customerID", loginCustomer.CustomerID.ToString());
                    return RedirectToAction("CustomerIndex", "CustomerHome", new { customerID = loginCustomer.CustomerID });

                }
                else
                {
                    return Content("Customer not found.");
                }
            }
            else
                return Content("Please select user type");
        }

    }
}
