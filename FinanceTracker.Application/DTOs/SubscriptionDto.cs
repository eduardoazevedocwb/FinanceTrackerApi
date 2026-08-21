using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.DTOs
{
    public record SubscriptionDto(Guid Id, string Name, decimal Amount, int DueDay, string Category, bool IsActive);
    public record CreateSubscriptionRequest(string Name, decimal Amount, int DueDay, Guid CategoryId);
}
