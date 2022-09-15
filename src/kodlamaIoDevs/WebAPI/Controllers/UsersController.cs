using Application.Features.Users.Commands.RegisterUser;
using Application.Features.Users.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            RegisteredUserDto registeredUserDto = await Mediator.Send(command);

            return Ok(registeredUserDto);
        }
    }
}
