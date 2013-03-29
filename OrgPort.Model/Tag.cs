using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgPort.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public ICollection<NewsItem> NewsItems { get; set; }
    }
}