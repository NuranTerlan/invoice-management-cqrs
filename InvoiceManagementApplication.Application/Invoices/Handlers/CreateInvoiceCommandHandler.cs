using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InvoiceManagementApplication.Application.Common.Interfaces;
using InvoiceManagementApplication.Application.Invoices.Commands;
using InvoiceManagementApplication.Domain.Entities;
using MediatR;

namespace InvoiceManagementApplication.Application.Invoices.Handlers
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateInvoiceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = new Invoice
            {
                AmountPaid = request.AmountPaid,
                Date = request.Date,
                Discount = request.Discount,
                DiscountType = request.DiscountType,
                Tax = request.Tax,
                TaxType = request.TaxType,
                DueDate = request.DueDate,
                From = request.From,
                To = request.To,
                InvoiceNumber = request.InvoiceNumber,
                Logo = request.Logo,
                PaymentTerms = request.PaymentTerms,
                InvoiceItems = request.InvoiceItems.Select(item => new InvoiceItem
                {
                    Item = item.Item,
                    Quantity = item.Quantity,
                    Rate = item.Rate
                }).ToList()
            };

            await _context.Invoices.AddAsync(invoice, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return invoice.Id;
        }
    }
}