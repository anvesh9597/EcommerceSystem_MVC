﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.Entities
{
    public interface IUser
    {
        string Email { get; set; }
        string Password { get; set; }
    }

}
