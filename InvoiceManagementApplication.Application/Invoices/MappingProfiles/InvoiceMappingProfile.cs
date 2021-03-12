using AutoMapper;
using InvoiceManagementApplication.Application.Invoices.Commands;
using InvoiceManagementApplication.Application.Invoices.DTOs;
using InvoiceManagementApplication.Domain.Entities;

namespace InvoiceManagementApplication.Application.Invoices.MappingProfiles
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceDto>().ReverseMap();

            // we can declare mapped properties by hard coding it like code below
            CreateMap<InvoiceItem, InvoiceItemDto>().ConstructUsing(i => new InvoiceItemDto
            {
                Id = i.Id,
                Item = i.Item,
                Quantity = i.Quantity,
                Rate = i.Rate
            }).ReverseMap();

            CreateMap<CreateInvoiceCommand, Invoice>();
        }
    }
}