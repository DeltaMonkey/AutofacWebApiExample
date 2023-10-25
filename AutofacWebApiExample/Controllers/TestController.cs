using AutofacWebApiExample.Helpers;
using System.Diagnostics;
using System.Web.Http;

namespace AutofacWebApiExample.Controllers
{
    public class TestController : ApiController
    {
        private readonly ILogger _logger;

        public TestController(ILogger logger)
        {
            Debugger.Break();
            _logger = logger;
        }

        public string Get()
        {
            Debugger.Break();
            _logger.Write("Inside the 'Get' method of the '{0}' controller.", GetType().Name);
            return "Hello, world!";
        }
    }
}