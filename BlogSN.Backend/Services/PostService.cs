using BlogSN.Backend.Data;
using BlogSN.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogSN.Backend.Services;

public class PostService : IPostService
{
    private readonly BlogSnDbContext _context;

    public PostService(BlogSnDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Post>> GetPosts(CancellationToken cancellationToken)
    {
        var tasks = await _context.Posts.ToListAsync(cancellationToken);

        return tasks;
    }

    public async Task CreatePost(Post post, CancellationToken cancellationToken)
    {
        await _context.Posts.AddAsync(post, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Post> GetPostById(int id, CancellationToken cancellationToken)
    {
        //var post = await _context.Posts.FindAsync(id, cancellationToken);
        
        var post = await _context.Posts.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        
        return post;

    }

    public async Task DeletePostById(int id, CancellationToken cancellationToken)
    {
        var post = await GetPostById(id, cancellationToken);

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task UpdatePostById(int id, Post post, CancellationToken cancellationToken)
    {
        _context.Entry(post).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
    }
}