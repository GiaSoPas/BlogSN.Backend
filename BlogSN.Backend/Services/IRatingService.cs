using Models.ModelsBlogSN;

namespace BlogSN.Backend.Services
{
    public interface IRatingService
    {
        public Task CreateRatingStatus(Rating rating, CancellationToken cancellationToken);
    }
}
