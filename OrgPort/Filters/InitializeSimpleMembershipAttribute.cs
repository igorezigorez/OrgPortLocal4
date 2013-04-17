using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using OrgPort.Models;
using OrgPort.DB.Initializers;
using OrgPort.DB;
//using OrgPort.AccountExtensions;
using System.Web.Security;
using Microsoft.Practices.ServiceLocation;

namespace OrgPort.Filters
{
    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    //public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    //{
    //    private static SimpleMembershipInitializer _initializer;
    //    private static object _initializerLock = new object();
    //    private static bool _isInitialized;

    //    public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        // Ensure ASP.NET Simple Membership is initialized only once per app start
    //        LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
    //    }

    //    private class SimpleMembershipInitializer
    //    {
    //        public SimpleMembershipInitializer()
    //        {
    //            //Database.SetInitializer<UsersContext>(null);

    //            try
    //            {
    //                OrgPortWebSecurity.Initialize(ServiceLocator.Current);
    //                //WebSecurity.InitializeDatabaseConnection("OrgPort.DB.OrgPortDBContext", "Users", "Id", "UserName", false);
    //                //(Membership.Provider as OrgPortMembershipProvider).ServiceLocator = ServiceLocator.Current;
    //            }
    //            catch (Exception ex)
    //            {
    //                throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
    //            }
    //        }
    //    }
    //}
}
