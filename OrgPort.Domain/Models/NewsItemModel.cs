using OrgPort.DB;
using OrgPort.Domain.Properties;
using OrgPort.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgPort.Domain.Models
{
    public class NewsItemModel
    {
        public NewsItemModel(NewsItem newsItem)
        {
            _newsItem = newsItem;
        }

        [StringLength(Constants.TITLE_MAX_LENGTH, ErrorMessageResourceName="Error", ErrorMessageResourceType=typeof(Resources))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "NewsTitleRequired", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "NewsTitleLabelText", ResourceType = typeof(Resources))]
        public string Title { get { return _newsItem.Title; } }
                
        [StringLength(Constants.TITLE_MAX_LENGTH, ErrorMessageResourceName = "Error", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "NewsSubTitleLabelText", ResourceType = typeof(Resources))]
        public string SubTitle { get { return _newsItem.SubTitle; } }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "NewsContentRequired", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "NewsContentLabelText", ResourceType = typeof(Resources))]
        public string Text { get { return _newsItem.Text; } }

        [Required(ErrorMessageResourceName = "NewsDateRequired", ErrorMessageResourceType = typeof(Resources))]
        public DateTime Date { get { return _newsItem.Date; } }

        public int Rating { get { return _newsItem.Rating; } }
        
        public NewsItemType NewsItemType { get { return _newsItem.Type; } }

        private NewsItem _newsItem;
    }
}
