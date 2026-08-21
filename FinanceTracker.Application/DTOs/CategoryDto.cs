using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.DTOs
{
    public record CategoryDto(
        Guid Id,
        string Name,
        bool IsActive
    );

    public record CreateCategoryRequest(
        string Name
    );

    public record UpdateCategoryRequest(
        string Name
    );
}
