using Microsoft.EntityFrameworkCore;

namespace Rush.Order.Repositories
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Order> Order { get; set; }
    }
}
