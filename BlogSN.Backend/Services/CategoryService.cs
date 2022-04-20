using BlogSN.Backend.Data;
using BlogSN.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogSN.Backend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogSnDbContext _context;

        public CategoryService(BlogSnDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetCategotyPosts(int categoryId, CancellationToken cancellationToken)
        {
            return await _context.Post.Where(p => p.CategoryId == categoryId).ToListAsync(cancellationToken);
        }
    }
}
