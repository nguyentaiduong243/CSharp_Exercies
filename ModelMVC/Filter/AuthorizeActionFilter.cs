using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ModelMVC.Filter
{
    public class AuthorizeActionFilter: IAuthorizationFilter
    {
        private readonly string _permission;
        public AuthorizeActionFilter(string permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //throw new NotImplementedException();
            String role = context.HttpContext.Session.GetString("role");
            if (!isAuthorized(role))
            {
                context.Result = new UnauthorizedResult();
            }
        }

        private bool isAuthorized(string role)
        {
            if (String.IsNullOrWhiteSpace(role)) return false;
            return role == _permission || role == "Admin";
        }

        //private bool CheckUserPermission(ClaimsPrincipal role, string permission)
        //{
        //    //throw new NotImplementedException();
        //    return permission == "Admin";
        //}
    }
    
}
