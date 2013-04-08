using OrgPort.Contracts;
using OrgPort.DB;
using OrgPort.Domain.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrgPort.Models
{
    public class UserFormModel: ICreateUserCommand
    {
        //[TextLineInputValidator]
        [StringLength(Constants.USERNAME_MAX_LENGTH, ErrorMessageResourceName = "UserNameStringLengthValidationError", ErrorMessageResourceType = typeof(Resources))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "UserNameRequired", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "UserNameLabelText", ResourceType = typeof(Resources))]
        public string UserName
        {
            get;
            set;
        }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "PasswordLabelText", ResourceType = typeof(Resources))]
        [DataType(DataType.Password)]
        public string Password
        {
            get;
            set;
        }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(Resources))]
        [Compare("Password", ErrorMessage = "PasswordConfirmNotMatch")]
        [Display(Name = "PasswordConfirmLabelText", ResourceType = typeof(Resources))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}