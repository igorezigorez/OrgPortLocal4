using OrgPort.Domain.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace OrgPort.AuthoriztionExtentions
{
    public class UserProvider : IPrincipal
    {
        private UserIndentity userIdentity { get; set; }

        public IIdentity Identity
        {
            get
            {
                return userIdentity;
            }
        }

        public bool IsInRole(string role)
        {
            if (userIdentity.User == null)
            {
                return false;
            }
            return userIdentity.User.InRoles(role);
        }

        public UserProvider(string name, LoginUser loginUserHandler)
        {
            userIdentity = new UserIndentity();
            userIdentity.Init(name, loginUserHandler);
        }


        public override string ToString()
        {
            return userIdentity.Name;
        }
    }
}