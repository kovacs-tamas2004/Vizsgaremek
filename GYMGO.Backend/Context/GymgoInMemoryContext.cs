using Microsoft.EntityFrameworkCore;

namespace GYMGO.Backend.Context
{
    public class GymgoInMemoryContext : GymgoContext
    {
        public GymgoInMemoryContext(DbContextOptions<GymgoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
