using System;

namespace Grkouk.Nop.Api3.Models
{
    public partial class ForumsPostVote
    {
        public int Id { get; set; }
        public int ForumPostId { get; set; }
        public int CustomerId { get; set; }
        public bool IsUp { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public virtual ForumsPost ForumPost { get; set; }
    }
}
