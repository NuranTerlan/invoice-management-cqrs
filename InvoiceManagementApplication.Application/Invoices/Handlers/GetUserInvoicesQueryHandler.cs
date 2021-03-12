using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetUserInvoicesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<InvoiceDto>> Handle(GetUserInvoicesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<InvoiceDto>();
            var invoices = await _context.Invoices.Include(i => i.InvoiceItems)
                .Where(i => i.CreatedBy == request.UserId).ToListAsync(cancellationToken: cancellationToken);

            if (invoices != null)
            {
                result = _mapper.Map<List<InvoiceDto>>(invoices);
            }

            return result;
        }
    }
}