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
<<<<<<< HEAD
        var post = await _context.Post.Include(p => p.Comments).Include(a => a.Rating).FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        foreach (Rating rating in post.Rating)
        {
            if (rating.LikeStatus)
            {
                post.RatingCount++;
            }
            else post.RatingCount--;
=======
        var post = await _context.Post.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

        if (post is null)
        {
            throw new NotFoundException($"No post with id = {id}");
>>>>>>> master
        }
        return post;
    }

    public async Task<IEnumerable<Post>> GetPosts(CancellationToken cancellationToken)
    {
<<<<<<< HEAD
        var posts = await _context.Post.Include(p => p.Rating).ToListAsync(cancellationToken);
        foreach (Post post in posts)
        {
            foreach (Rating rating in post.Rating)
            {
                if (rating.LikeStatus)
                {
                    post.RatingCount++;
                }
                else post.RatingCount--;
            }
        }
        return await _context.Post.ToListAsync(cancellationToken);
=======
        var post = await _context.Post.ToListAsync(cancellationToken);
        if (!post.Any())
        {
            throw new NotFoundException($"No task fround");
        }
        return post;
>>>>>>> master
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