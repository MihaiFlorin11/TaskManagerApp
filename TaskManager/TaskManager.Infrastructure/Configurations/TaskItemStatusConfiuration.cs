using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Configurations
{
    public sealed class TaskItemStatusConfiguration
    : IEntityTypeConfiguration<TaskItemStatus>
    {
        public void Configure(EntityTypeBuilder<TaskItemStatus> builder)
        {
            builder.ToTable("TaskStatuses");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Position)
                .IsRequired();

            builder.Property(x => x.IsCompleted)
                .IsRequired();

            builder.HasOne(x => x.Project)
                .WithMany(x => x.TaskStatuses)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new
            {
                x.ProjectId,
                x.Name
            })
            .IsUnique();

            builder.HasIndex(x => new
            {
                x.ProjectId,
                x.Position
            });
        }
    }
}
