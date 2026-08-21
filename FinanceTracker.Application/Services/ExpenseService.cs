using FinanceTracker.Application.Application;
using FinanceTracker.Application.DTOs;
using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;
        private readonly IInstallmentGenerator _installmentGenerator;
        private readonly IInstallmentRepository _installmentRepository;

        public ExpenseService(
            IExpenseRepository repository,
            IInstallmentGenerator installmentGenerator,
            IInstallmentRepository installmentRepository)
        {
            _repository = repository;
            _installmentGenerator = installmentGenerator;
            _installmentRepository = installmentRepository;
        }

        public async Task<ExpenseDto> CreateAsync(
            CreateExpenseRequest request,
            CancellationToken cancellationToken = default)
        {
            var expense = new Expense(
                request.Description,
                request.Amount,
                request.Date,
                request.Type,
                request.PaymentMethod,
                request.CategoryId,
                request.CreditCardId,
                request.IsRecurring,
                request.NumberOfInstallments);

            await _repository.AddAsync(expense, cancellationToken);

            var installments = _installmentGenerator.Generate(expense);

            if (installments.Count > 0)
            {
                await _installmentRepository.AddRangeAsync(installments, cancellationToken);
            }

            await _repository.SaveChangesAsync(cancellationToken);

            return new ExpenseDto(
                expense.Id,
                expense.Description,
                expense.Amount,
                expense.Date,
                string.Empty,
                null);
        }
    }
}
