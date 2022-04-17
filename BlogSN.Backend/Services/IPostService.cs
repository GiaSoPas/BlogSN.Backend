using BlogSN.Backend.Models;

namespace BlogSN.Backend.Services;

public interface IPostService
{
    public Task<IEnumerable<Post>> GetPosts();

    public Task CreatePost(Post post);
}