using Microsoft.EntityFrameworkCore;

namespace Grkouk.Nop.Api3.Data
{
    public class HandmadeDbContext : BaseNopContext
    {
        public HandmadeDbContext()
        {
        }

        public HandmadeDbContext(DbContextOptions<HandmadeDbContext> options)
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