using BlogSN.Models;
using Microsoft.EntityFrameworkCore;
using Models.ModelsBlogSN;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Data;

public class BlogSnDbContext: DbContext
{
    public BlogSnDbContext(DbContextOptions<BlogSnDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Comment> Comment { get; set; }

    public DbSet<Rating> Rating { get; set; }

    public DbSet<ApplicationUser> AspNetUsers { get; set; }

    public DbSet<Post> Post { get; set; }
    
    public DbSet<Category> Category { get; set; }
    
    public async Task<bool> IsPostExists(int id) =>
        await Post.AnyAsync(post => post.Id == id);
    
}