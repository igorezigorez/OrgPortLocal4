using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrgPort.Models
{
    [Table("UserInformation")]
    public class UserInformationModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PhotoLink { get; set; }
        public string AvatarLink { get; set; }
        public int Rating { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IEnumerable<UserRole> Roles { get; set; }
        public IEnumerable<UserInformationModel> RelatedUsers { get; set; }
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