using FinanceTracker.Application.DTOs;
using FinanceTracker.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register(RegisterRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.RegisterAsync(request, cancellationToken);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.LoginAsync(request, cancellationToken);
            return result is null ? Unauthorized() : Ok(result);
        }
    }
}
