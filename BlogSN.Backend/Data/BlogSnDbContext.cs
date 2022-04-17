using BlogSN.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogSN.Backend.Data;

public class BlogSnDbContext: DbContext
{
    public BlogSnDbContext(DbContextOptions<BlogSnDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Post> Posts { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Role> Roles { get; set; }
}