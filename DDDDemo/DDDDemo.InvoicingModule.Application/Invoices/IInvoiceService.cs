using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Common.Operations;

namespace DDDDemo.InvoicingModule.Application.Invoices
{
    public interface IInvoiceService
    {
        Response GenerateInvoiceForRegisteredUser(int userId);
    }
}
