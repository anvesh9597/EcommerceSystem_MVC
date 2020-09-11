using Ecommerce.System.Ecommerce.Helpers.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.Entities
{
    public interface ICustomer
    {
        Guid CustomerID { get; set; }
        string CustomerName { get; set; }
       /* string BillingAddress { get; set; }*/
        string DefaultShippingAddress { get; set; }
        string CustomerMobile { get; set; }
        
        /*string PaymentInfo { get; set; }*/
        DateTime CreationDateTime { get; set; }
        DateTime LastModifiedDateTime { get; set; }

    }

    public class Customer : ICustomer,IUser
    {

        [Required("Customer ID cannot be blank")]
        public Guid CustomerID { get; set; }

        [Required("Customer Name cannot be blank")]
        [RegExp("[a-zA-Z]$", "name format is wrong, should not contain numbers or special characters")]
        public string CustomerName { get; set; }

        [Required("Customer Mobile cannot be blank")]
        [RegExp(@"\+?[0-9]{10}", "please enter valid mobile number")]
        public string CustomerMobile { get; set; }

        [Required("Email cannot be blank")]
        [RegExp(@"([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", "please enter valid email")]
        public string Email { get; set; }

        /*[Required("Billing Address cannot be blank")]
        [RegExp(@"([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$", "address format is wrong")]
        public string BillingAddress { get; set; }*/

        [Required("Shipping Address cannot be blank")]
        [RegExp(@"([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$", "address format is wrong")]
        public string DefaultShippingAddress { get; set; }

        [Required("Password can't be blank.")]
        [RegExp(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})", "Password should be 6 to 15 characters with at least one digit, one uppercase letter, one lower case letter.")]
        public string Password { get; set; }

        [Required("Card Number cannot be blank")]
        [RegExp(@"\+?[0-9]{16}", "please enter valid card number")]
       /* public string PaymentInfo { get; set; }*/
        public DateTime CreationDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }



        //constructor
        public Customer()
        {
            CustomerID = default(Guid);
        }
      
    }
}
