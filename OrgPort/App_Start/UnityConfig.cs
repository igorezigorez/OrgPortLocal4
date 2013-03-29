using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using OrgPort.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrgPort
{
    public static class UnityConfig
    {
        public static void RegisterUnity()
        {
            IUnityContainer container = new UnityContainer();
            container.LoadConfiguration("container");
            var serviceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(()=>serviceLocator);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}