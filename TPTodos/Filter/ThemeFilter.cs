using Microsoft.AspNetCore.Mvc.Filters;

namespace TPTodos.Filter
{
    public class ThemeFilter : ActionFilterAttribute
    {
        public static string GetTheme(HttpContext context)
        {
            string theme = context.Session.GetString("theme") ?? "light";
            return theme;
        }
    }
}
