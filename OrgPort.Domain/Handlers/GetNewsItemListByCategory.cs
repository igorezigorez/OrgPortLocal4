using OrgPort.Contracts;
using OrgPort.Data;
using OrgPort.Domain.Models;
using OrgPort.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgPort.Domain.Handlers
{
    public class GetNewsItemListByCategory : GetNewsItemList
    {
        public GetNewsItemListByCategory(INewsItemRepository newsRepository)
            : base(newsRepository)
        { }

        public virtual IEnumerable<NewsItemModel> Execute(NewsItemType newsItemType, int count, int startIndex)
        {
            IEnumerable<NewsItem> newsItemsData = null;

            try
            {
                newsItemsData = _newsRepository.GetNewsItemListByType(newsItemType, count, startIndex);
            }
            catch
            {
                throw new BaseDomainLevelException("unable to retrieve news from database");
            }

            var newsItems = newsItemsData.Select(n => new NewsItemModel(n));

            return newsItems;
        }
    }
}
