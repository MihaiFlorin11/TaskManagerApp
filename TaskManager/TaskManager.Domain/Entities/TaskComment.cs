using TaskManager.Domain.Common;

namespace TaskManager.Domain.Entities
{
    public class TaskComment : BaseEntity
    {
        public string Content { get; private set; } = null!;

        public Guid TaskItemId { get; private set; }

        public TaskItem TaskItem { get; private set; } = null!;

        public Guid AuthorId { get; private set; }

        public User Author { get; private set; } = null!;

        private TaskComment()
        {
        }

        public TaskComment(
            Guid taskItemId,
            Guid authorId,
            string content)
        {
            TaskItemId = taskItemId;
            AuthorId = authorId;
            Content = content;
        }

        public void UpdateContent(string content)
        {
            Content = content;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
