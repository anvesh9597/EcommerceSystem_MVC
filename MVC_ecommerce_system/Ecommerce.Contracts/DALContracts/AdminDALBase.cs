using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.Contracts.DALContracts
{
    /// <summary>
    /// This abstract class acts as a base for AdminDAL class
    /// </summary>

    public abstract class AdminDALBase
    {
        //Collection of Admins
        public static List<Admin> adminList = new List<Admin>()
        {
            new Admin() { AdminID = Guid.Parse("cb203330-4770-4be4-9503-12b5b2b9f38c"), AdminName = "Admin", Email = "admin@capgemini.com", Password = "manager", CreationDateTime = DateTime.Now, LastModifiedDateTime = DateTime.Now }
        };

        //Methods
        public abstract Admin GetAdminByAdminIDDAL(Guid searchAdminID);
        public abstract Admin GetAdminByEmailAndPasswordDAL(string email, string password);
        public abstract bool UpdateAdminDAL(Admin updateAdmin);
        public abstract bool UpdateAdminPasswordDAL(Admin updateAdmin);
        public abstract bool UpdateAdminForgotPasswordDAL(string email);
       


    }
}
