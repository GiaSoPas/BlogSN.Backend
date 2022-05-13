using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ModelsBlogSN
{
    public class Rating
    {
        public string Id { get; set; }

        public bool LikeStatus { get; set; }

        public int PostId { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
