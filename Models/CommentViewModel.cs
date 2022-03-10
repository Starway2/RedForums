﻿using Ganss.XSS;
using RedForums.Data.Mapping;
using RedForums.Data.Models;

namespace RedForums.Models
{
    public class CommentViewModel : IMapFrom<Comment>
    {
        public string Content { get; set; }

        public string CleanContent => new HtmlSanitizer().Sanitize(Content);

        public Post Post { get; set; }

        public int PostId { get; set; }

        public string UserUserName { get; set; }

        public int UserPostsCount { get; set; }

        public int UserCommentsCount { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
