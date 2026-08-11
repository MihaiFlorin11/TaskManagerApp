using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Configurations
{
    public sealed class TaskItemConfiguration
     : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.ToTable("Tasks");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(4000);

            builder.Property(x => x.Priority)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt);

            builder.Property(x => x.DueDate);

            // Project
            builder.HasOne(x => x.Project)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Status
            builder.HasOne(x => x.Status)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            // Created by
            builder.HasOne(x => x.CreatedByUser)
                .WithMany()
                .HasForeignKey(x => x.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Assigned user
            builder.HasOne(x => x.AssignedUser)
                .WithMany(x => x.AssignedTasks)
                .HasForeignKey(x => x.AssignedUserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
