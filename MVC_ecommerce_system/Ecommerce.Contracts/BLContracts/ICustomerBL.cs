using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.Contracts.BLContracts
{
    public interface ICustomerBL
    {
        public Customer GetCustomerByCustomerIDBL(Guid CustomerID);
        public bool AddCustomerBL(Customer newCustomer);
        public bool RemoveCustomerBL(Guid CustomerID);
        public List<Customer> GetAllCustomersBL();
        public bool UpdateCustomerByCustomerIDBL(Customer updateCustomer);
        public Customer GetCustomerByEmailAndPasswordBL(string Email, string Password);
        public abstract bool UpdateCustomerPasswordBL(Customer updateCustomerPassword);
        public abstract bool ForgotCustomerPasswordBL(string Email, string Mobile);

    }
}
