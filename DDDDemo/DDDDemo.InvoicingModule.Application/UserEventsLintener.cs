using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Common.Events;
using DDDDemo.Common.Logging;
using DDDDemo.SharedKernel.Events;

namespace DDDDemo.InvoicingModule.Application
{
    [EventListeners]
    public class UserEventsLintener : IEventListener<UserCreatedEvent>
    {
        private readonly ILogger _logger;

        public UserEventsLintener(ILogger logger)
        {
            _logger = logger;
        }

        [EventListener]
        public void Handle(UserCreatedEvent eventData)
        {
            _logger.Info("User created! Information from event Listener");
        }
    }
}
