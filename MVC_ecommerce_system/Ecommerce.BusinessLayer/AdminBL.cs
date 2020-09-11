using Ecommerce.System.Ecommerce.Contracts.BLContracts;
using Ecommerce.System.Ecommerce.Contracts.DALContracts;
using Ecommerce.System.Ecommerce.DataAccessLayer;
using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ecommerce.System.Ecommerce.BusinessLayer
{
    public class AdminBL : IAdminBL
    {
        AdminDALBase adminDAL;

        /*AdminDALBase _adminDALBase = new AdminDAL();*/
        public AdminBL()
        {
            this.adminDAL = new AdminDAL();

        }

        //get by id
        public Admin GetAdminByAdminIDBL(Guid searchAdminID)
        {
            Admin matchingAdmin = null;
            try
            {
                
                    matchingAdmin = this.adminDAL.GetAdminByAdminIDDAL(searchAdminID);               
            }
            catch (Exception)
            {
                throw;
            }
            return matchingAdmin;

        }

        //get by email and password
        public Admin GetAdminByEmailAndPasswordBL(string email, string password)
        {
            Admin matchingAdmin = null;
            try
            {
                    matchingAdmin = this.adminDAL.GetAdminByEmailAndPasswordDAL(email, password);               
            }
            catch (Exception)
            {
                throw;
            }
            return matchingAdmin;

        }

        //update details
        public bool UpdateAdminBL(Admin updateAdmin)
        {
            bool adminUpdated = false;
            try
            {
                if (GetAdminByAdminIDBL(updateAdmin.AdminID) != null)
                {
                    adminUpdated = this.adminDAL.UpdateAdminDAL(updateAdmin);
                                      
                }
            }
            catch (Exception)
            {
                throw;
            }
            return adminUpdated;

        }

        public bool UpdateAdminForgotPasswordBL(string email)
        {
            bool adminPasswordUpdated = false;
            try
            {
                adminPasswordUpdated = this.adminDAL.UpdateAdminForgotPasswordDAL(email);
            }
            catch (Exception)
            {

                throw;
            }
            return adminPasswordUpdated;
        }

        //update password
        public bool UpdateAdminPasswordBL(Admin updateAdminPassword)
        {
            bool adminPasswordUpdated = false;
            try
            {
                if (GetAdminByAdminIDBL(updateAdminPassword.AdminID) != null)
                {
                    adminPasswordUpdated = this.adminDAL.UpdateAdminDAL(updateAdminPassword);

                }
            }
            catch (Exception)
            {

                throw;
            }
            return adminPasswordUpdated;
        }
    }
}
