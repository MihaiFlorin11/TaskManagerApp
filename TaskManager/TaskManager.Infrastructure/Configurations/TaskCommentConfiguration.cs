using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Configurations
{
    public sealed class TaskCommentConfiguration
    : IEntityTypeConfiguration<TaskComment>
    {
        public void Configure(EntityTypeBuilder<TaskComment> builder)
        {
            builder.ToTable("TaskComments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Content)
                .HasMaxLength(4000)
                .IsRequired();

            builder.HasOne(x => x.TaskItem)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.TaskItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Author)
                .WithMany()
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
