using Application.Features.Frameworks.Commands.CreateFramework;
using Application.Features.Frameworks.Dtos;
using Application.Features.Frameworks.Models;
using Application.Features.Frameworks.Queries.GetListFramework;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrameworksController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListFrameworkQuery getListFrameworkQuery = new() { PageRequest = pageRequest };
            FrameworkListModel result = await Mediator.Send(getListFrameworkQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateFrameworkCommand command)
        {
            CreatedFrameworkDto result = await Mediator.Send(command);
            return Created(" ", result);
        }

    }
}
