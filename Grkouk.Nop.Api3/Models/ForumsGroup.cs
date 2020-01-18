using System;
using System.Collections.Generic;

namespace Grkouk.Nop.Api3.Models
{
    public partial class ForumsGroup
    {
        public ForumsGroup()
        {
            ForumsForum = new HashSet<ForumsForum>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ICollection<ForumsForum> ForumsForum { get; set; }
    }
}
