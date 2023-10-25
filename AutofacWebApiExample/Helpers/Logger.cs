using System.Diagnostics;

namespace AutofacWebApiExample.Helpers
{
    public class Logger : ILogger
    {
        public void Write(string message, params object[] args)
        {
            Debug.WriteLine(message, args);
        }
    }
}