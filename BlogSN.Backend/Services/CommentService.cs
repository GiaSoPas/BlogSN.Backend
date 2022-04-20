using BlogSN.Backend.Data;
using Models.ModelsBlogSN;

namespace BlogSN.Backend.Services
{
    public class CommentService : ICommentService
    {
        private readonly BlogSnDbContext _context;

        public CommentService(BlogSnDbContext context)
        {
            _context = context;
        }

        public async Task CreateComment(Comment comment, CancellationToken cancellationToken)
        {
            await _context.Comment.AddAsync(comment, cancellationToken);
            await _context.SaveChangesAsync();
        }
    }
}
