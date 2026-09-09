using FinanceTracker.Application.DTOs;
using FinanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Infrastructure.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(UserRegisterCommand request, CancellationToken cancellationToken = default);
        Task<AuthResponse?> LoginAsync(LoginCommand request, CancellationToken cancellationToken = default);
    }
}
