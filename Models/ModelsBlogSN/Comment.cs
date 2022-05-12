using Models.ModelsIdentity.IdentityAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BlogSN.Models;

namespace Models.ModelsBlogSN
{
    public class Comment
    {
        public Comment()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public string? Content { get; set; }

        public int PostId { get; set; }
        [JsonIgnore]
        public Post? Post { get; set; }
        public string? ApplicationUserId { get; set; }
        [JsonIgnore]
        public ApplicationUser? ApplicationUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
