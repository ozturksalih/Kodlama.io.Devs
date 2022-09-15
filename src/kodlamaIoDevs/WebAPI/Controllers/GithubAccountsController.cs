using Application.Features.GithubAccounts.Commands.CreateGithubAccount;
using Application.Features.GithubAccounts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubAccountsController : BaseController
    {

        [HttpPost("create")]
        public async Task<IActionResult> CreateGithubAccount([FromBody] CreateGithubAccountCommand command)
        {
            CreatedGithubAccountDto createdGithubAccountDto = await Mediator.Send(command);
            return Ok(createdGithubAccountDto);

        }
    }
}
