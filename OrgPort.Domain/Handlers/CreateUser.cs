using OrgPort.Contracts;
using OrgPort.Data;
using OrgPort.Domain.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgPort.Domain.Handlers
{
    public class CreateUser
    {
        private readonly IUserRepository _userRepository;

        public CreateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public virtual void Execute(ICreateUserCommand userForm)
        {
            if (userForm == null) throw new ArgumentNullException("userForm");

            try
            {
                var user = userForm.ConvertToEntity();
                _userRepository.CreateUser(user);
            }
            catch (InvalidOperationException ex)
            {
                throw new BaseDomainLevelException(Resources.UnableToCreateUserExceptionMessage, ex);
            }
        }
    }
}
