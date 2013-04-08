using OrgPort.Contracts;
using OrgPort.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgPort.Domain
{
    public static class ViewModelExtentions
    {
        public static User ConvertToEntity(this ICreateUserCommand userForm)
        {
            if (userForm == null)
            {
                return null;
            }

            var vehicle = new User
            {
                UserName = userForm.UserName,
                Password = userForm.Password
            };

            return vehicle;
        }
    }
}
