using System.Runtime.InteropServices.ComTypes;
using BlogSN.Backend.Data;
using BlogSN.Backend.Exceptions;
using BlogSN.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.ModelsBlogSN;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Services
{
    public class UserServive : IUserServive
    {
        private readonly BlogSnDbContext _context;
   

        public UserServive(BlogSnDbContext context, UserManager<ApplicationUser> userManager)
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
            var userPosts = await _context.Post.Where(x => x.ApplicationUserId == id).Include(p => p.Category).Include(p => p.ApplicationUser).ToListAsync(cancellationToken);
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

        public async Task<IEnumerable<Comment>> GetCommentsByUserId(string userId, CancellationToken cancellationToken)
        {
            var userComments = await _context.Comment.Where(x => x.ApplicationUserId == userId).ToListAsync(cancellationToken);
            if (!userComments.Any())
            {
                throw new NotFoundException($"User has no comments");
            }
            return userComments;
        }

        public async Task DeleteUserById(string userId, CancellationToken cancellationToken)
        {
            var user = await GetUserById(userId, cancellationToken);

            _context.AspNetUsers.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateUserById(string userId, ApplicationUser applicationUser, CancellationToken cancellationToken)
        {
            if (userId != applicationUser.Id)
            {
                throw new BadRequestException("id from the route is not equal to id from passed object");
            }

            if(!_context.AspNetUsers.Any(p=> p.Id == userId))
                throw new NotFoundException($"There is no post with {{id}} = {userId}.");
            
            _context.Entry(applicationUser).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
