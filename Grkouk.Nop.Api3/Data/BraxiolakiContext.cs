using Microsoft.EntityFrameworkCore;

namespace Grkouk.Nop.Api3.Data
{
    public class BraxiolakiContext : BaseNopContext
    {
        public BraxiolakiContext()
        {
        }

        public BraxiolakiContext(DbContextOptions<BraxiolakiContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

    }


}
