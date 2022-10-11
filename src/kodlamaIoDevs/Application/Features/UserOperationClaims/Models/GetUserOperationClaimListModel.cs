using Application.Features.UserOperationClaims.Dtos;

namespace Application.Features.UserOperationClaims.Models
{
    public class GetUserOperationClaimListModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public ICollection<GetByUserIdUserOperationClaimDto> Items { get; set; }
    }
}
