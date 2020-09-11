using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.Contracts.DALContracts
{
    public abstract class CustomerDALBase
    {
        //collection
        public static List<Customer> customers = new List<Customer>()
        {
             new Customer() { CustomerID = Guid.Parse("2523c11a-6c1d-4ff0-bc18-1f301bf4a8cb"), CustomerName = "Palak", Email = "palak@gmail.com", Password = "Palak123",CustomerMobile= "9787965897", DefaultShippingAddress= "Raipur", CreationDateTime = DateTime.Now, LastModifiedDateTime = DateTime.Now },
             new Customer() { CustomerID = Guid.Parse("457c83a6-ffdf-44b9-a992-0637f53477fc"), CustomerName = "Arun", Email = "arun@gmail.com", Password = "Arun123",CustomerMobile= "9787965897", DefaultShippingAddress= "Mumbai", CreationDateTime = DateTime.Now, LastModifiedDateTime = DateTime.Now },
             new Customer() { CustomerID = Guid.Parse("548589fe-158e-4cd2-8eb9-4479605a2853"), CustomerName = "Kartik", Email = "kartik@gmail.com", Password = "Kartik123",CustomerMobile= "9787965897", DefaultShippingAddress= "Bangalore", CreationDateTime = DateTime.Now, LastModifiedDateTime = DateTime.Now }
        };

        //methods
        public abstract bool AddCustomerDAL(Customer newCustomer);
        public abstract bool RemoveCustomerDAL(Guid CustomerID);
        public abstract Customer GetCustomerByCustomerIDDAL(Guid searchCustomerID);
        public abstract Customer GetCustomerByEmailAndPasswordDAL(string Email, string Password);
        public abstract List<Customer> GetAllCustomersDAL();
        public abstract bool UpdateCustomerByCustomerIDDAL(Customer updateCustomer);
        public abstract bool UpdateCustomerPasswordDAL(Customer updateCustomerPassword);
        public abstract bool ForgotCustomerPasswordDAL(string Email, string Mobile);
        
    }

}

