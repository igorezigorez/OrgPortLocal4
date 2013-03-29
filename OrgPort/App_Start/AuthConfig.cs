using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using OrgPort.Models;

namespace OrgPort
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "1",
                consumerSecret: "2");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "1",
                appSecret: "2");

            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
