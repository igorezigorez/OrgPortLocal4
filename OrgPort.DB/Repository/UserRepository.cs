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

        public bool ValidateUser(string name, string password)
        {
            throw new NotImplementedException();
        }

        public User CreateUser(Model.User userInfo)
        {
            GetDbSet<User>().Add(userInfo);
            this.UnitOfWork.SaveAllChanges();
            return userInfo;
        }
    }
}
