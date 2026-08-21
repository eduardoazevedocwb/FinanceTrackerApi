using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Domain.Enums
{
    public enum PaymentMethod
    {
        Cash = 1,
        DebitCard = 2,
        CreditCard = 3,
        BankTransfer = 4,
        Pix = 5
    }
}
