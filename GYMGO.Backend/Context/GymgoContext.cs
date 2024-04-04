using GYMGO.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GYMGO.Backend.Context
{
    public class GymgoContext : DbContext
    {
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public GymgoContext(DbContextOptions<GymgoContext> options) : base(options)
        {
        }
    }
}
