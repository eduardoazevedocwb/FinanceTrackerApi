using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Domain.Entities
{
    public class CreditCard
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public decimal Limit { get; private set; }
        public int ClosingDay { get; set; }
        public int DueDay { get; set; }

        public CreditCard()
        {}

        public CreditCard(string name, decimal limit, int closingDay, int dueDay)
        {
            Id = Guid.NewGuid();
            Name = name;
            Limit = limit;
            ClosingDay = closingDay;
            DueDay = dueDay;
        }

        public void Update(string name, decimal limit, int closingDay, int dueDay)
        {
            Name = name;
            Limit = limit;
            ClosingDay = closingDay;
            DueDay = dueDay;
        }
    }
}
