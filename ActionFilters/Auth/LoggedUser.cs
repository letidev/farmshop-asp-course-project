using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FarmShop.ActionFilters.Auth {
    public class LoggedUser : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext context) {
            if (context.HttpContext.Session.GetString("LoggedUsername") == null) {
                context.Result = new RedirectResult("/Home/Login");
            }
        }
    }
}
