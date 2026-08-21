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
    public class CreditCardService : ICreditCardService
    {
        private readonly ICreditCardRepository _repository;
        public CreditCardService(ICreditCardRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CreditCardDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var creditCards = await _repository.GetAllAsync(cancellationToken);
            return creditCards.Select(cc => new CreditCardDto(cc.Id, cc.Name, cc.Limit, cc.ClosingDay)).ToList();
        }

        public async Task<CreditCardDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var creditCard = await _repository.GetByIdAsync(id, cancellationToken);
            if (creditCard == null)
            {
                return null;
            }
            return new CreditCardDto(creditCard.Id, creditCard.Name, creditCard.Limit, creditCard.ClosingDay);
        }

        public async Task<CreditCardDto> CreateAsync(CreateCreditCardRequest request, CancellationToken cancellationToken = default)
        {
            var creditCard = new CreditCard(request.Name, request.Limit, request.ClosingDay, request.DueDay);
            await _repository.AddAsync(creditCard, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return new CreditCardDto(creditCard.Id, creditCard.Name, creditCard.Limit, creditCard.ClosingDay);
        }

        public async Task<CreditCardDto?> UpdateAsync(Guid id, UpdateCreditCardRequest request, CancellationToken cancellationToken = default)
        {
            var creditCard = await _repository.GetByIdAsync(id, cancellationToken);
            if (creditCard == null)
            {
                return null;
            }
            creditCard.Update(request.Name, request.Limit, request.ClosingDay, request.DueDay);
            await _repository.SaveChangesAsync(cancellationToken);
            return new CreditCardDto(creditCard.Id, creditCard.Name, creditCard.Limit, creditCard.ClosingDay);
        }
    }
}
