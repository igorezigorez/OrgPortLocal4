using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OrgPort.Web.Test.AuthMocks
{
    public class MockHttpServerUtility : Mock<HttpServerUtilityBase>
    {
        public MockHttpServerUtility(MockBehavior mockBehavior = MockBehavior.Strict)
            : base(mockBehavior)
        {

        }
    }
}
