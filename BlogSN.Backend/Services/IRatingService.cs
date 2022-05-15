using Models.ModelsBlogSN;

namespace BlogSN.Backend.Services
{
    public interface IRatingService
    {
        public Task CreateRatingStatus(Rating rating, CancellationToken cancellationToken);
        public Task UpdateRatingStatusById(string id, Rating rating, CancellationToken cancellationToken);
        public Task DeleteRatingStatusById(string id, CancellationToken cancellationToken);
    }
}
