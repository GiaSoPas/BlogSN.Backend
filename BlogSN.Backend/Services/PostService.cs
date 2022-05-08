using BlogSN.Backend.Data;
using BlogSN.Backend.Exceptions;
using BlogSN.Models;
using Microsoft.EntityFrameworkCore;
using Models.ModelsBlogSN;

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

        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException e)
        {
            if (await _context.IsPostExists(post.Id))
                throw new BadRequestException($"There is already exists task with {{id}} = {post.Id}");
            else
                throw;
        }
    }

    public async Task DeletePostById(int id, CancellationToken cancellationToken)
    {
        var post = await GetPostById(id, cancellationToken);

        _context.Post.Remove(post);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Post> GetPostById(int id, CancellationToken cancellationToken)
    {

        var post = await _context.Post.Include(p => p.ApplicationUser).Include(p=> p.Category).FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

        if (post is null)
        {
            throw new NotFoundException($"No post with id = {id}");

        }
        return post;

    }
    public async Task<IEnumerable<Post>> GetPosts(CancellationToken cancellationToken)
    {
        var post = await _context.Post.Include(p=> p.Category).ToListAsync(cancellationToken);

        if (!post.Any())
        {
            throw new NotFoundException($"No task fround");
        }
        return post;
    }

    public async Task UpdatePostById(int id, Post post, CancellationToken cancellationToken)
    {
        if (id != post.Id)
        {
            throw new BadRequestException("id from the route is not equal to id from passed object");
        }
        
        if (!await _context.IsPostExists(id))
            throw new NotFoundException($"There is no post with {{id}} = {id}.");
        
        _context.Entry(post).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
    }

}