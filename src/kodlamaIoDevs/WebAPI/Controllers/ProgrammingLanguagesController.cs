using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Services.Repositories;
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
        public async Task<IActionResult> GetAll()
        {
            var programmingLanguages = await _programmingLanguageRepository.GetListAsync();
            return Ok(programmingLanguages);
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
            GetByIdProgrammingLanguageDto getByIdProgrammingLanguageDto = await Mediator.Send(getByIdProgrammingLanguageQuery);
            
            return Ok(getByIdProgrammingLanguageDto);
        }
        
    }
}
