using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace OrgPort.Web.Test.AuthMocks
{
    public interface IAuthCookieProvider
    {
        HttpCookie GetCookie(string cookieName);
        void SetCookie(HttpCookie cookie);
    }
}
