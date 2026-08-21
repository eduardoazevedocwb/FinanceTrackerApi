using FinanceTracker.Application.Application;
using FinanceTracker.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense([FromBody] CreateExpenseRequest request, CancellationToken cancellationToken)
        {
            var result = await _expenseService.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(CreateExpense), new { id = result.Id }, result);
        }
    }
}
