using OrgPort.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgPort.AuthoriztionExtentions
{
    public interface IUserProvider
    {
        UserModel User { get; set; }
    }
}
