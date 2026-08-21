using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.DTOs
{
    public record MonthlySummaryDto(int Year, int Month, decimal FixedTotal, decimal InstallmentTotal, decimal SubscriptionTotal, decimal ExtraTotal, decimal Total);

    public record DashboardProjectionRequest(int MonthsAhead);
}
