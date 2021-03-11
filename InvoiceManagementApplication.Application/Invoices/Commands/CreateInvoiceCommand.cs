using System;
using System.Collections.Generic;
using InvoiceManagementApplication.Application.Invoices.DTOs;
using InvoiceManagementApplication.Domain.Enums;
using MediatR;

namespace InvoiceManagementApplication.Application.Invoices.Commands
{
    public class CreateInvoiceCommand : IRequest<int>
    {
        public CreateInvoiceCommand()
        {
            InvoiceItems = new List<InvoiceItemDto>();
        }

        public string InvoiceNumber { get; set; }
        public string Logo { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string PaymentTerms { get; set; }
        public DateTime? DueDate { get; set; }
        public float Discount { get; set; }
        public DiscountType DiscountType { get; set; }
        public float Tax { get; set; }
        public TaxType TaxType { get; set; }
        public float AmountPaid { get; set; }
        public IList<InvoiceItemDto> InvoiceItems { get; set; }
    }
}