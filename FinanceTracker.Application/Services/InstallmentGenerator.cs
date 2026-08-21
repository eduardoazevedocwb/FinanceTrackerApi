using FinanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Services
{
    public class InstallmentGenerator : IInstallmentGenerator
    {
        public List<Installment> Generate (Expense expense)
        {
            if (expense.NumberOfInstallments is null || expense.NumberOfInstallments <= 0)
            {
                throw new InvalidOperationException("Number of installments must be greater than zero.");
            }

            var count = expense.NumberOfInstallments.Value;

            var baseAmount = Math.Round(expense.Amount / count, 2, MidpointRounding.ToEven);
            var installments = new List<Installment>(count);
            decimal runningTotal = 0m;
                        
            for (int i = 1; i <= count; i++)
            {
                var amount = i < count ? baseAmount : Math.Round(expense.Amount - runningTotal, 2, MidpointRounding.ToEven);
                
                runningTotal += amount;
                
                var dueDate = expense.Date.AddMonths(i - 1);
                
                installments.Add(new Installment(expense.Id, i, amount, dueDate));
            }

            return installments;
        }
    }
}
