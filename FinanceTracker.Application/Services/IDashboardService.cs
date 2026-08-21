using FinanceTracker.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Services
{
    public interface IDashboardService
    {
        Task<List<MonthlySummaryDto>> GetProjectionAsync(int monthsAhead, CancellationToken cancellationToken = default);
    }
}
