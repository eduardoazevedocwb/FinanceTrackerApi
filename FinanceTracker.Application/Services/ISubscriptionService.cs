using FinanceTracker.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Services
{
    public interface ISubscriptionService
    {
        Task<List<SubscriptionDto>> GetActiveAsync(CancellationToken cancellationToken = default);
        Task<SubscriptionDto> CreateAsync(CreateSubscriptionRequest request, CancellationToken cancellationToken = default);
        Task<bool> CancelAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
