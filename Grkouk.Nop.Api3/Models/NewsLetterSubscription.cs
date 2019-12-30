using System;

namespace Grkouk.Nop.Api3.Models
{
    public partial class NewsLetterSubscription
    {
        public int Id { get; set; }
        public Guid NewsLetterSubscriptionGuid { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public int StoreId { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
