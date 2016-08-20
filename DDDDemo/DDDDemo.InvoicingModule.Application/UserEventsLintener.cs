using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Common.Events;
using DDDDemo.Common.Logging;
using DDDDemo.InvoicingModule.Application.Invoices;
using DDDDemo.SharedKernel.Events;

namespace DDDDemo.InvoicingModule.Application
{
    [EventListeners]
    public class UserEventsLintener : IEventListener<UserCreatedEvent>
    {
        private readonly ILogger _logger;
        private readonly IInvoiceService _invoiceService;

        public UserEventsLintener(ILogger logger, IInvoiceService invoiceService)
        {
            _logger = logger;
            _invoiceService = invoiceService;
        }

        [EventListener]
        public void Handle(UserCreatedEvent eventData)
        {
            _logger.Info("User created! Information from InvoiceModule event Listener");
            _invoiceService.GenerateInvoiceForRegisteredUser(eventData.UserId);
        }
    }
}
