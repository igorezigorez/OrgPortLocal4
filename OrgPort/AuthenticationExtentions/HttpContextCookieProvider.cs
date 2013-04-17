using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgPort.AuthenticationExtentions
{
    public class HttpContextCookieProvider:IAuthenticationCookieProvider
    {
        public HttpContext HttpContext { get; set; }

        public HttpCookie GetCookie(string cookieName)
        {
            return HttpContext.Request.Cookies.Get(cookieName);
        }

        public void SetCookie(HttpCookie cookie)
        {
            HttpContext.Response.Cookies.Set(cookie);
        }
    }
}