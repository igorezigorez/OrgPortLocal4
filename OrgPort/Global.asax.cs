using NLog;
using OrgPort.AuthoriztionExtentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OrgPort
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            logger.Info("Application Start");

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            UnityConfig.RegisterUnity();
            DataSourceConfig.RegisterDataBase();
        }

        public void Init()
        {
            logger.Info("Application Init");
            base.Init();
        }

        public void Dispose()
        {
            logger.Info("Application Dispose");
            base.Dispose();
        }

        protected void Application_Error()
        {
            logger.Info("Application Error");
        }


        protected void Application_End()
        {
            logger.Info("Application End");
        }

        protected void Application_AuthenticateRequest()
        {
            var context = HttpContext.Current;
            var authentication = DependencyResolver.Current.GetService<IAuthentication>();
            authentication.AuthCookieProvider = DependencyResolver.Current.GetService<IAuthenticationCookieProvider>();
            authentication.HttpContext = context;
            context.User = authentication.CurrentUser;
        }
    }
}