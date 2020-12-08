using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FarmShop.ActionFilters.Auth {
    public class LoggedUser : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext context) {
            if (context.HttpContext.Session.GetString("LoggedUserId") == null) {
                context.Result = new RedirectResult("/Home/Login");
            }
        }
    }
}
