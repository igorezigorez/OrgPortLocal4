using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;

namespace OrgPort.AccountExtensions
{
    public static class OrgPortWebSecurity
    {
        public static bool Initialized { get; private set; }

        public static string CurrentUserName
        {
            get { return Context.User.Identity.Name; }
        }

        internal static HttpContextBase Context
        {
            get { return new HttpContextWrapper(HttpContext.Current); }
        }

        internal static HttpRequestBase Request
        {
            get { return Context.Request; }
        }

        internal static HttpResponseBase Response
        {
            get { return Context.Response; }
        }

        public static void Initialize(IServiceLocator serviceLocator)
        {
            var membershipProvider = Membership.Provider as OrgPortMembershipProvider;
            membershipProvider.ServiceLocator = serviceLocator;
            Initialized = true;
        }
    }
}