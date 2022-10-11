using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();

            CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();

            CreateMap<UserOperationClaim, GetByUserIdUserOperationClaimDto>()
                .ForMember(c => c.OperationClaimName, opt => opt.MapFrom(c => c.OperationClaim.Name))
                .ReverseMap();

            CreateMap<IPaginate<UserOperationClaim>, GetUserOperationClaimListModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(source => source.Items.Select(uoc => uoc.UserId).First()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(source => source.Items.Select(uoc => uoc.User.Email).First()));


        }
    }
}
