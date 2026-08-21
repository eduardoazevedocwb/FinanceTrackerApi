using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.DTOs
{
    public record CreditCardDto(
        Guid Id,
        string Name,
        decimal Limit,
        decimal Balance
    ); 

    public record CreateCreditCardRequest(
        string Name,
        decimal Limit,
        int ClosingDay,
        int DueDay
    );

    public record UpdateCreditCardRequest(
        string Name,
        decimal Limit,
        int ClosingDay,
        int DueDay
    );
}
