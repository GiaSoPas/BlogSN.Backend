using BlogSN.Backend.Data;
using BlogSN.Backend.Exceptions;
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

        public async Task<IEnumerable<Post>> GetCategoryPosts(int categoryId, CancellationToken cancellationToken)
        {
            return await _context.Post.Where(p => p.CategoryId == categoryId).Include(p => p.Category).Include(p => p.ApplicationUser).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Category>> GetAllCategories(CancellationToken cancellationToken)
        {
            var categories = await _context.Category.ToListAsync(cancellationToken);
            
            if (!categories.Any())
            {
                throw new NotFoundException($"No task fround");
            }

            return categories;
        }

        public async Task<Category> GetCategoryById(int id, CancellationToken cancellationToken)
        {
            var category = await _context.Category.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

            if (category is null)
            {
                throw new NotFoundException($"No post with id = {id}");
            }
            return category;
        }
    }
}
