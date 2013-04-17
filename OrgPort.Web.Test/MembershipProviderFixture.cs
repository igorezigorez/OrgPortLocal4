using Microsoft.Practices.ServiceLocation;
using Moq;
//using OrgPort.AccountExtensions;
using OrgPort.Domain.Handlers;
using OrgPort.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrgPort.Web.Test
{
    public class MembershipProviderFixture
    {
        private readonly Mock<IServiceLocator> serviceLocator;

        public MembershipProviderFixture()
        {
            serviceLocator = new Mock<IServiceLocator>();
        }

        [Fact]
        public void RegisterUser_()
        {
            MockHandlerFor(
                () => new Mock<CreateUser>(),
                x => x
                    .Setup(h => h.Execute((new UserFormModel { UserName = "UserName", Password = "Password", ConfirmPassword = "Password" })))
            );

            //var membershipProvider = new OrgPortMembershipProvider(serviceLocator.Object);

            //var user = membershipProvider.CreateUserAndAccount()
        }

        Mock<T> MockHandlerFor<T>(Func<Mock<T>> create, Action<Mock<T>> setup = null) where T : class
        {
            return serviceLocator.MockHandlerFor(create, setup);
        }
    }
}
