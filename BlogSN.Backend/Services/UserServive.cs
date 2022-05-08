using BlogSN.Backend.Data;
using BlogSN.Backend.Exceptions;
using BlogSN.Models;
using Microsoft.EntityFrameworkCore;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Services
{
    public class UserServive : IUserServive
    {
        private readonly BlogSnDbContext _context;

        public UserServive(BlogSnDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> GetUserById(string id, CancellationToken cancellationToken)
        {
            var user = await _context.AspNetUsers.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (user is null)
            {
                throw new NotFoundException($"No user with id = {id}");
            }
            return user;
        }

        public async Task<IEnumerable<Post>> GetPostsByUserId(string id, CancellationToken cancellationToken)
        {
            var userPosts = await _context.Post.Where(x => x.ApplicationUserId == id).ToListAsync(cancellationToken);
            if (!userPosts.Any())
            {
                throw new NotFoundException($"User has no posts");
            }
            return userPosts;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsers(CancellationToken cancellationToken)
        {
            var users = await _context.AspNetUsers.ToListAsync(cancellationToken);
            if (!users.Any())
            {
                throw new NotFoundException($"No users");
            }
            return users;
        }
    }
}
