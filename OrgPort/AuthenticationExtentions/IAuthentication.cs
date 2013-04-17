using Microsoft.Practices.ServiceLocation;
using OrgPort.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OrgPort.AuthenticationExtentions
{
    public interface IAuthentication
    {
        IAuthenticationCookieProvider AuthenticationCookieProvider { get; set; }

        IServiceLocator ServiceLocator { get; set; }

        HttpContext HttpContext { get; set; }

        UserModel Login(string login, string password, bool isPersistent);

        UserModel Login(string login);

        void LogOff();

        IPrincipal CurrentUser { get; }
    }
}
