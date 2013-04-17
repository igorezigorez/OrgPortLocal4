using OrgPort.AuthenticationExtentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrgPort.Web.Test
{
    public class AuthenticationFixture
    {
        [Fact]
        public void LoginUser_ReturnsUser()
        {
            var authentication = new Authentication();

            var 

            var userName = "user1";
            var password = "user1";
            var result = authentication.Login(userName, password, true);

            Assert.NotNull(result);
            Assert.Equal(result.UserName, userName);
        }
    }
}
