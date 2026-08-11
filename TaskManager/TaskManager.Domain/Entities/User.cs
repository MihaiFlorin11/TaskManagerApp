using TaskManager.Domain.Common;

namespace TaskManager.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; private set; } = null!;

        public string FirstName { get; private set; } = null!;

        public string LastName { get; private set; } = null!;

        public bool IsActive { get; private set; }

        public ICollection<Project> OwnedProjects { get; private set; }
            = new List<Project>();

        public ICollection<ProjectMember> ProjectMemberships { get; private set; }
            = new List<ProjectMember>();

        public ICollection<TaskItem> AssignedTasks { get; private set; }
            = new List<TaskItem>();

        private User()
        {
        }

        public User(
            string email,
            string firstName,
            string lastName)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            IsActive = true;
        }

        public void UpdateProfile(
            string firstName,
            string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void Deactivate()
        {
            IsActive = false;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
