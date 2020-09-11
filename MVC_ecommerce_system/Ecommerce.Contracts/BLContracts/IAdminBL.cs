using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.Contracts.BLContracts
{
    public interface IAdminBL
    {
        public Admin GetAdminByAdminIDBL(Guid searchAdminID);
        public Admin GetAdminByEmailAndPasswordBL(string email, string password);
        public bool UpdateAdminBL(Admin updateAdmin);
        public bool UpdateAdminPasswordBL(Admin updateAdminPassword);
        public bool UpdateAdminForgotPasswordBL(string email);

    }
}
