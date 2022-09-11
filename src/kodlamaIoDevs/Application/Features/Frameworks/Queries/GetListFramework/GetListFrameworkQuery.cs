using Application.Features.Frameworks.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Frameworks.Queries.GetListFramework
{
    public class GetListFrameworkQuery : IRequest<FrameworkListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListFrameworkHandler : IRequestHandler<GetListFrameworkQuery, FrameworkListModel>
        {
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly IMapper _mapper;

            public GetListFrameworkHandler(IFrameworkRepository frameworkRepository, IMapper mapper)
            {
                _frameworkRepository = frameworkRepository;
                _mapper = mapper;
            }

            public async Task<FrameworkListModel> Handle(GetListFrameworkQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Framework> frameworks = await _frameworkRepository.GetListAsync(include: 
                                                                        f => f.Include(c =>c.ProgrammingLanguage),
                                                                        index: request.PageRequest.Page,
                                                                        size: request.PageRequest.PageSize);

                FrameworkListModel mappedFrameworks = _mapper.Map<FrameworkListModel>(frameworks);

                return mappedFrameworks;
            }
        }
    }
}
