using Application.Features.Frameworks.Dtos;
using Application.Features.Frameworks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Frameworks.Commands.DeleteFramework
{
    public class DeleteFrameworkCommand : IRequest<DeletedFrameworkDto>
    {
        public int Id { get; set; }
        public class DeleteFrameworkHandler : IRequestHandler<DeleteFrameworkCommand, DeletedFrameworkDto>
        {
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly IMapper _mapper;
            private readonly FrameworkBusinessRules _frameworkBusinessRules;

            public DeleteFrameworkHandler(IFrameworkRepository frameworkRepository, IMapper mapper, FrameworkBusinessRules frameworkBusinessRules)
            {
                _frameworkRepository = frameworkRepository;
                _mapper = mapper;
                _frameworkBusinessRules = frameworkBusinessRules;
            }

            public async Task<DeletedFrameworkDto> Handle(DeleteFrameworkCommand request, CancellationToken cancellationToken)
            {
                Framework frameworkToDelete = _mapper.Map<Framework>(request);
                Framework framework = await _frameworkRepository.DeleteAsync(frameworkToDelete);

                DeletedFrameworkDto deletedFrameworkDto = _mapper.Map<DeletedFrameworkDto>(framework);
                return deletedFrameworkDto;

            }
        }
    }
}
