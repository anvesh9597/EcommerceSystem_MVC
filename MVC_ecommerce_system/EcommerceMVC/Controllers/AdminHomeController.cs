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
    public class AdminHomeController : Controller
    {
        // GET 
        //URL: AdminHome/AdminIndex

        public ActionResult AdminIndex(Guid? adminID)
        {
            //System.Diagnostics.Debug.WriteLine(adminID);
            AdminBL adminBL = new AdminBL();
            Admin admin = new Admin();
            AdminViewModel adminViewModel = new AdminViewModel();

            admin = adminBL.GetAdminByAdminIDBL(Guid.Parse(HttpContext.Session.GetString("adminID")));
            /*adminViewModel.AdminID = Guid.Parse(Convert.ToString(Session["adminID"]));*/
            adminViewModel.AdminName = admin.AdminName;
            adminViewModel.Email = admin.Email;
            /*adminViewModel.LastModifiedDate = admin.LastModifiedDateTime;
*/
            TempData["adminID"] = adminViewModel.AdminID;


            return View(adminViewModel);
        }



        //URL: AdminHome/Edit
        public ActionResult Edit(Guid adminID)
        {
            AdminBL adminBL = new AdminBL();
            Admin admin = new Admin()
            {
                AdminID = adminID
            };

            admin =  adminBL.GetAdminByAdminIDBL(adminID);
            System.Diagnostics.Debug.WriteLine(admin.AdminID);
            AdminViewModel viewModel = new AdminViewModel();
            viewModel.AdminID = admin.AdminID;
            viewModel.AdminName = admin.AdminName;
            viewModel.Email = admin.Email;

            return View(viewModel);


        }


        [HttpPost]
        public ActionResult Edit(AdminViewModel viewModel)
        {
            bool isUpdated = false;
            AdminBL adminBL = new AdminBL();
            Admin admin = new Admin();

            admin.AdminID = Guid.Parse(HttpContext.Session.GetString("adminID"));
            admin.AdminName = viewModel.AdminName;
            admin.Email = viewModel.Email;


            isUpdated = adminBL.UpdateAdminBL(admin);
            if (isUpdated)
                return RedirectToAction("AdminIndex", "AdminHome", new { adminID = TempData["adminID"] });
            else
                return Content("Your details were not updated");

        }



        public ActionResult EditPassword(Guid? adminID)
        {
            AdminBL adminBL = new AdminBL();
            Admin admin = new Admin();

            admin = adminBL.GetAdminByAdminIDBL((Guid)adminID);

            AdminViewModel viewModel = new AdminViewModel();
            viewModel.AdminID = admin.AdminID;
            viewModel.Password = admin.Password;


            return View(viewModel);
        }


        [HttpPost]
        public ActionResult EditPassword(AdminViewModel viewModel)
        {
            bool isUpdated = false;
            AdminBL adminBL = new AdminBL();
            Admin admin = new Admin();



            admin.AdminID = Guid.Parse(HttpContext.Session.GetString("adminID"));
            admin.Password = viewModel.ConfirmPassword;


            isUpdated = adminBL.UpdateAdminPasswordBL(admin);
            if (isUpdated)
                return RedirectToAction("AdminIndex", "AdminHome", new { adminID = TempData["adminID"] });
            else
                return Content("Your password was not updated");

        }

        //public ActionResult Cancel(Guid adminID)
        //{
        //    return RedirectToAction("AdminIndex", "AdminHome", new { adminID = TempData["adminID"] });
        //}
    }
}
