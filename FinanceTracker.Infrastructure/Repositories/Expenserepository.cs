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
    public class Expenserepository : IExpenseRepository
    {
        private readonly FinanceDbContext _context;

        public Expenserepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Expense expense, CancellationToken cancellationToken = default)
        {
            await _context.Expenses.AddAsync(
                    expense,
                    cancellationToken);
        }

        public async Task<Expense?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Expenses
                .Include(x => x.Category)
                .Include(x => x.CreditCard)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
