using TaskManager.Domain.Common;

namespace TaskManager.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; private set; } = null!;

        public string? Description { get; private set; }

        public Guid OwnerId { get; private set; }

        public User Owner { get; private set; } = null!;

        public ICollection<TaskItem> Tasks { get; private set; }
            = new List<TaskItem>();

        public ICollection<TaskItemStatus> TaskStatuses { get; private set; }
            = new List<TaskItemStatus>();

        public ICollection<ProjectMember> Members { get; private set; }
            = new List<ProjectMember>();

        private Project()
        {
        }

        public Project(
            string name,
            string? description,
            Guid ownerId)
        {
            Name = name;
            Description = description;
            OwnerId = ownerId;
        }

        public void Update(
            string name,
            string? description)
        {
            Name = name;
            Description = description;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
