using BlogSN.Backend.Data;
using BlogSN.Backend.Exceptions;
using Microsoft.EntityFrameworkCore;
using Models.ModelsBlogSN;

namespace BlogSN.Backend.Services
{
    public class RatingService : IRatingService
    {
        private readonly BlogSnDbContext _context;
        private readonly IPostService _postService;

        public RatingService(BlogSnDbContext context, IPostService postService)
        {
            _context = context;
            _postService = postService;
        }

        public async Task CreateRatingStatus(Rating rating, CancellationToken cancellationToken)
        {
            var ratingSearch = await _context.Rating.FirstOrDefaultAsync(p => p.Id == rating.Id, cancellationToken);
            if (ratingSearch is null)
            {
                await _context.Rating.AddAsync(rating, cancellationToken);
            }
            else throw new BadRequestException($"Like status {ratingSearch.LikeStatus} is already exist");
           
            var post = await _postService.GetPostById(rating.PostId, cancellationToken);
            if (rating.LikeStatus)
            {
                post.RatingCount++;
            }
            else post.RatingCount--;
            await _context.SaveChangesAsync();

        }

        public async Task DeleteRatingStatusById(string id, CancellationToken cancellationToken)
        {
            var rating = await _context.Rating.FirstOrDefaultAsync(p=> p.Id == id, cancellationToken);
            if (rating is null)
            {
                throw new NotFoundException($"No rating with id = {id}");
            }
            var post = await _postService.GetPostById(rating.PostId, cancellationToken);
            if (rating.LikeStatus)
            {
                post.RatingCount--;
            }
            else post.RatingCount++;
            _context.Remove(rating);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateRatingStatusById(string id, Rating rating, CancellationToken cancellationToken)
        {
            if (id != rating.Id)
            {
                throw new BadRequestException("id from the route is not equal to id from passed object");
            }
            var lickCheck = await _context.Rating.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            if (lickCheck is null)
            {
                throw new NotFoundException($"No rating with id = {id}");
            }
            var post = await _postService.GetPostById(rating.PostId, cancellationToken);
            if (lickCheck.LikeStatus == rating.LikeStatus)
            {
                _context.Rating.Remove(rating);
                if (rating.LikeStatus)
                {
                    post.RatingCount--;
                }
                else post.RatingCount++;
                await _context.SaveChangesAsync(cancellationToken);
                return;
            }
            post.RatingCount = rating.LikeStatus ? post.RatingCount + 2 : post.RatingCount - 2;
            _context.Entry(rating).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
