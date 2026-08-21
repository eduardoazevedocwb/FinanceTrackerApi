using FinanceTracker.Application.DTOs;
using FinanceTracker.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService _service;

        public SubscriptionsController(ISubscriptionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubscriptionDto>>> GetActive(CancellationToken cancellationToken)
        {
            return Ok(await _service.GetActiveAsync(cancellationToken));
        }

        [HttpPost]
        public async Task<ActionResult<SubscriptionDto>> Create(CreateSubscriptionRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetActive), new { id = result.Id }, result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Cancel(Guid id, CancellationToken cancellationToken)
        {
            var success = await _service.CancelAsync(id, cancellationToken);
            return success ? NoContent() : NotFound();
        }
    }
}
