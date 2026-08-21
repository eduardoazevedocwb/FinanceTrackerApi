using FinanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Services
{
    public interface IInstallmentGenerator
    {
        List<Installment> Generate(Expense expense);
    }
}
