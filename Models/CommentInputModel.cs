﻿namespace RedForums.Models
{
    public class CommentInputModel
    {
        public int? Id { get; set;
        }
        public string Content { get; set; }

        public int PostId { get; set; }

        public string UserId { get; set; }

    }
}
