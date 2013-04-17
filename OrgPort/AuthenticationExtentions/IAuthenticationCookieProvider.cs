using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OrgPort.AuthenticationExtentions
{
    public interface IAuthenticationCookieProvider
    {
        HttpContext HttpContext { get; set; }

        HttpCookie GetCookie(string cookieName);

        void SetCookie(HttpCookie cookie);
    }
}
