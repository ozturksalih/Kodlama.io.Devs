using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand command)
        {
            CreatedUserOperationClaimDto result = await Mediator.Send(command);

            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserOperationClaimCommand command)
        {
            DeletedUserOperationClaimDto result = await Mediator.Send(command);

            return Ok(result);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetUserOperationClaimsByUserId([FromBody] )
        //{

        //}
    }
}
