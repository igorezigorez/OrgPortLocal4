using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgPort.Model
{
    public class Question
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TargetUserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
    }
}