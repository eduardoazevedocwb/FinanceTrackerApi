using FinanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Interfaces
{
    public interface ICreditCardRepository
    {
        Task<CreditCard?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<CreditCard>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(CreditCard creditCard, CancellationToken cancellationToken = default);
        Task SaveChangesAsync (CancellationToken cancellationToken = default);
    }
}
