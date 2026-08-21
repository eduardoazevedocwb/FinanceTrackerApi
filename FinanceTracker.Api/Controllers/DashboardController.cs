using FinanceTracker.Application.DTOs;
using FinanceTracker.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("projection")]
        public async Task<ActionResult<List<MonthlySummaryDto>>> GetProjection([FromQuery] int monthAhead,CancellationToken cancellationToken)
        {
            var months = monthAhead <= 0 ? 6 : Math.Min(monthAhead, 24);
            return Ok(await _dashboardService.GetProjectionAsync(months,cancellationToken));
        }
    }
}
