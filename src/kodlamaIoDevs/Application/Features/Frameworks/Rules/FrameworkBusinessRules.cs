using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Frameworks.Rules
{
    public class FrameworkBusinessRules
    {
        private readonly IFrameworkRepository _frameworkRepository;

        public FrameworkBusinessRules(IFrameworkRepository frameworkRepository)
        {
            _frameworkRepository = frameworkRepository;
        }

        public void FrameworkShouldExistWhenRequested(Framework framework)
        {
            if (framework == null) throw new BusinessException("Requested framework doesn't exist");
        }
    }
}
