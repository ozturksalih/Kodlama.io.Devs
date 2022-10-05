using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.OperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateOperationClaimCommand, OperationClaim>().ReverseMap();
            CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();

            CreateMap<OperationClaim, UpdatedClaimOperationClaimDto>().ReverseMap();

            CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();

            CreateMap<OperationClaim, GetByIdOperationClaimDto>().ReverseMap();

            CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
            CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
        }
    }
}
