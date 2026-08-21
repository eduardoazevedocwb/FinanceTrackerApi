using FinanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Interfaces
{
    public interface IExpenseRepository
    {
        Task<Expense?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync (Expense expense, CancellationToken cancellationToken = default);
        Task SaveChangesAsync (CancellationToken cancellationToken = default);
    }
}
