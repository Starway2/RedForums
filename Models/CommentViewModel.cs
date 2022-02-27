﻿using RedForums.Data.Mapping;
using RedForums.Data.Models;

namespace RedForums.Models
{
    public class CommentViewModel : IMapFrom<Comment>
    {
        public string Content { get; set; }

        public Post Post { get; set; }

        public int PostId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }
    }
}
