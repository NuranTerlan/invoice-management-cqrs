using System.Collections;
using System.Collections.Generic;
using FluentValidation.Validators;
using InvoiceManagementApplication.Application.Invoices.DTOs;
using Microsoft.EntityFrameworkCore.Internal;

namespace InvoiceManagementApplication.Application.Invoices.Validators
{
    public class MustHaveInvoiceItemPropertyValidator : PropertyValidator
    {
        public MustHaveInvoiceItemPropertyValidator()
            :base("Property {PropertyName} should not be an empty list")
        {
            
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var list = context.PropertyValue as IList<InvoiceItemDto>;
            return list != null && list.Any();
        }
    }
}