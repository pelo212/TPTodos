using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TPTodos.Controllers
{
    public class AuthController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (HttpContext.Session.GetString("Login") == null)
            {
                context.Result= new RedirectResult("/Users/Login");
            }
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
