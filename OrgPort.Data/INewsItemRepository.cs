using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgPort.Data;
using OrgPort.Model;

namespace OrgPort.Data
{
    public interface INewsItemRepository
    {
        void CreateNewsItem(NewsItem newsItem);
        NewsItem GetNewsItemById(int id);
        IEnumerable<NewsItem> GetNewsItemList(int count, int startIndex);
        IEnumerable<NewsItem> GetNewsItemListByType(NewsItemType newsItemType, int count, int startIndex);
        IEnumerable<NewsItem> GetNewsItemListByTag(Tag tag, int count, int startIndex);
        IEnumerable<NewsItem> GetNewsItemListByUser(User person, int count, int startIndex);
        IEnumerable<NewsItem> GetNewsItemListByDate(DateTime upToDate, TimeSpan period, int count, int startIndex);
    }
}
