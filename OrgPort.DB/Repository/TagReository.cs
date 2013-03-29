using OrgPort.Data;
using OrgPort.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgPort.DB.Repository
{
    public class TagReository : BaseDBRepository, ITagRepository
    {
        public TagReository(IUnitOfWork unitOfWork): base(unitOfWork) {}

        public IEnumerable<Tag> GetTagsByNewsItemId(NewsItem newsItem)
        {
            return GetDbSet<Tag>().Where(t => t.NewsItems.Contains(newsItem));
        }

        public void AddTagForNewsItem(IEnumerable<string> tags, int NewsItemId)
        {
            foreach (var tag in tags)
            {
                if (GetDbSet<Tag>().Where(t => t.Text == tag).Count() == 0)
                {
                    GetDbSet<Tag>().Add(new Tag { Text = tag });
                }
            }
        }
    }
}
