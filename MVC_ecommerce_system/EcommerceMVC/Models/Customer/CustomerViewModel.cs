using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


/*View Model for Customers */


namespace EcommerceMVC.Models
{
    public class CustomerViewModel
    {
        public Guid CustomerID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Customer Name can't be empty")]
        [MaxLength(40, ErrorMessage = "Name cannot be longer than 40 characters.")]
        [MinLength(2, ErrorMessage = "Name should contain atleast 2 characters.")]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "Customer Name should contain alphabets only")]
        [Display(Name = "Name")]
        public string CustomerName { get; set; }


        [Required(ErrorMessage = "Customer Mobile can't be empty")]
        [MinLength(10, ErrorMessage = "Mobile number should contain ten digits.")]
        [RegularExpression("^([9876]{1})([0-9]{9})$", ErrorMessage = "Mobile number should be valid")]
        [Display(Name = "Mobile")]
        public string CustomerMobile { get; set; }

        [Required(ErrorMessage ="Shipping Address cannot be blank")]
        [RegularExpression(@"([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$", ErrorMessage ="address format is wrong")]
        public string DefaultShippingAddress { get; set; }


        [Required(ErrorMessage = "Email can't be empty")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-z0-9\-]+\.)+))([a-z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email should be in proper format")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Pasword can't be empty")]
        [MaxLength(13, ErrorMessage = "Password cannot be longer than 15 characters.")]
        [MinLength(8, ErrorMessage = "Password should contain atleast 8 characters.")]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})", ErrorMessage = "Password length can be 8 to 15 characters long and should contain atleast one UPPER case letter, one lower case letter and one digit")]
        [Display(Name = "Password")]
        public string CustomerPassword { get; set; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage = "Password can't be blank")]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})", ErrorMessage = "Password should be 8 to 15 characters with at least one digit, one uppercase letter, one lower case letter.")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm New Password")]
        [Required(ErrorMessage = "Password can't be blank")]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})", ErrorMessage = "Password should be 8 to 15 characters with at least one digit, one uppercase letter, one lower case letter.")]
        [Compare("NewPassword", ErrorMessage = "Password does not match!")]
        public string ConfirmNewPassword { get; set; }

    }
}
