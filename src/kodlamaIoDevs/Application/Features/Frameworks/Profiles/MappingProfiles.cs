using Application.Features.Frameworks.Commands.CreateFramework;
using Application.Features.Frameworks.Dtos;
using Application.Features.Frameworks.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Frameworks.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Framework, FrameworkListDto>().ForMember(f=> 
            f.ProgrammingLanguageName, opt => opt.MapFrom(c=>c.ProgrammingLanguage.Name))
                .ReverseMap();

            CreateMap<IPaginate<Framework>, FrameworkListModel>().ReverseMap();


            CreateMap<Framework, CreateFrameworkCommand>().ReverseMap();
            CreateMap<Framework, CreatedFrameworkDto>().ReverseMap();

        }
    }
}
