using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgPort.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
    }
}