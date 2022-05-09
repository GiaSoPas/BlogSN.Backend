using BlogSN.Backend.Data;
using BlogSN.Backend.Exceptions;
using Microsoft.EntityFrameworkCore;
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
            var post = await _context.Post.FirstOrDefaultAsync(p => p.Id == comment.PostId);
            if (post is null)
            {
                throw new NotFoundException($"No post with id");
            }
            post.CommentsCount++;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCommentById(int id, Comment comment, CancellationToken cancellationToken)
        {
            if (id != comment.Id)
            {
                throw new BadRequestException("id from the route is not equal to id from passed object");
            }
            _context.Entry(comment).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCommentById(int id, CancellationToken cancellationToken)
        {
            var comment = await _context.Comment.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

            if (comment is null)
            {
                throw new NotFoundException($"No comment with id = {id}");
            }

            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
