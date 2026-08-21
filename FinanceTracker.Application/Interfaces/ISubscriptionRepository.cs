using FinanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<Subscription?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Subscription>> GetActiveAsync(CancellationToken cancellationToken = default);
        Task AddAsync(Subscription subscription, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
