using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgPort.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public UserInformationModel User { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
    }
}