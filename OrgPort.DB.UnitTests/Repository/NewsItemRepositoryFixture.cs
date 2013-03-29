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
    public class NewsItemRepositoryFixture
    {

        public NewsItemRepositoryFixture()
        {
            InitializeFixture();
        }

        private void InitializeFixture()
        {
            DBTestUtility.DropCreateOrgPortDatabase();
        }

        [Fact]
        public void ConstructedWithNullUnitOfWork_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new NewsItemRepository(null));
        }

        [Fact]
        public void GetAllFromEmptyDatabase_ReturnsEmptyCollection()
        {
            
            var repository = new NewsItemRepository(new OrgPortDBContext());
            IEnumerable<NewsItem> actual = repository.GetNewsItemList(10, 0);
            Assert.NotNull(actual);
            List<NewsItem> actualList = actual.ToList();
            Assert.Equal(actualList.Count(), 0);
        }

        [Fact]
        public void NewsItemAdded_UpdateRepository()
        {
            var repository = new NewsItemRepository(new OrgPortDBContext());

            var newsItem = new NewsItem { Title = "title", Text = "text" };

            repository.CreateNewsItem(newsItem);

            List<NewsItem> actualList = new OrgPortDBContext().NewsItems.ToList();

            Assert.Equal(actualList.Count(), 1);
            Assert.Equal(newsItem.Title, actualList[0].Title);
        }
    }
}
