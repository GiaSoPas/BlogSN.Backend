using BlogSN.Models;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Services
{
    public interface IUserServive
    {
        public Task<ApplicationUser> GetUserById(string id, CancellationToken cancellationToken);

        public Task<IEnumerable<Post>> GetPostsByUserId(string id, CancellationToken cancellationToken);

    }
}
