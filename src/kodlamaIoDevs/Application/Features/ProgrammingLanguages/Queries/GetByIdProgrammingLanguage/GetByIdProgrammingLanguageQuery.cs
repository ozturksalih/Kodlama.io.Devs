using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQuery : IRequest<GetByIdProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public class GetByIdProgrammingLanguageHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, GetByIdProgrammingLanguageDto>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public GetByIdProgrammingLanguageHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository,
                ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _mapper = mapper;
                _programmingLanguageRepository = programmingLanguageRepository;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<GetByIdProgrammingLanguageDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(pl => pl.Id == request.Id);

                _programmingLanguageBusinessRules.ProgrammingLangugageShouldExistWhenRequested(programmingLanguage);
                
                GetByIdProgrammingLanguageDto getByIdProgrammingLanguageDto = _mapper.Map<GetByIdProgrammingLanguageDto>(programmingLanguage);

                return getByIdProgrammingLanguageDto;
            }
        }
    }
}
