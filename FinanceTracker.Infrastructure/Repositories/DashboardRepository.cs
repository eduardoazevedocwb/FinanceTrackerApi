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
    public class DashboardRepository : IDashboardRepository
    {
        private readonly FinanceDbContext _context;

        public DashboardRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Installment>> GetInstallmentBetweenAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            return await _context.Installments
                .Where(x => x.DueDate >= startDate && x.DueDate < endDate)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Expense>> GetNonInstallmentExpensesBetweenAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            return await _context.Expenses
                .Where(x => x.Type != Domain.Enums.ExpenseType.Installment && x.Date >= startDate && x.Date < endDate)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Subscription>> GetActiveSubscriptionsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Subscriptions
                .Where(x => x.IsActive)
                .ToListAsync(cancellationToken);
        }
    }
}
