using System;

namespace InvoiceManagementApplication.Domain.Common
{
    public class AuditEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreationTime { get; set; }

        public string LastModifiedBy { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}