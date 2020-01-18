using System;

namespace Grkouk.Nop.Api3.Models
{
    public partial class BlogComment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CommentText { get; set; }
        public bool IsApproved { get; set; }
        public int StoreId { get; set; }
        public int BlogPostId { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public virtual BlogPost BlogPost { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
    }
}
