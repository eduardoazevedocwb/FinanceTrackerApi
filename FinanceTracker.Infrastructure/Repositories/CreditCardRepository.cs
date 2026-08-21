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
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly FinanceDbContext _context;
        public CreditCardRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<CreditCard?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.CreditCards.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<List<CreditCard>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.CreditCards.ToListAsync(cancellationToken);
        }

        public async Task AddAsync(CreditCard creditCard, CancellationToken cancellationToken = default)
        {
            await _context.CreditCards.AddAsync(creditCard, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
