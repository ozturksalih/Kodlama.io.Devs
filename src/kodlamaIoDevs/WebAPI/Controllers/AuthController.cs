using Application.Features.Members.Commands.LoginMember;
using Application.Features.Members.Commands.RegisterMember;
using Application.Features.Members.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterMemberCommand command)
        {
            RegisteredMemberDto registeredMemberDto = await Mediator.Send(command);

            return Ok(registeredMemberDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginMemberCommand command)
        {
            LoggedMemberDto loggedMemberDto = await Mediator.Send(command);

            return Ok(loggedMemberDto);
        }
    }
}
