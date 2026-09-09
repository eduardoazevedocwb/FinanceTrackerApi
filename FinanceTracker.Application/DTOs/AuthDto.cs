using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.DTOs
{
    public record AuthResponse(string Token, DateTime ExpiresAt, UserResponse User);
    public record UserResponse(Guid Id, string Name, string Username, string Email);
}
