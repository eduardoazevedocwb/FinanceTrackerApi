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
    public class InstallmentRepository : IInstallmentRepository
    {
        private readonly FinanceDbContext _context;

        public InstallmentRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<Installment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Installments.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<Installment>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Installments
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Installment installment, CancellationToken cancellationToken = default)
        {
            await _context.Installments.AddAsync(installment, cancellationToken);
        }

        public async Task AddRangeAsync(List<Installment> installments, CancellationToken cancellationToken = default)
        {
            await _context.Installments.AddRangeAsync(installments, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
