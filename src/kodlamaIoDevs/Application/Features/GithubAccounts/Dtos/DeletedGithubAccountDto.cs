namespace Application.Features.GithubAccounts.Dtos
{
    public class DeletedGithubAccountDto
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string GithubLink { get; set; }
    }
}