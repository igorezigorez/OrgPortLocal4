using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgPort.Models
{
    public class NewsItemModel
    {
        public int Id { get; set; }
        public NewsItemType Type { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbUrl { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public DateTime TargetDate { get; set; }
        public IEnumerable<UserInformationModel> Users { get; set; }
        public IEnumerable<UserInformationModel> Tags { get; set; }

//tags
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