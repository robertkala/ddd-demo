using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using DDDDemo.Common.Logging;

namespace DDDDemo.Common.Aspects
{
    public class LoggingAspect
    {
        private readonly ILogger _logger;

        public LoggingAspect(ILogger logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            _logger.Info($"Method {invocation.Method.Name} started at: {DateTime.Now}");

            invocation.Proceed();

            _logger.Info($"Method {invocation.Method.Name} ended at: {DateTime.Now}");
        }
    }
}
