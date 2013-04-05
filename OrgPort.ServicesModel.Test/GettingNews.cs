using Moq;
using OrgPort.Data;
using OrgPort.Domain.Handlers;
using OrgPort.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrgPort.ServicesModel.Test
{
    public class GettingNews
    {
        private readonly Mock<INewsItemRepository> _newsItemRepository;
        private const int _defaultStartIndex = 0;
        private const int _defaultCount = 2;
        private const NewsItemType _defaultNewsItemType = NewsItemType.NewsItem;
        private readonly List<Tag> _tags;
        private readonly List<User> _users;

        public GettingNews()
        {
            _newsItemRepository = new Mock<INewsItemRepository>();
            _tags = new List<Tag>();
            _tags.Add(new Tag { Text = "tag1" });
            _tags.Add(new Tag { Text = "tag2" });
            _users = new List<User>();
            _users.Add(new User { UserName = "user1" });
            _users.Add(new User { UserName = "user2" });
        }

        [Fact]
        public void NewsItemAdded_UpdateRepository()
        {
            _newsItemRepository
                .Setup(r => r.GetNewsItemListByType(_defaultNewsItemType, _defaultCount, _defaultStartIndex))
                .Returns(new NewsItem[] { new NewsItem(), new NewsItem() })
                .Verifiable();

            var handler = new GetNewsItemListByCategory(_newsItemRepository.Object);
            var result = handler.Execute(_defaultNewsItemType, _defaultCount, _defaultStartIndex);
            _newsItemRepository.Verify();

            Assert.NotNull(result);
            Assert.Equal(result.Count(), 2);
        }

        [Fact]
        public void NewsItemsAll_ReturnNews()
        {
            var news = new List<NewsItem> { new NewsItem(), new NewsItem() };

            _newsItemRepository
                .Setup(r => r.GetNewsItemList(_defaultCount, _defaultStartIndex))
                .Returns(news);

            var handler = new GetNewsItemList(_newsItemRepository.Object);
            var result = handler.Execute(_defaultCount, _defaultStartIndex);

            Assert.Equal(result.Count(), news.Count());
        }

        [Fact]
        public void NewsItemsByTag_ReturnNews()
        {
            var news = new List<NewsItem>  { new NewsItem { Tags = _tags }, new NewsItem { Tags = _tags }};

            _newsItemRepository
                .Setup(r => r.GetNewsItemListByTag(_tags.First(), _defaultCount, _defaultStartIndex))
                .Returns(news);

            var handler = new GetNewsItemListByTag(_newsItemRepository.Object);
            var result = handler.Execute(_tags.First(), _defaultCount, _defaultStartIndex);
            
            Assert.Equal(result.Count(), news.Count());
        }

        [Fact]
        public void NewsItemsByUser_ReturnNews()
        {
            var news = new List<NewsItem> { new NewsItem { Users = _users }, new NewsItem { Users = _users } };

            _newsItemRepository
                .Setup(r => r.GetNewsItemListByUser(_users.First(), _defaultCount, _defaultStartIndex))
                .Returns(news);

            var handler = new GetNewsItemListByUser(_newsItemRepository.Object);
            var result = handler.Execute(_users.First(), _defaultCount, _defaultStartIndex);
            
            Assert.Equal(result.Count(), news.Count());
        }
    }
}
