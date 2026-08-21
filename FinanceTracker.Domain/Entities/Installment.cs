using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Domain.Entities
{
    public class Installment
    {
        public Guid Id { get; private set; }

        public Guid ExpenseId { get; private set; }

        public Expense Expense { get; private set; } = null!;

        public int Number { get; private set; }

        public decimal Amount { get; private set; }

        public DateTime DueDate { get; private set; }

        public bool Paid { get; private set; }

        private Installment()
        {}

        public Installment(Guid expenseId, int number, decimal amount, DateTime dueDate)
        {
            Id = Guid.NewGuid();
            ExpenseId = expenseId;
            Number = number;
            Amount = amount;
            DueDate = dueDate;
            Paid = false;
        }

        public void MarkAsPaid()
        {
            Paid = true;
        }
    }
}
