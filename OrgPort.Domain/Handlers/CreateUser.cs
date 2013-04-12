using OrgPort.Contracts;
using OrgPort.Data;
using OrgPort.Domain.Mappers;
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

        private readonly IMapper _modelMapper;

        public CreateUser(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _modelMapper = mapper;
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
