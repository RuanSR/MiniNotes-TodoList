using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MiniNotes.Library.Filters
{
    public class LoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Login") == null)
            {
                if (context.Controller != null)
                {
                    Controller controller = context.Controller as Controller;
                    controller.TempData["INDEX_ERROR_MSG"] = "Faça login para ver suas anotações";
                }
                context.Result = new RedirectToActionResult("Index", "Index", null);
            }
        }
    }
}
