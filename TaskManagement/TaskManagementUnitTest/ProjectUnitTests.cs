using TaskManagement.Exceptions.Model.Entities;
using TaskManagement.Model.Entities;


using Task = TaskManagement.Model.Entities.Task;

namespace TaskManagementUnitTest
{
    public class ProjectUnitTests
    {
        private readonly Project Project;
        public ProjectUnitTests()
        {
            Project = new Project();
        }

        [Fact]
        public void AddTask_ShouldThrowException_WhenUserNotOnProject()
        {
            // Act & Assert
            Assert.Throws<UserNotOnProjectException>(() => Project.AddTask(1, "Task Title", "Task Description"));
        }
        [Fact]
        public void AddTask_ShouldAddTask_WhenUserIsOnProject()
        {
            // Arrange
            Project.Users.Add(new User { Id = 1 });

            // Act
            Project.AddTask(1, "Task Title", "Task Description");

            // Assert
            Assert.Single(Project.Tasks);
            var addedTask = Project.Tasks.Single();
            Assert.Equal("Task Title", addedTask.Title);
            Assert.Equal("Task Description", addedTask.Description);

        }

        [Fact]
        public void DeleteTask_ShouldThrowException_WhenTaskNotFound()
        {
            // Arrange
            Project.Users.Add(new User { Id = 1 });

            // Act & Assert
            Assert.Throws<TaskNotFoundException>(() => Project.DeleteTask(1, 1));

        }

        [Fact]
        public void DeleteTask_ShouldThrowException_WhenUserNotOnProject()
        {
            // Arrange
            Project.Tasks.Add(new Task("Task", "Task descritpion"));

            // Act & Assert
            Assert.Throws<UserNotOnProjectException>(() => Project.DeleteTask(1, 1));
        }


        [Fact]
        public void DeleteTask_ShouldDeleteTask_WhenTaskFoundAndUserOnProject()
        {
            // Arrange
            var task = new Task("Task", "Task description")
            {
                Id = 1
            };

            Project.Users.Add(new User { Id = 1 });
            Project.Tasks.Add(task);

            // Act
            Project.DeleteTask(1, 1);

            // Assert
            Assert.DoesNotContain(Project.Tasks, t => t.Id == 1);
        }

        [Fact]
        public void UpdateTask_ShouldThrowException_WhenTaskNotFound()
        {
            // Arrange
            Project.Users.Add(new User { Id = 1 });

            // Act & Assert
            Assert.Throws<TaskNotFoundException>(() => Project.UpdateTask(1, 1, "a", "aa"));
        }

        [Fact]
        public void UpdateTask_ShouldThrowException_WhenUserNotOnProject()
        {
            // Arrange
            Project.Tasks.Add(new Task("Task", "Task descritpion"));

            // Act & Assert
            Assert.Throws<UserNotOnProjectException>(() => Project.UpdateTask(1, 1, "a", "aa"));
        }

        [Fact]
        public void UpdateTask_ShouldUpdateTask_WhenTaskFoundAndUserOnProject()
        {
            // Arrange
            var task = new Task("Task", "Task description")
            {
                Id = 1
            };

            Project.Users.Add(new User { Id = 1 });
            Project.Tasks.Add(task);

            // Act
            Project.UpdateTask(1, 1, "a", "aa");

            // Assert
            Assert.Equal("a", task.Title);
            Assert.Equal("aa", task.Description);

        }
    }
}
