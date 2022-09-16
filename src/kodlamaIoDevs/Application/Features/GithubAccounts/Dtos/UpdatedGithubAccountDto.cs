namespace Application.Features.GithubAccounts.Dtos
{
    public class UpdatedGithubAccountDto
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string GithubLink { get; set; }
    }
}