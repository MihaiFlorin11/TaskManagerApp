using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Configurations
{
    public sealed class UserConfiguration
    : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .HasMaxLength(320)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.HasIndex(x => x.Email)
                .IsUnique();
        }
    }
}
