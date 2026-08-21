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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoryDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _repository.GetAllAsync(cancellationToken);

            return categories
                .Select(x => new CategoryDto(x.Id, x.Name, x.IsActive))
                .ToList();
        }

        public async Task<CategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var category = await _repository.GetByIdAsync(id, cancellationToken);

            return category is null
                ? null
                : new CategoryDto(category.Id, category.Name, category.IsActive);
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryRequest request, CancellationToken cancellationToken = default)
        {
            var category = new Category(request.Name);

            await _repository.AddAsync(category, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return new CategoryDto(category.Id, category.Name, category.IsActive);
        }

        public async Task<CategoryDto?> UpdateAsync(Guid id, UpdateCategoryRequest request, CancellationToken cancellationToken = default)
        {
            var category = await _repository.GetByIdAsync(id, cancellationToken);

            if (category is null)
            {
                return null;
            }

            category.UpdateName(request.Name);
            await _repository.SaveChangesAsync(cancellationToken);

            return new CategoryDto(category.Id, category.Name, category.IsActive);
        }

        public async Task<bool> DeactivateAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var category = await _repository.GetByIdAsync(id, cancellationToken);

            if (category is null)
            {
                return false;
            }

            category.Deactivate();
            await _repository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
