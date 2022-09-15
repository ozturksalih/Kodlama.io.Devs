using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class GithubAccount : Entity
    {
        public int MemberId { get; set; }
        public string GithubLink { get; set; }

        public GithubAccount()
        {

        }

        public GithubAccount(int id, int memberId, string githubLink) : base(id)
        {
            Id = id;
            MemberId = memberId;
            GithubLink = githubLink;
        }

        public virtual Member Member { get; set; }
    }
}
