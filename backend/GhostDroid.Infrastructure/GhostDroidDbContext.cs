using GhostDroid.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GhostDroid.Infrastructure
{
    public class GhostDroidDbContext : DbContext
    {
        public DbSet<Notification> Notifications{ get; set; }

        public GhostDroidDbContext(DbContextOptions<GhostDroidDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GhostDroidDbContext).Assembly);
        }
    }
}
