using FinanceTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.DTOs
{
    public record CreateExpenseRequest(
        string Description,
        decimal Amount,
        DateTime Date,
        ExpenseType Type,
        PaymentMethod PaymentMethod,
        Guid CategoryId,
        Guid? CreditCardId,
        bool IsRecurring,
        int? NumberOfInstallments
    );
}
