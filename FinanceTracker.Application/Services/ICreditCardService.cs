using FinanceTracker.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Services
{
    public interface ICreditCardService
    {
        Task<List<CreditCardDto?>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<CreditCardDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<CreditCardDto> CreateAsync(CreateCreditCardRequest request, CancellationToken cancellationToken = default);
        Task<CreditCardDto?> UpdateAsync(Guid id, UpdateCreditCardRequest request, CancellationToken cancellationToken = default);
    }
}
