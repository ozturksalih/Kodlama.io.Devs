using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System.Xml.Linq;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }
        public async Task ProgrammingLanguageCanNotBeDuplicated(string name)
        {
            IPaginate<ProgrammingLanguage> result =  await _programmingLanguageRepository.GetListAsync(pl => pl.Name == name);
            if (result.Items.Any()) throw new BusinessException("Entered programming language exist");
        }
        public void ProgrammingLangugageShouldExistWhenRequested(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested programming language doesn't exist");
        }
        public async Task ProgrammingLanguageShouldExistInDatabase(ProgrammingLanguage programmingLanguage)
        {
            var result = await _programmingLanguageRepository.GetAsync(pl=>pl.Id == programmingLanguage.Id);
            if (result == null) throw new BusinessException("Entered programming language doesn't exist");

        }
    }
}
