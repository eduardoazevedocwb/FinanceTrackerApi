using FinanceTracker.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Application
{
    public interface IExpenseService
    {
        Task<ExpenseDto> CreateAsync(CreateExpenseRequest request, CancellationToken cancellationToken = default);
    }
}
