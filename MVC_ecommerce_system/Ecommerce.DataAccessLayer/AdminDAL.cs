using Ecommerce.System.Ecommerce.Entities;
using Ecommerce.System.Ecommerce.Contracts.DALContracts;
using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.System.Ecommerce.Exceptions;

namespace Ecommerce.System.Ecommerce.DataAccessLayer
{
    public class AdminDAL:AdminDALBase
    {
        /// <summary>
        /// Gets admin based on AdminID.
        /// </summary>
        /// <param name="searchAdminID">Represents AdminID to search.</param>
        /// <returns>Returns Admin object.</returns>
        public override Admin GetAdminByAdminIDDAL(Guid searchAdminID)
        {
            Admin matchingAdmin = null;
            try
            {
                //Find Admin based on searchAdminID
                matchingAdmin = AdminDALBase.adminList.Find(
                    (item) => { return item.AdminID == searchAdminID; }
                );
            }
            catch (AdminNotFoundException)
            {
                throw new AdminNotFoundException("admin was not found!");
            }
            return matchingAdmin;
        }


        /// <summary>
        /// Gets admin based on Email and Password.
        /// </summary>
        /// <param name="email">Represents Admin's Email Address.</param>
        /// <param name="password">Represents Admin's Password.</param>
        /// <returns>Returns Admin object.</returns>
        public override Admin GetAdminByEmailAndPasswordDAL(string email, string password)
        {
            Admin matchingAdmin = null;
            try
            {
                //Find Admin based on Email and Password
                

                matchingAdmin = adminList.Find(
                    (item) => { return item.Email.Equals(email) && item.Password.Equals(password); }
                );

            }

            catch (AdminNotFoundException)
            {
                throw new AdminNotFoundException("admin was not found!");
            }
            return matchingAdmin;
        }

        //update admin details
        public override bool UpdateAdminDAL(Admin updateAdmin)
        {
            bool adminUpdated = false;
            try
            {
                //Find Admin based on AdminID
                Admin matchingAdmin = GetAdminByAdminIDDAL(updateAdmin.AdminID);

                if (matchingAdmin != null)
                {
                    //Update admin details
                    
                   matchingAdmin.AdminName = updateAdmin.AdminName;
                    matchingAdmin.Email = updateAdmin.Email;
                   matchingAdmin.LastModifiedDateTime = DateTime.Now;

                    adminUpdated = true;
                }

            }

            catch (AdminNotFoundException)
            {
                throw new AdminNotFoundException("admin was not found!");
            }
            return adminUpdated; 
        }

        public override bool UpdateAdminForgotPasswordDAL(string email)
        {
            bool passwordUpdated = false;
            Admin matchingAdmin = null;
            try
            {
                matchingAdmin = adminList.Find(
                    (item) => { return item.Email.Equals(email); }
                );
                passwordUpdated = UpdateAdminPasswordDAL(matchingAdmin);
            }
            catch (AdminNotFoundException)
            {

                throw new AdminNotFoundException("admin was not found!");
            }
            return passwordUpdated;
        }

        //update admin password
        public override bool UpdateAdminPasswordDAL(Admin updateAdmin)
        {
            bool adminUpdated = false;
            try
            {
                //Find Admin based on AdminID
                Admin matchingAdmin = GetAdminByAdminIDDAL(updateAdmin.AdminID);
                //Update admin password
                for (int i = 0; i < adminList.Count; i++)
                {
                    if(adminList[i].AdminID == matchingAdmin.AdminID)
                    {
                        matchingAdmin.Password = updateAdmin.Password;
                        matchingAdmin.LastModifiedDateTime = DateTime.Now;
                    }
                        
                }
                adminUpdated = true;
            }
            catch (AdminNotFoundException)
            {
                throw new AdminNotFoundException("admin was not found!");
            }
            return adminUpdated;
        }
    }
}
