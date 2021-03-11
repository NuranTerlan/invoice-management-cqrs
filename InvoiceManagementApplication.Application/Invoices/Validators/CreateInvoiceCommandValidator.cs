using FluentValidation;
using InvoiceManagementApplication.Application.Invoices.Commands;

namespace InvoiceManagementApplication.Application.Invoices.Validators
{
    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
        {
            RuleFor(i => i.AmountPaid).NotNull();
            RuleFor(i => i.Date).NotNull();
            RuleFor(i => i.From).NotEmpty().MinimumLength(3);
            RuleFor(i => i.To).NotEmpty().MinimumLength(3);
            RuleFor(i => i.InvoiceItems)
                .SetValidator(new MustHaveInvoiceItemPropertyValidator());
        }
    }
}