using System.Reflection;
using AutoMapper;
using FluentValidation;
using InvoiceManagementApplication.Application.Common.Behaviors;
using InvoiceManagementApplication.Application.Invoices.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceManagementApplication.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateInvoiceCommand));
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}