﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OrgPort.Web.Test.AuthMocks
{
    public class FakeAuthCookieProvider : IAuthCookieProvider
    {
        //[Inject]
        public HttpCookieCollection Cookies { get; set; }

        public HttpCookie GetCookie(string cookieName)
        {
            return Cookies.Get(cookieName);
        }

        public void SetCookie(HttpCookie cookie)
        {
            if (Cookies.Get(cookie.Name) != null)
            {
                Cookies.Remove(cookie.Name);
            }
            Cookies.Add(cookie);
        }
    }
}
