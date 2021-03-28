using Microsoft.AspNetCore.Mvc;

namespace ModelMVC.Filter
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(string permission) : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { permission };
        }
    }
}
