using System;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Options;
using InvoiceManagementApplication.Application.Common.Interfaces;
using InvoiceManagementApplication.Domain.Common;
using InvoiceManagementApplication.Domain.Entities;
using InvoiceManagementApplication.Infrastructure.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace InvoiceManagementApplication.Infrastructure.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions, ICurrentUserService currentUserService) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (var entityEntry in ChangeTracker.Entries<AuditEntity>())
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        entityEntry.Entity.CreatedBy = _currentUserService.UserId;
                        entityEntry.Entity.CreationTime = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entityEntry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entityEntry.Entity.LastModificationTime = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
