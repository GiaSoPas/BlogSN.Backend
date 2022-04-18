using BlogSN.Models;
using Microsoft.AspNetCore.Identity;

namespace Models.ModelsIdentity.IdentityAuth
{
    public class ApplicationUser : IdentityUser
    {
        public IList<Post> Posts { get; set; }
    }
}
