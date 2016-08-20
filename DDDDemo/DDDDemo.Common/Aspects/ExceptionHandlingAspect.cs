using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using DDDDemo.Common.Logging;

namespace DDDDemo.Common.Aspects
{
    public class ExceptionHandlingAspect
    {
        private readonly ILogger _logger;

        public ExceptionHandlingAspect(ILogger logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                _logger.Error(exception);
            }
        }
    }
}
