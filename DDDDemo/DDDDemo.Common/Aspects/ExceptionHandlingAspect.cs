using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using DDDDemo.Common.Logging;
using DDDDemo.Common.Operations;

namespace DDDDemo.Common.Aspects
{
    public class ExceptionHandlingAspect : IInterceptor
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
                invocation.ReturnValue = Response.CreateFailureResponse(exception.Message);
            }
        }
    }
}
