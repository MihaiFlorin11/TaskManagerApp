using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Configurations
{
    public sealed class ProjectMemberConfiguration
    : IEntityTypeConfiguration<ProjectMember>
    {
        public void Configure(EntityTypeBuilder<ProjectMember> builder)
        {
            builder.ToTable("ProjectMembers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Role)
                .IsRequired();

            builder.HasOne(x => x.Project)
                .WithMany(x => x.Members)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.ProjectMemberships)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new
            {
                x.ProjectId,
                x.UserId
            })
            .IsUnique();
        }
    }
}
