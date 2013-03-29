using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgPort.Model
{
    public class User
    {
        public User()
        {
            Roles = new List<UserRole>();
            RelatedUsers = new List<User>();
        }
        public int Id { get; set; }
        public string AuthorizationId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhotoLink { get; set; }
        public string AvatarLink { get; set; }
        public int Rating { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<UserRole> Roles { get; set; }
        public ICollection<User> RelatedUsers { get; set; }
        public ICollection<NewsItem> NewsItems { get; set; }
    }

    public enum UserRole
    {
        Admin,
        Teacher,
        Pupil,
        Parent,
        User
    }
}