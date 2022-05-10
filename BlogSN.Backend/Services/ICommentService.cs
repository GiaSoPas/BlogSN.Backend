using Models.ModelsBlogSN;

namespace BlogSN.Backend.Services
{
    public interface ICommentService
    {
        public Task CreateComment(Comment comment, CancellationToken cancellationToken);
        public Task UpdateCommentById(int id, Comment comment, CancellationToken cancellationToken);
        public Task DeleteCommentById(int id, CancellationToken cancellationToken);
        public Task<IEnumerable<Comment>> GetComments(CancellationToken cancellationToken);
    }
}
