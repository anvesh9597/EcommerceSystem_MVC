using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.Exceptions
{
    public class AdminNotFoundException : ApplicationException
    {
        public AdminNotFoundException(string msg) : base(msg)
        {

        }
    }

}
