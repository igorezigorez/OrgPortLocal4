using OrgPort.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgPort.Data
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetTagsByNewsItemId(NewsItem NewsItemId);

        void AddTagForNewsItem(IEnumerable<string> tags, int NewsItemId);
    }
}
