using Ecommerce.System.Ecommerce.Contracts.BLContracts;
using Ecommerce.System.Ecommerce.Contracts.DALContracts;
using Ecommerce.System.Ecommerce.DataAccessLayer;
using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.BusinessLayer
{
    public class CustomerBL : ICustomerBL
    {
        CustomerDALBase customerDALBase;
        public CustomerBL()
        {
            this.customerDALBase = new CustomerDAL();
        }


        //add
        public bool AddCustomerBL(Customer newCustomer)
        {
            bool customerAdded = false;
            try
            {
                customerAdded = this.customerDALBase.AddCustomerDAL(newCustomer);
            }
            catch (Exception)
            {

                throw;
            }
            return customerAdded;
        }

        //forgot password
        public bool ForgotCustomerPasswordBL(string Email, string Mobile)
        {
            bool updatedPassword = false;
            try
            {
                updatedPassword = this.customerDALBase.ForgotCustomerPasswordDAL(Email,Mobile);
            }
            catch (Exception)
            {

                throw;
            }
            return updatedPassword;
        }


        //get all 
        public List<Customer> GetAllCustomersBL()
        {
            List<Customer> customers = null;
            try
            {
                customers = this.customerDALBase.GetAllCustomersDAL();
            }
            catch (Exception)
            {

                throw;
            }
            return customers;
        }

        //get by id
        public Customer GetCustomerByCustomerIDBL(Guid CustomerID)
        {
            Customer customer = null;
            try
            {
                customer = this.customerDALBase.GetCustomerByCustomerIDDAL(CustomerID);
            }
            catch (Exception)
            {

                throw;
            }
            return customer;
        }

        //get by email and password
        public Customer GetCustomerByEmailAndPasswordBL(string Email, string Password)
        {
            Customer matchingCustomer = null;
            try
            {
                matchingCustomer = this.customerDALBase.GetCustomerByEmailAndPasswordDAL(Email, Password);
            }
            catch (Exception)
            {

                throw;
            }
            return matchingCustomer;
        }


        //remove
        public bool RemoveCustomerBL(Guid CustomerID)
        {
            bool customerRemoved = false;
            try
            {
                customerRemoved = this.customerDALBase.RemoveCustomerDAL(CustomerID);
            }
            catch (Exception)
            {

                throw;
            }
            return customerRemoved;
        }


        //update details
        public bool UpdateCustomerByCustomerIDBL(Customer updateCustomer)
        {
            bool customerUpdated = false;
            try
            {
                customerUpdated = this.customerDALBase.UpdateCustomerByCustomerIDDAL(updateCustomer);
            }
            catch (Exception)
            {

                throw;
            }
            return customerUpdated;
        }


        //update password
        public bool UpdateCustomerPasswordBL(Customer updateCustomerPassword)
        {
            bool updatedCustomerPassword = false;
            try
            {
                updatedCustomerPassword = this.customerDALBase.UpdateCustomerPasswordDAL(updateCustomerPassword);
            }
            catch (Exception)
            {

                throw;
            }
            return updatedCustomerPassword;
        }
    }
}
