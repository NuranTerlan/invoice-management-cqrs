using System.Collections.Generic;
using InvoiceManagementApplication.Application.Invoices.DTOs;
using MediatR;

namespace InvoiceManagementApplication.Application.Invoices.Queries
{
    public class GetUserInvoicesQuery : IRequest<IList<InvoiceDto>>
    {
        public string UserId { get; set; }
    }
}