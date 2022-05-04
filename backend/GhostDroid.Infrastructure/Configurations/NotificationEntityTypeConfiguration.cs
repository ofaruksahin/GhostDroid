using GhostDroid.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostDroid.Infrastructure.Configurations
{
    public class NotificationEntityTypeConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(f => f.Id);

            builder
                .Property(f => f.PackageName)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .Property(f => f.Title)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .Property(f => f.Content)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .ToTable("Notifications");
        }
    }
}
