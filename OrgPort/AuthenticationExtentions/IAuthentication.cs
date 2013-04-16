using OrgPort.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OrgPort.AuthoriztionExtentions
{
    public interface IAuthentication
    {
        IAuthenticationCookieProvider AuthCookieProvider { get; set; }

        HttpContext HttpContext { get; set; }

        UserModel Login(string login, string password, bool isPersistent);

        UserModel Login(string login);

        void LogOut();

        IPrincipal CurrentUser { get; }
    }
}
