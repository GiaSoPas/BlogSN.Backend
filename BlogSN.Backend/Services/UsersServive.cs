﻿using BlogSN.Backend.Data;
using BlogSN.Backend.Exceptions;
using Microsoft.EntityFrameworkCore;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Services
{
    public class UsersServive : IUsersServive
    {
        private readonly BlogSnDbContext _context;

        public UsersServive(BlogSnDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> GetUserById(string id, CancellationToken cancellationToken)
        {
            var user = await _context.AspNetUsers.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (user is null)
            {
                throw new NotFoundException($"No post with id = {id}");
            }
            return user;
        }
    }
}
