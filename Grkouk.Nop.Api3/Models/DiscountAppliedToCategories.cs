namespace Grkouk.Nop.Api3.Models
{
    public partial class DiscountAppliedToCategories
    {
        public int DiscountId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Discount Discount { get; set; }
    }
}
