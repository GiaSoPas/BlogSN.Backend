using BlogSN.Models;
using Models.ModelsBlogSN;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Services
{
    public interface IUserServive
    {
        public Task<ApplicationUser> GetUserById(string id, CancellationToken cancellationToken);

        public Task<IEnumerable<Post>> GetPostsByUserId(string id, CancellationToken cancellationToken);

        public Task<IEnumerable<ApplicationUser>> GetUsers(CancellationToken cancellationToken);

        public Task<IEnumerable<Comment>> GetCommentsByUserId(string userId, CancellationToken cancellationToken);

        public Task DeleteUserById(string userId, CancellationToken cancellationToken);

        public Task UpdateUserById(string userId, ApplicationUser applicationUser, CancellationToken cancellationToken);
    }
}
