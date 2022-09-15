namespace Application.Features.Members.Dtos
{
    public class LoggedMemberDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}