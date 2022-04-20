using BlogSN.Models;

namespace BlogSN.Backend.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Post>> GetCategotyPosts(int categoryId, CancellationToken cancellationToken);

    }
}
