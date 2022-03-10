using Ganss.XSS;
using RedForums.Data.Mapping;
using RedForums.Data.Models;

namespace RedForums.Models
{
    public class PostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string CleanContent => new HtmlSanitizer().Sanitize(Content);

        public DateTime CreatedOn { get; set; }

        public virtual Category Category { get; set; }

        public string UserUserName { get; set; }

        public int UserPostsCount { get; set; }

        public int UserCommentsCount { get; set; }

        public virtual ApplicationUser User { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
