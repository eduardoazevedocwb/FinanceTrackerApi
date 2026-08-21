using FinanceTracker.Application.DTOs;
using FinanceTracker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _repository;

        public DashboardService(IDashboardRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MonthlySummaryDto>> GetProjectionAsync(int monthsAhead, CancellationToken cancellationToken = default)
        {
            var today = DateTime.UtcNow.Date;
            var rangeStart = new DateTime(today.Year, today.Month, 1);
            var rangeEnd = rangeStart.AddMonths(monthsAhead);

            var installments = await _repository.GetInstallmentBetweenAsync(rangeStart, rangeEnd, cancellationToken);
            var expenses = await _repository.GetNonInstallmentExpensesBetweenAsync(rangeStart, rangeEnd, cancellationToken);
            var subscriptions = await _repository.GetActiveSubscriptionsAsync(cancellationToken);

            var result = new List<MonthlySummaryDto>();

            for (int i = 0; i < monthsAhead; i++)
            {
                var monthStart = rangeStart.AddMonths(i);
                var monthEnd = monthStart.AddMonths(1);

                var installmentTotal = installments
                    .Where(x => x.DueDate >= monthStart && x.DueDate < monthEnd)
                    .Sum(x => x.Amount);

                var monthExpenses = expenses
                    .Where(x => x.Date >= monthStart && x.Date < monthEnd)
                    .ToList();

                var fixedTotal = monthExpenses
                    .Where(x => x.Type == Domain.Enums.ExpenseType.Fixed)
                    .Sum(x => x.Amount);

                var extraTotal = monthExpenses
                    .Where(x => x.Type == Domain.Enums.ExpenseType.Extra || x.Type == Domain.Enums.ExpenseType.Variable)
                    .Sum(x => x.Amount);

                var subscriptionTotal = subscriptions
                    .Sum(x => x.Amount);

                result.Add(new MonthlySummaryDto
                (
                    monthStart.Year,
                    monthStart.Month,
                    fixedTotal,
                    installmentTotal,
                    subscriptionTotal,
                    extraTotal,
                    fixedTotal + installmentTotal + subscriptionTotal + extraTotal
                ));
            }

            return result;
        }
    }
}
