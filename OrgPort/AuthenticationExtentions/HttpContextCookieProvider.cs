using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgPort.AuthoriztionExtentions
{
    public class HttpContextCookieProvider:IAuthenticationCookieProvider
    {
        public HttpContextCookieProvider(HttpContext HttpContext)
        {
            this.HttpContext = HttpContext;
        }

        protected HttpContext HttpContext { get; set; }

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