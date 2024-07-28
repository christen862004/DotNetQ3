using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetQ3.Filtters
{
    public class HandelErrorAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ViewResult view = new ViewResult();
            view.ViewName = "Error";
            //view.ViewData.Model = context.Exception;
            //view.ViewData["key"] = "Value";
            //ContentResult contentresult = new ContentResult();

            //contentresult.Content = "Exception Thow" + context.Exception.Message;
            //IActionresult
            context.Result = view;
        }
    }
}
