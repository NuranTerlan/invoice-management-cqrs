using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InvoiceManagementApplication.Application.Common.Interfaces;
using InvoiceManagementApplication.Application.Invoices.Commands;
using InvoiceManagementApplication.Domain.Entities;
using MediatR;

namespace InvoiceManagementApplication.Application.Invoices.Handlers
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateInvoiceCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = _mapper.Map<Invoice>(request);

            await _context.Invoices.AddAsync(invoice, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return invoice.Id;
        }
    }
}