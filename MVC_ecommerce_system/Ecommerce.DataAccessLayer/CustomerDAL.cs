using Ecommerce.System.Ecommerce.Contracts.DALContracts;
using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.DataAccessLayer
{
    public class CustomerDAL : CustomerDALBase
    {
        //add customer
        public override bool AddCustomerDAL(Customer newCustomer)
        {
            bool customerAdded = false;
            try
            {
                customers.Add(newCustomer);
                customerAdded = true;
            }
            catch (Exception)
            {

            }
            return customerAdded;
        }

        //forgot password
        public override bool ForgotCustomerPasswordDAL(string Email, string Mobile)
        {
            bool passwordUpdated = false;
            Customer matchingCustomer = null;
            try
            {
                matchingCustomer = customers.Find(
                    (item) => { return item.Email.Equals(Email) && item.CustomerMobile.Equals(Mobile); }
                );
                passwordUpdated = UpdateCustomerPasswordDAL(matchingCustomer);
            }
            catch (Exception)
            {

                throw;
            }
            return passwordUpdated;
        }

        //list customers
        public override List<Customer> GetAllCustomersDAL()
        {
            return customers;
        }

        //get customer by id 
        public override Customer GetCustomerByCustomerIDDAL(Guid searchCustomerID)
        {
            Customer matchingCustomer = null;
            try
            {
                //Find Customer based on searchCustomerID
                 matchingCustomer = CustomerDALBase.customers.Find(
                    (item) => { return item.CustomerID == searchCustomerID; }
                );
            }
            catch (Exception)
            {

            }
            return matchingCustomer;
        }

        //get by email and password
        public override Customer GetCustomerByEmailAndPasswordDAL(string Email, string Password)
        {
            Customer matchingCustomer = null;
            try
            {

                matchingCustomer = customers.Find(
                    (item) => { return item.Email.Equals(Email) && item.Password.Equals(Password); }
                );

            }

            catch (Exception)
            {
                throw ;
            }
            return matchingCustomer;
        }

        //remove customer
        public override bool RemoveCustomerDAL(Guid CustomerID)
        {
            bool customerRemoved = false;
            try
            {
                Customer matchingCustomer = GetCustomerByCustomerIDDAL(CustomerID);
                if (matchingCustomer != null)
                {
                    customers.Remove(matchingCustomer);
                    customerRemoved = true;
                }
                    
            }
            catch (Exception)
            {

            }
            return customerRemoved;
        }


        //update
        public override bool UpdateCustomerByCustomerIDDAL(Customer updateCustomer)
        {
            bool customerUpdated = false;
            try
            {
                //Find customer based on CustomerID
                Customer matchingCustomer = GetCustomerByCustomerIDDAL(updateCustomer.CustomerID);

                if (matchingCustomer != null)
                {
                    //Update customer details
                    for (int i = 0; i < customers.Count; i++)
                    {
                        if (customers[i].CustomerID == matchingCustomer.CustomerID)
                        {
                            matchingCustomer.CustomerName = updateCustomer.CustomerName;
                            matchingCustomer.Email = updateCustomer.Email;
                            matchingCustomer.CustomerMobile = updateCustomer.CustomerMobile;
                           
                            matchingCustomer.DefaultShippingAddress = updateCustomer.DefaultShippingAddress;
                           
                            matchingCustomer.LastModifiedDateTime = DateTime.Now;
                        }
                    }
                    customerUpdated = true;
                }
            }
            catch (Exception)
            {

            }
            return customerUpdated;
        }

        //update password
        public override bool UpdateCustomerPasswordDAL(Customer updateCustomerPassword)
        {
            bool customerPasswordUpdated = false;
            try
            {
                Customer matchingCustomer = GetCustomerByCustomerIDDAL(updateCustomerPassword.CustomerID);
                if (matchingCustomer != null)
                {
                    for(int i=0; i<customers.Count; i++)
                    {
                        if (customers[i].CustomerID == matchingCustomer.CustomerID)
                        {
                            matchingCustomer.Password = updateCustomerPassword.Password;
                            matchingCustomer.LastModifiedDateTime = DateTime.Now;
                        }

                    }
                    customerPasswordUpdated = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return customerPasswordUpdated;
        }

    }
}
