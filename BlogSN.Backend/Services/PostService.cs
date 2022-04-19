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

    public async Task CreatePost(Post post, CancellationToken cancellationToken)
    {
        await _context.Post.AddAsync(post, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeletePostById(int id, CancellationToken cancellationToken)
    {
        var post = await GetPostById(id, cancellationToken);

        _context.Post.Remove(post);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Post> GetPostById(int id, CancellationToken cancellationToken)
    {
        return await _context.Post.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Post>> GetPosts(CancellationToken cancellationToken)
    {
        return await _context.Post.ToListAsync(cancellationToken);
    }

    public async Task UpdatePostById(int id, Post post, CancellationToken cancellationToken)
    {
        _context.Entry(post).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
    }

    private bool PostExists(int id)
    {
        return _context.Post.Any(e => e.Id == id);
    }

}