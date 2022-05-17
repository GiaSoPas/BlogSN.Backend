using System.Runtime.InteropServices.ComTypes;
using BlogSN.Backend.Data;
using BlogSN.Backend.Exceptions;
using BlogSN.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.ModelsBlogSN;
using Models.ModelsIdentity;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Services
{
    public class UserServive : IUserServive
    {
        private readonly BlogSnDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public UserServive(BlogSnDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetUserById(string id, CancellationToken cancellationToken)
        {
            var user = await _context.AspNetUsers.Include(p=> p.Posts).Include(p=> p.Comments).FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
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

        public async Task<IEnumerable<Rating>> GetRatingsByUserId(string userId, CancellationToken cancellationToken)
        {
            var userRattings = await _context.Rating.Where(x => x.ApplicationUserId == userId).ToListAsync(cancellationToken);
            if (!userRattings.Any())
            {
                throw new NotFoundException("User has no rating");
            }
            return userRattings;
        }

        public async Task DeleteUserById(string userId, CancellationToken cancellationToken)
        {
            var user = await GetUserById(userId, cancellationToken);

            _context.AspNetUsers.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateUsernameById(string userId, string newName, CancellationToken cancellationToken)
        {
            if (!_context.AspNetUsers.Any(p => p.Id == userId))
                throw new NotFoundException($"There is no user with {{id}} = {userId}.");

            var user = await _userManager.FindByIdAsync(userId);
            if (user.UserName == newName)
            {
                throw new BadRequestException("Cannot be changed to the same name");
            }
            var users = await _context.AspNetUsers.AnyAsync(p => p.UserName == newName);
            if (users)
            {
                throw new BadRequestException("User with this name exists");
            }

            user.UserName = newName;
            user.NormalizedUserName = newName.ToUpper();
            var result = await _userManager.UpdateAsync(user);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateUserEmailById(string userId, string newEmail, CancellationToken cancellationToken)
        {
            if (!_context.AspNetUsers.Any(p => p.Id == userId))
                throw new NotFoundException($"There is no user with {{id}} = {userId}.");

            var user = await _userManager.FindByIdAsync(userId);
            if (user.Email == newEmail)
            {
                throw new BadRequestException("Cannot be changed to the same email");
            }
            var users = await _context.AspNetUsers.AnyAsync(p => p.Email == newEmail);
            if (users)
            {
                throw new BadRequestException("User with this email exists");
            }

            user.Email = newEmail;
            user.NormalizedEmail = newEmail.ToUpper();
            var result = await _userManager.UpdateAsync(user);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateUserRoleToAdminById(string userId, CancellationToken cancellationToken)
        {
            if (!_context.AspNetUsers.Any(p => p.Id == userId))
                throw new NotFoundException($"There is no user with {{id}} = {userId}.");

            var user = await _userManager.FindByIdAsync(userId);
            if (user.Role == UserRole.Admin)
            {
                throw new BadRequestException("User already admin");
            }
            await _userManager.AddToRoleAsync(user,UserRole.Admin);
            await _userManager.RemoveFromRoleAsync(user,UserRole.User);
            user.Role = UserRole.Admin;
            await _userManager.UpdateAsync(user);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateUserRoleToUserById(string userId, CancellationToken cancellationToken)
        {
            if (!_context.AspNetUsers.Any(p => p.Id == userId))
                throw new NotFoundException($"There is no user with {{id}} = {userId}.");

            var user = await _userManager.FindByIdAsync(userId);
            if (user.Role == UserRole.User)
            {
                throw new BadRequestException("User already user");
            }
            await _userManager.AddToRoleAsync(user,UserRole.User);
            await _userManager.RemoveFromRoleAsync(user,UserRole.Admin);
            user.Role = UserRole.User;
            await _userManager.UpdateAsync(user);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
