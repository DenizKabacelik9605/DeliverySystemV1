using Microsoft.EntityFrameworkCore;

namespace DeliveryEntityframeworkCrud.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Delivery2> deliveries { get; set; }
    }
}
