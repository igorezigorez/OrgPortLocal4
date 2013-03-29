using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgPort.UnityExtensions
{
    public class HttpPerRequestLifetimeManager : PerRequestLifetimeManager
    {
        public HttpPerRequestLifetimeManager()
            : base(new HttpContextPerRequestStore())
        {

        }
    }
}