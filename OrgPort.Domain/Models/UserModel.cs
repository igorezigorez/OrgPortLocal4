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
    public class UserModel
    {
        public int UserId { get; set; }

        [StringLength(15, ErrorMessageResourceName = "UserDisplayNameStringLengthValidationError", ErrorMessageResourceType = typeof(Resources))]
        //[TextLineInputValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "UserDisplayNameRequired", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "UserDisplayNameLabelText", ResourceType = typeof(Resources))]
        public string UserName { get; set; }

        public string Password { get; set; }

        [Required(ErrorMessageResourceName = "UserAuthorizationIdRequired", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "UserAuthorizationIdLabelText", ResourceType = typeof(Resources))]
        public string AuthorizationId { get; set; }

        public bool HasRegistered { get; set; }

        public ICollection<UserRole> Roles { get; set; }

        public bool InRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }

            var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var role in rolesArray)
            {
                //var hasRole = Roles.Any(p => string.Compare(p.Role.Code, role, true) == 0);
                //if (hasRole)
                //{
                //    return true;
                //}
            }
            return false;
        }
    }
}
