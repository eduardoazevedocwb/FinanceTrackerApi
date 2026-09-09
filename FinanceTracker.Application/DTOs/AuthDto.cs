using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.DTOs
{
    public record RegisterRequest(string Email, string Password, string Name, string Username);
    public record LoginRequest(string Email, string Password);
    public record AuthResponse(string Token, DateTime ExpiresAt, string Email);
    public record UserResponse(Guid Id, string Name, string Username, string Email);
}
