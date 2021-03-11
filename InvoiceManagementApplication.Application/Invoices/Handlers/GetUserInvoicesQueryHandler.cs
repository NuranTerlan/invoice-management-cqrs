using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InvoiceManagementApplication.Application.Common.Interfaces;
using InvoiceManagementApplication.Application.Invoices.DTOs;
using InvoiceManagementApplication.Application.Invoices.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementApplication.Application.Invoices.Handlers
{
    public class GetUserInvoicesQueryHandler : IRequestHandler<GetUserInvoicesQuery, IList<InvoiceDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetUserInvoicesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<InvoiceDto>> Handle(GetUserInvoicesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<InvoiceDto>();
            var invoices = await _context.Invoices.Include(i => i.InvoiceItems)
                .Where(i => i.CreatedBy == request.UserId).ToListAsync(cancellationToken: cancellationToken);

            if (invoices != null)
            {
                result = invoices.Select(i => new InvoiceDto
                {
                    AmountPaid = i.AmountPaid,
                    CreationTime = i.CreationTime,
                    Date = i.Date,
                    Discount = i.Discount,
                    DiscountType = i.DiscountType,
                    Tax = i.Tax,
                    TaxType = i.TaxType,
                    DueDate = i.DueDate,
                    From = i.From,
                    To = i.To,
                    Id = i.Id,
                    InvoiceNumber = i.InvoiceNumber,
                    Logo = i.Logo,
                    PaymentTerms = i.PaymentTerms,
                    InvoiceItems = i.InvoiceItems.Select(item => new InvoiceItemDto
                    {
                        Id = item.Id,
                        Item = item.Item,
                        Quantity = item.Quantity,
                        Rate = item.Rate
                    }).ToList()
                }).ToList();
            }

            return result;
        }
    }
}