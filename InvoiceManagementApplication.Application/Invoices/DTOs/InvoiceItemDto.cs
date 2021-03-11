namespace InvoiceManagementApplication.Application.Invoices.DTOs
{
    public class InvoiceItemDto
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public float Quantity { get; set; }
        public float Rate { get; set; }

        public float Amount => Rate * Quantity;
    }
}