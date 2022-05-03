using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Services
{
    public interface IUsersServive
    {
        public Task<ApplicationUser> GetUserById(string id, CancellationToken cancellationToken);
    }
}
