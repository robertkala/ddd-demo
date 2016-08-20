using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Common.Logging;
using DDDDemo.InvoicingModule.Domain.Interfaces;

namespace DDDDemo.InvoicingModule.Application.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;

        public InvoiceService(IUserRepository userRepository, ILogger logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public void GenerateInvoiceForRegisteredUser(int userId)
        {
            var user = _userRepository.Get(userId);
            _logger.Info($"User get for invoice creation: {user.ToString()}");
        }
    }
}
