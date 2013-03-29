using Microsoft.Practices.ServiceLocation;
using OrgPort.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgPort
{
    public static class DataSourceConfig
    {
        public static void RegisterDataBase()
        {
            var repositoryInitializer = ServiceLocator.Current.GetInstance<IRepositoryInitializer>();
            repositoryInitializer.Initialize();           
        }
    }
}