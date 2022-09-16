using Application.Features.GithubAccounts.Commands.CreateGithubAccount;
using Application.Features.GithubAccounts.Commands.DeleteGithubAccount;
using Application.Features.GithubAccounts.Commands.UpdateGithubAccount;
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

            CreateMap<GithubAccount, DeleteGithubAccountCommand>().ReverseMap();
            CreateMap<GithubAccount, DeletedGithubAccountDto>().ReverseMap();

            CreateMap<GithubAccount, UpdateGithubAccountCommand>().ReverseMap();
            CreateMap<GithubAccount, UpdatedGithubAccountDto>().ReverseMap();
        }
    }
}
