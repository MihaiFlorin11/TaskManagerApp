using TaskManager.Domain.Common;
using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities
{
    public class TaskItem : BaseEntity
    {
        public string Title { get; private set; } = null!;

        public string? Description { get; private set; }

        public TaskPriority Priority { get; private set; }

        public DateTimeOffset? DueDate { get; private set; }


        // Project

        public Guid ProjectId { get; private set; }

        public Project Project { get; private set; } = null!;


        // Status

        public Guid StatusId { get; private set; }

        public TaskItemStatus Status { get; private set; } = null!;


        // Creator

        public Guid CreatedByUserId { get; private set; }

        public User CreatedByUser { get; private set; } = null!;


        // Assignee

        public Guid? AssignedUserId { get; private set; }

        public User? AssignedUser { get; private set; }


        // Comments

        public ICollection<TaskComment> Comments { get; private set; }
            = new List<TaskComment>();


        private TaskItem()
        {
        }

        public TaskItem(
            string title,
            string? description,
            Guid projectId,
            Guid statusId,
            Guid createdByUserId,
            TaskPriority priority,
            DateTimeOffset? dueDate = null)
        {
            Title = title;
            Description = description;
            ProjectId = projectId;
            StatusId = statusId;
            CreatedByUserId = createdByUserId;
            Priority = priority;
            DueDate = dueDate;
        }

        public void UpdateDetails(
            string title,
            string? description,
            TaskPriority priority,
            DateTimeOffset? dueDate)
        {
            Title = title;
            Description = description;
            Priority = priority;
            DueDate = dueDate;

            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void ChangeStatus(Guid statusId)
        {
            StatusId = statusId;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void AssignTo(Guid userId)
        {
            AssignedUserId = userId;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void Unassign()
        {
            AssignedUserId = null;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
