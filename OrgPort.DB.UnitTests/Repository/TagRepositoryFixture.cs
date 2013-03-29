using OrgPort.DB.Repository;
using OrgPort.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace OrgPort.DB.UnitTests.Repository
{
    class TagRepositoryFixture
    {
        [Fact]
        public void ConstructedWithNullUnitOfWork_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new NewsItemRepository(null));
        }

        [Fact]
        public void GetAllFromEmptyDatabase_ReturnsEmptyCollection()
        {
            
        }
    }
}
