using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Invest.Services.Api.Infrastructure
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HandleDefaultException(context);
            context.ExceptionHandled = true;
        }

        static void HandleDefaultException(ExceptionContext context)
        {
            context.Result = new InternalServerErrorObjectResult("An error occurred");
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}