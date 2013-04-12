using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgPort.Model;

namespace OrgPort.Data
{
    public interface IUserRepository
    {
        User GetUser(int id);
        User Login(string userName, string password);
        User GetUserByName(string userName);
        User CreateUser(User userInfo);
        
    }
}
