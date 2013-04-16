using Microsoft.Practices.ServiceLocation;
using OrgPort.Domain.Handlers;
using OrgPort.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace OrgPort.AuthoriztionExtentions
{
    public class Authentication: IAuthentication
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private const string cookieName = "__AUTH_COOKIE";

        public HttpContext HttpContext { get; set; }

        public IServiceLocator ServiceLocator { get; set; }

        public IAuthenticationCookieProvider AuthCookieProvider { get; set; }

        //public IRepository Repository { get; set; }

        public UserModel Login(string userName, string Password, bool isPersistent)
        {
            UserModel retUser = Using<LoginUser>().Execute(userName, Password);
            if (retUser != null)
            {
                CreateCookie(userName, isPersistent);
            }
            return retUser;
        }

        public UserModel Login(string userName)
        {
            //UserModel retUser =  Repository.Users.FirstOrDefault(p => string.Compare(p.Email, userName, true) == 0);
            UserModel retUser = Using<LoginUser>().Execute(userName);
            if (retUser != null)
            {
                CreateCookie(userName);
            }
            return retUser;
        }

        private void CreateCookie(string userName, bool isPersistent = false)
        {
            var ticket = new FormsAuthenticationTicket(
                  1,
                  userName,
                  DateTime.Now,
                  DateTime.Now.Add(FormsAuthentication.Timeout),
                  isPersistent,
                  string.Empty,
                  FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            var encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            var AuthCookie = new HttpCookie(cookieName)
            {
                Value = encTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };
            AuthCookieProvider.SetCookie(AuthCookie);
        }

        public void LogOut()
        {
            var httpCookie = AuthCookieProvider.GetCookie(cookieName);
            if (httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }
        }

        private IPrincipal _currentUser;

        public IPrincipal CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    try
                    {
                        HttpCookie authCookie = AuthCookieProvider.GetCookie(cookieName);
                        if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
                        {
                            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                            _currentUser = new UserProvider(ticket.Name, Using<LoginUser>());
                        }
                        else
                        {
                            _currentUser = new UserProvider(null, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Failed authentication: " + ex.Message);
                        _currentUser = new UserProvider(null, null);
                    }
                }
                return _currentUser;
            }
        }

        protected T Using<T>() where T : class
        {
            var handler = ServiceLocator.GetInstance<T>();
            if (handler == null)
            {
                throw new NullReferenceException("Unable to resolve type with service locator; type " + typeof(T).Name);
            }
            return handler;
        }
    }
}