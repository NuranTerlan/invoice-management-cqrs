using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceManagementApplication.Application.Common.Interfaces;
using InvoiceManagementApplication.Application.Invoices.Commands;
using InvoiceManagementApplication.Application.Invoices.DTOs;
using InvoiceManagementApplication.Application.Invoices.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementApplication.API.Controllers
{
    [Authorize]
    public class InvoicesController : ApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public InvoicesController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        [HttpPost("/api/invoices")]
        public async Task<int> Create([FromBody] CreateInvoiceCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("api/invoices")]
        public async Task<IList<InvoiceDto>> Get()
        {
            var query = new GetUserInvoicesQuery { UserId = _currentUserService.UserId };
            return await Mediator.Send(query);
        }
    }
}