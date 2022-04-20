using BlogSN.Backend.Data;
using Models.ModelsBlogSN;

namespace BlogSN.Backend.Services
{
    public class RatingService : IRatingService
    {
        private readonly BlogSnDbContext _context;

        public RatingService(BlogSnDbContext context)
        {
            _context = context;
        }

        public async Task CreateRatingStatus(Rating rating, CancellationToken cancellationToken)
        {
            await _context.Rating.AddAsync(rating, cancellationToken);
            await _context.SaveChangesAsync();
        }
    }
}
