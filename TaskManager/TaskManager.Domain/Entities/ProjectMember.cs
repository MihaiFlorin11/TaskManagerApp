using TaskManager.Domain.Common;
using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities
{
    public class ProjectMember : BaseEntity
    {
        public Guid ProjectId { get; private set; }

        public Project Project { get; private set; } = null!;

        public Guid UserId { get; private set; }

        public User User { get; private set; } = null!;

        public ProjectMemberRole Role { get; private set; }

        private ProjectMember()
        {
        }

        public ProjectMember(
            Guid projectId,
            Guid userId,
            ProjectMemberRole role)
        {
            ProjectId = projectId;
            UserId = userId;
            Role = role;
        }

        public void ChangeRole(ProjectMemberRole role)
        {
            Role = role;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
