using Application.Features.Frameworks.Dtos;
using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand command)
        {
            CreatedOperationClaimDto result = await Mediator.Send(command);
            return Created(" ", result);
        }
    }
}
