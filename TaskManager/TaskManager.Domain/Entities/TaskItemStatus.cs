using TaskManager.Domain.Common;

namespace TaskManager.Domain.Entities
{
    public class TaskItemStatus : BaseEntity
    {
        public string Name { get; private set; } = null!;

        public int Position { get; private set; }

        public bool IsCompleted { get; private set; }

        public Guid ProjectId { get; private set; }

        public Project Project { get; private set; } = null!;

        public ICollection<TaskItem> Tasks { get; private set; }
            = new List<TaskItem>();

        private TaskItemStatus()
        {
        }

        public TaskItemStatus(
            string name,
            int position,
            Guid projectId,
            bool isCompleted = false)
        {
            Name = name;
            Position = position;
            ProjectId = projectId;
            IsCompleted = isCompleted;
        }

        public void Rename(string name)
        {
            Name = name;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void ChangePosition(int position)
        {
            Position = position;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void MarkAsNotCompleted()
        {
            IsCompleted = false;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
