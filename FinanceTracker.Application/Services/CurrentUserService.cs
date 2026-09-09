using FinanceTracker.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public Guid UserId { get; }
        public CurrentUserService(IHttpContextAccessor accessor)
        {
            var sub = accessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            UserId = sub != null ? Guid.Parse(sub) : Guid.Empty;
        }
    }
}
