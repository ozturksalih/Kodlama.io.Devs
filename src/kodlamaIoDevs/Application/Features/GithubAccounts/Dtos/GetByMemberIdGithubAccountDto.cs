namespace Application.Features.GithubAccounts.Dtos
{
    public class GetByMemberIdGithubAccountDto
    {
        public int Id { get; set; }
        public string MemberEmail { get; set; }
        public string GithubLink { get; set; }
    }
}
