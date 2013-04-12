using OrgPort.Data;
using OrgPort.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgPort.DB.Repository
{
    public class UserRepository : BaseDBRepository, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public Model.User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public User Login(string userName, string password)
        {
            return GetDbSet<User>().FirstOrDefault(u => (String.Compare(userName, u.UserName, true) == 0 && password == u.Password));
        }

        public User GetUserByName(string userName)
        {
            return GetDbSet<User>().FirstOrDefault(u => String.Compare(userName, u.UserName, true) == 0);
        }

        public User CreateUser(Model.User userInfo)
        {
            GetDbSet<User>().Add(userInfo);
            this.UnitOfWork.SaveAllChanges();
            return userInfo;
        }
    }
}
