using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Application.Services.Repositories;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        private IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguagesController(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreatedProgrammingLanguageDto createdProgrammingLanguageDto = await Mediator.Send(createProgrammingLanguageCommand);
            return Created("",createdProgrammingLanguageDto);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
        {
            ProgrammingLanguageGetByIdDto getByIdProgrammingLanguageDto = await Mediator.Send(getByIdProgrammingLanguageQuery);
            
            return Ok(getByIdProgrammingLanguageDto);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProgrammingLanguage([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdatedProgrammingLanguageDto updatedProgrammingLanguageDto = await Mediator.Send(updateProgrammingLanguageCommand);
            
            return Ok(updatedProgrammingLanguageDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProgrammingLanguage([FromRoute] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeletedProgrammingLanguageDto deletedProgrammingLanguageDto = await Mediator.Send(deleteProgrammingLanguageCommand);

            return Ok(deletedProgrammingLanguageDto);

        }
    }
}
