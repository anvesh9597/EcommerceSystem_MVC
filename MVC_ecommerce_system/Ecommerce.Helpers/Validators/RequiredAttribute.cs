using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.Helpers.Validators
{
    public class RequiredAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
        public RequiredAttribute() : base()
        {

        }
        public RequiredAttribute(string msg) : base()
        {
            ErrorMessage = msg;
        }
    }

}
