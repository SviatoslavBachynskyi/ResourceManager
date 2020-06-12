using Microsoft.AspNetCore.Authorization;
using ResourceManager.Core.Models;
using System;
using System.Linq;

namespace ResourceManager.Authorize
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params Role[] allowedRoles)
        {
            var allowedRolesAsStrings = allowedRoles.Select(x => Enum.GetName(typeof(Role), x));
            this.Roles = string.Join(",", allowedRolesAsStrings);
        }
    }
}
