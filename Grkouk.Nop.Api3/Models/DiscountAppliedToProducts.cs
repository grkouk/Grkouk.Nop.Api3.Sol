namespace Grkouk.Nop.Api3.Models
{
    public partial class DiscountAppliedToProducts
    {
        public int DiscountId { get; set; }
        public int ProductId { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual Product Product { get; set; }
    }
}
