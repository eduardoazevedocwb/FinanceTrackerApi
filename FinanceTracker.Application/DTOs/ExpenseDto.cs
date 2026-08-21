using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.DTOs
{
    public record ExpenseDto (
        Guid Id, 
        string Description, 
        decimal Amount, 
        DateTime Date, 
        string Category, 
        string? CreditCard
    );
}
