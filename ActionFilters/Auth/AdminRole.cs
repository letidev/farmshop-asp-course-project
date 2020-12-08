using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FarmShop.ActionFilters.Auth {
    public class AdminRole : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext context) {
            if (context.HttpContext.Session.GetString("LoggedUserRole") != "Admin") {
                context.Result = new RedirectResult("/Home/Index");
            }
        }
    }
}
