using Application.Features.Frameworks.Rules;
using AutoMapper;
using Core.Persistence.Repositories;

namespace Application.Features.Core.Core.Command
{
    public class BaseCommandHandler<TRepository, BusinessRules>
    {
        protected TRepository _repository;
        protected IMapper _mapper;
        protected BusinessRules _businessRules;

        public BaseCommandHandler(TRepository repository, IMapper mapper, BusinessRules businessRules)
        {
            _repository = repository;
            _mapper = mapper;
            _businessRules = businessRules;
        }
    }
}
