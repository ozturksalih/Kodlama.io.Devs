using Application.Features.GithubAccounts.Commands.CreateGithubAccount;
using Application.Features.GithubAccounts.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.GithubAccounts.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GithubAccount, CreateGithubAccountCommand>().ReverseMap();
            CreateMap<GithubAccount, CreatedGithubAccountDto>().ReverseMap();
        }
    }
}
