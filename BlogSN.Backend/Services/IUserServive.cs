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

        public Task UpdateUsernameById(string userId, string newName, CancellationToken cancellationToken);

        public Task UpdateUserEmailById(string userId, string newEmail, CancellationToken cancellationToken);

        public Task UpdateUserRoleToAdminById(string userId, CancellationToken cancellationToken);

        public Task UpdateUserRoleToUserById(string userId, CancellationToken cancellationToken);

        public Task<IEnumerable<Rating>> GetRatingsByUserId(string userId, CancellationToken cancellationToken);
    }
}
