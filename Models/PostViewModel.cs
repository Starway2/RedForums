using RedForums.Data.Mapping;
using RedForums.Data.Models;

namespace RedForums.Models
{
    public class PostViewModel : IMapFrom<Post>
    {
        public PostViewModel()
        {
            Comments = new HashSet<CommentViewModel>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual Category Category { get; set; }

        public string UserUserName { get; set; }

        public int UserPostCount { get; set; }

        public virtual ApplicationUser User { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
