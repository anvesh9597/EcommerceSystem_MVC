using Ecommerce.Helpers;
using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System
{
    public static class CommonData
    {
        public static IUser CurrentUser { get; set; }
        public static UserType CurrentUserType { get; set; }
    }

}
