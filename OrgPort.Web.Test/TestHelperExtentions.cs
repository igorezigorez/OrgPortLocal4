using Microsoft.Practices.ServiceLocation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgPort.Web.Test
{
    public static class TestHelperExtentions
    {
        public static Mock<T> MockHandlerFor<T>(this Mock<IServiceLocator> serviceLocator, Func<Mock<T>> create, Action<Mock<T>> setup = null) where T : class
        {
            var mock = create();

            if (setup != null) setup(mock);

            serviceLocator
                .Setup(s => s.GetInstance<T>())
                .Returns(mock.Object);

            return mock;

        }
    }
}
