using FinanceTracker.Application.DTOs;
using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _repository;

        public SubscriptionService(ISubscriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SubscriptionDto>> GetActiveAsync(CancellationToken cancellationToken = default)
        {
            var subscriptions = await _repository.GetActiveAsync(cancellationToken);

            return subscriptions
                .Select(x => new SubscriptionDto(x.Id, x.Name, x.Amount, x.DueDay, x.Category.Name, x.IsActive))
                .ToList();
        }

        public async Task<SubscriptionDto> CreateAsync(CreateSubscriptionRequest request, CancellationToken cancellationToken = default)
        {
            var subscription = new Subscription(request.Name, request.Amount, request.DueDay, request.CategoryId);

            await _repository.AddAsync(subscription, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return new SubscriptionDto(subscription.Id, subscription.Name, subscription.Amount, subscription.DueDay, string.Empty, subscription.IsActive);
        }

        public async Task<bool> CancelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var subscription = await _repository.GetByIdAsync(id, cancellationToken);

            if (subscription is null)
            {
                return false;
            }

            subscription.Cancel();
            await _repository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
