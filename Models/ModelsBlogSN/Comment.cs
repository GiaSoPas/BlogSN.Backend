using Models.ModelsIdentity.IdentityAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ModelsBlogSN
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int PostId { get; set; }

        public string ApplicationUserId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
