using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Infrastructure.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly FinanceDbContext _context;

        public SubscriptionRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<Subscription?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Subscriptions
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<Subscription>> GetActiveAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Subscriptions
                .Include(x => x.Category)
                .Where(x => x.IsActive)
                .OrderBy(x => x.DueDay)
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Subscription subscription, CancellationToken cancellationToken = default)
        {
            await _context.Subscriptions.AddAsync(subscription, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
