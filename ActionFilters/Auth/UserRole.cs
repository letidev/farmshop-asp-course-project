using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FarmShop.ActionFilters.Auth {
    public class UserRole : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext context) {
            if(context.HttpContext.Session.GetString("LoggedUserRole") != "User") {
                context.Result = new RedirectResult("/Home/Index");
            }   
        }
    }
}
