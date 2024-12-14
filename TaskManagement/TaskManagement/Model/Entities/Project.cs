using TaskManagement.Exceptions.Model.Entities;
using TaskManagement.Model.Abstractions.Validation;

namespace TaskManagement.Model.Entities
{
    public class Project : ValidatableBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public List<Task> Tasks { get; set; } = [];
        public List<User> Users { get; set; } = [];

        public override void Validate()
        {

        }

        public void AddTask(int userId, string title, string? description)
        {
            CheckIfUserIsOnProject(userId);

            Task task = new(title, description);

            Tasks.Add(task);
        }

        public void DeleteTask(int userId, int taskId)
        {
            CheckIfUserIsOnProject(userId);

            var task = Tasks.FirstOrDefault(task => task.Id == taskId) ?? throw new TaskNotFoundException();

            Tasks.Remove(task);
        }
        public void UpdateTask(int userId, int taskId, string title, string? description)
        {
            CheckIfUserIsOnProject(userId);

            var task = Tasks.FirstOrDefault(task => task.Id == taskId) ?? throw new TaskNotFoundException();

            task.UpdateTask(title, description);

        }


        private void CheckIfUserIsOnProject(int userId)
        {
            if (!Users.Exists(u => u.Id == userId))
            {
                throw new UserNotOnProjectException();
            }
        }
    }
}
