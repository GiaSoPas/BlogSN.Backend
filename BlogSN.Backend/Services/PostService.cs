using BlogSN.Backend.Data;
using BlogSN.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogSN.Backend.Services;

public class PostService : IPostService
{
    private readonly BlogSnDbContext _context;

    public PostService(BlogSnDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Post>> GetPosts()
    {
        var tasks = await _context.Post.ToListAsync();

        return tasks;
    }

    public async Task CreatePost(Post post)
    {
        await _context.AddAsync(post);
        await _context.SaveChangesAsync();
    }
}