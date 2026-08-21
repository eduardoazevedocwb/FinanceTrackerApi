using FinanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Interfaces
{
    public interface IInstallmentRepository
    {
        Task<Installment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Installment>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(Installment installment, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        Task AddRangeAsync(List<Installment> installments, CancellationToken cancellationToken = default);
    }
}
