using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgPort.Model
{
    public class NewsItem
    {
        public NewsItem()
        {
            Type = NewsItemType.NewsItem;
            Date = DateTime.UtcNow;
            TargetDate = DateTime.UtcNow;
            Users = new List<User>();
            Tags = new List<Tag>();
        }

        public int Id { get; set; }
        public NewsItemType Type { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImagePath { get; set; }
        public string ImageThumbPath { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public DateTime TargetDate { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }

    public enum NewsItemType
    {
        NewsItem,
        PublicEvent,
        Report,
        Reward,
        Person
    }
}