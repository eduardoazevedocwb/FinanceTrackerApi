using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Domain.Entities
{
    public class Subscription
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public decimal Amount { get; private set; }

        public int DueDay { get; private set; }

        public Guid CategoryId { get; private set; }

        public Category Category { get; private set; } = null!;

        public bool IsActive { get; private set; }

        private Subscription()
        {}

        public Subscription(string name, decimal amount, int dueDay, Guid categoryId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Amount = amount;
            DueDay = dueDay;
            CategoryId = categoryId;
            IsActive = true;
        }

        public void Cancel()
        {
            IsActive = false;
        }
    }
}
