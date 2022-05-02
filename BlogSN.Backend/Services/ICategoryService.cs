using BlogSN.Models;

namespace BlogSN.Backend.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Post>> GetCategoryPosts(int categoryId, CancellationToken cancellationToken);
        public Task<IEnumerable<Category>> GetAllCategories(CancellationToken cancellationToken);
        
        public Task<Category> GetCategoryById(int id, CancellationToken cancellationToken);

    }
}
