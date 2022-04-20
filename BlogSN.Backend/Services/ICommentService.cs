using Models.ModelsBlogSN;

namespace BlogSN.Backend.Services
{
    public interface ICommentService
    {
        public Task CreateComment(Comment comment, CancellationToken cancellationToken);
    }
}
