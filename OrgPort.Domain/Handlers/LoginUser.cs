using OrgPort.Contracts;
using OrgPort.Data;
using OrgPort.Domain.Mappers;
using OrgPort.Domain.Models;
using OrgPort.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgPort.Domain.Handlers
{
    public class LoginUser
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _modelMapper;

        public LoginUser(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _modelMapper = mapper;
        }

        //todo: should return domain-level model
        public virtual UserModel Execute(string name, string password)
        {
            UserModel userModel;
            try
            {
                var user = _userRepository.Login(name, password);
                //todo: cheeck for default
                userModel = (UserModel)_modelMapper.Map(user, typeof(User), typeof(UserModel));
            }
            catch
            {
                throw new BaseDomainLevelException("unable to retrieve user from database");
            }

            return userModel;
        }

        public virtual UserModel Execute(string name)
        {
            UserModel userModel;
            try
            {
                var user = _userRepository.GetUserByName(name);
                //todo: cheeck for default
                userModel = (UserModel)_modelMapper.Map(user, typeof(User), typeof(UserModel));
            }
            catch
            {
                throw new BaseDomainLevelException("unable to retrieve user from database");
            }

            return userModel;
        }
    }
}
