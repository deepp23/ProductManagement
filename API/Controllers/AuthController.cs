using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.Auth.Commands;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailed)
                return Unauthorized(result.Errors);

            return Ok(new { token = result.Value });
        }
    }
}