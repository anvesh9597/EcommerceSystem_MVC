using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



/*
 Login View Model 
 
 */


namespace EcommerceMVC.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email can't be blank")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Enter a valid Email ID")]
        public string Email { get; set; }

        /*Password for User with validation for required, regular expression to check for 6 to 15 characters length, one 
        upper case, one lower case and one digit*/
        [Display(Name = "Password")]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})", ErrorMessage = "Password should be 6 to 15 characters with at least one digit, one uppercase letter, one lower case letter.")]
        [Required(ErrorMessage = "Password can be blank")]
        public string Password { get; set; }

        public  string UserType { get; set; }

        public  string[] UserTypes = { "Admin", "Customer" };

    }
}
