using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Context
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();

        public DbSet<Project> Projects => Set<Project>();

        public DbSet<ProjectMember> ProjectMembers => Set<ProjectMember>();

        public DbSet<TaskItem> Tasks => Set<TaskItem>();

        public DbSet<TaskItemStatus> TaskStatuses => Set<TaskItemStatus>();

        public DbSet<TaskComment> TaskComments => Set<TaskComment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ApplicationDbContext).Assembly);
        }
    }
}
