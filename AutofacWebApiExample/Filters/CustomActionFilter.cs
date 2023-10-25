using Autofac.Integration.WebApi;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using AutofacWebApiExample.Helpers;
using System.Diagnostics;

namespace AutofacWebApiExample.Filters
{
    /// WARNING! This action filter created for compare with middleware
    public class CustomActionFilter : IAutofacActionFilter
    {
        private readonly ILogger _logger;

        public CustomActionFilter(ILogger logger)
        {
            Debugger.Break();
            _logger = logger;
        }

        public Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            Debugger.Break();
            _logger.Write("Inside the 'OnActionExecutingAsync' method of the custom action filter. BEFORE");
            return Task.FromResult(0);
        }

        public Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            Debugger.Break();
            _logger.Write("Inside the 'OnActionExecutedAsync' method of the custom action filter. AFTER");
            return Task.FromResult(0);
        }


    }
}