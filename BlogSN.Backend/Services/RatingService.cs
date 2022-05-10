using BlogSN.Backend.Data;
using BlogSN.Backend.Exceptions;
using Microsoft.EntityFrameworkCore;
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
            var lickCheck = await _context.Post.AnyAsync(p => p.Rating.Any(v => v.ApplicationUserId == rating.ApplicationUserId && v.PostId == rating.PostId));
            if (!lickCheck)
            {
                await _context.Rating.AddAsync(rating, cancellationToken);
            }
            else throw new BadRequestException("Like is already exist");
            var post = await _context.Post.FirstOrDefaultAsync(p => p.Id == rating.PostId);
            if (rating.LikeStatus)
            {
                post.RatingCount++;
            }
            else post.RatingCount--;
            await _context.SaveChangesAsync();

        }

        public async Task UpdateRatingStatusById(int id, Rating rating, CancellationToken cancellationToken)
        {
            if (id != rating.Id)
            {
                throw new BadRequestException("id from the route is not equal to id from passed object");
            }
            _context.Entry(rating).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
