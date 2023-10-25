using AutofacWebApiExample.Helpers;
using Microsoft.Owin;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AutofacWebApiExample.OwinMiddlewares
{
    public class FirstMiddleware : OwinMiddleware
    {
        private readonly ILogger _logger;

        public FirstMiddleware(OwinMiddleware next, ILogger logger) : base(next)
        {
            Debugger.Break();
            _logger = logger;
        }

        public override async Task Invoke(IOwinContext context)
        {
            Debugger.Break();
            _logger.Write("Inside the 'Invoke' method of the '{0}' middleware. BEFORE", GetType().Name);
            await Next.Invoke(context);
            Debugger.Break();
            _logger.Write("Inside the 'Invoke' method of the '{0}' middleware. AFTER", GetType().Name);
        }


    }
}