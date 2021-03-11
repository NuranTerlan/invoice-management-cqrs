using System.Security.Claims;
using InvoiceManagementApplication.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace InvoiceManagementApplication.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string UserId { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}