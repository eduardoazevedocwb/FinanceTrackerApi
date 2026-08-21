using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Domain.Enums
{
    public enum ExpenseType
    {
        Fixed = 1,
        Variable = 2,
        Subscription = 3,
        Installment = 4,
        Extra = 5
    }
}
