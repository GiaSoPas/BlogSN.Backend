using System.Text.Json.Serialization;
using BlogSN.Models;
using Microsoft.AspNetCore.Identity;
using Models.ModelsBlogSN;

namespace Models.ModelsIdentity.IdentityAuth
{
    public class ApplicationUser : IdentityUser
    {
        public IList<Post>? Posts { get; set; }
        public IList<Comment>? Comments { get; set; }

    }
}
