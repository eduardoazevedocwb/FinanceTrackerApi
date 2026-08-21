using FinanceTracker.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<CategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<CategoryDto> CreateAsync(CreateCategoryRequest request, CancellationToken cancellationToken = default);
        Task<CategoryDto?> UpdateAsync(Guid id, UpdateCategoryRequest request, CancellationToken cancellationToken = default);
        Task<bool> DeactivateAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
