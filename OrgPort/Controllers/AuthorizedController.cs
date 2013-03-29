using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrgPort.Controllers
{
    public class AuthorizedController : Controller
    {
        //protected readonly IUserServices UserServices;
        private readonly IServiceLocator serviceLocator;

        public AuthorizedController(IServiceLocator serviceLocator)
        {
            //if (userServices == null) throw new ArgumentNullException("userServices");
            //this.UserServices = userServices;
            this.serviceLocator = serviceLocator;
        }

        protected T Using<T>() where T : class
        {
            var handler = serviceLocator.GetInstance<T>();
            if (handler == null)
            {
                throw new NullReferenceException("Unable to resolve type with service locator; type " + typeof(T).Name);
            }
            return handler;
        }
    }
}
