using FinanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Installment>> GetInstallmentBetweenAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

        Task<List<Expense>> GetNonInstallmentExpensesBetweenAsync(DateTime start, DateTime end, CancellationToken cancellationToken = default);

        Task<List<Subscription>> GetActiveSubscriptionsAsync(CancellationToken cancellationToken = default);
    }
}
