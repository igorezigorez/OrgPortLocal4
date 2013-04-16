using OrgPort.Domain.Handlers;
using OrgPort.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace OrgPort.AuthoriztionExtentions
{
    public class UserIndentity : IIdentity, IUserProvider
    {
        public UserModel User { get; set; }
        public IAuthentication Auth { get; set; }

        public string AuthenticationType
        {
            get
            {
                return typeof(UserModel).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.UserName;
                }
                //todo: replace mazafaka
                return "anonym";
            }
        }

        public void Init(string userName, LoginUser loginUserHandler)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                User = loginUserHandler.Execute(userName);
            }
        }

        public UserModel CurrentUser
        {
            get
            {
                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        }
    }
}