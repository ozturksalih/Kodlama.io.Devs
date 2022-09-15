using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities
{
    public class GithubAccount : Entity
    {
        public int DeveloperId { get; set; }
        public string GithubLink { get; set; }

        public GithubAccount()
        {

        }

        public GithubAccount(int id, int developerId, string githubLink) : base(id)
        {
            Id = id;
            DeveloperId = developerId;
            GithubLink = githubLink;
        }

        public virtual Developer Developer { get; set; }
    }
}
