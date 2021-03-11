using InvoiceManagementApplication.Domain.Common;

namespace InvoiceManagementApplication.Domain.Entities
{
    public class InvoiceItem : AuditEntity
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string Item { get; set; }
        public float Quantity { get; set; }
        public float Rate { get; set; }

        public Invoice Invoice { get; set; }
    }
}