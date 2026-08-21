using FinanceTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Domain.Entities
{
    public class Expense
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public ExpenseType Type { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        public Guid? CreditCardId { get; private set; }
        public CreditCard? CreditCard { get; private set; }
        public bool IsRecurring { get; private set; }
        public int? NumberOfInstallments { get; private set; }

        public Expense()
        {}

        public Expense(string description, decimal amount, DateTime date, ExpenseType type, PaymentMethod paymentMethod, Guid categoryId, Guid? creditCardId = null, bool isRecurring = false, int? numberOfInstallments = null)
        {
            Id = Guid.NewGuid();
            Description = description;
            Amount = amount;
            Date = date;
            Type = type;
            PaymentMethod = paymentMethod;
            CategoryId = categoryId;
            CreditCardId = creditCardId;
            IsRecurring = isRecurring;
            NumberOfInstallments = numberOfInstallments;
        }
    }
}
