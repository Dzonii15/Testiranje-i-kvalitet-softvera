using TaskManagement.Exceptions.Model.Entities;
using TaskManagement.Model.Entities;


using Task = TaskManagement.Model.Entities.Task;

namespace TaskManagementUnitTest
{
    public class ProjectUnitTests
    {
        [Fact]
        public void AddTask_ShouldThrowException_WhenUserNotOnProject()
        {
            // Arrange
            var project = new Project();

            Assert.False(true);


            // Act & Assert
            Assert.Throws<UserNotOnProjectException>(() => project.AddTask(1, "Task Title", "Task Description"));
        }
        [Fact]
        public void AddTask_ShouldAddTask_WhenUserIsOnProject()
        {
            // Arrange
            var project = new Project();
            project.Users.Add(new User { Id = 1 });

            // Act
            project.AddTask(1, "Task Title", "Task Description");

            // Assert
            Assert.Single(project.Tasks);
            var addedTask = project.Tasks.Single();
            Assert.Equal("Task Title", addedTask.Title);
            Assert.Equal("Task Description", addedTask.Description);

        }

        [Fact]
        public void DeleteTask_ShouldThrowException_WhenTaskNotFound()
        {
            // Arrange
            var project = new Project();
            project.Users.Add(new User { Id = 1 });

            // Act & Assert
            Assert.Throws<TaskNotFoundException>(() => project.DeleteTask(1, 1));

        }

        [Fact]
        public void DeleteTask_ShouldThrowException_WhenUserNotOnProject()
        {
            // Arrange
            var project = new Project();
            project.Tasks.Add(new Task("Task", "Task descritpion"));

            // Act & Assert
            Assert.Throws<UserNotOnProjectException>(() => project.DeleteTask(1, 1));
        }


        [Fact]
        public void DeleteTask_ShouldDeleteTask_WhenTaskFoundAndUserOnProject()
        {
            // Arrange
            var project = new Project();
            var task = new Task("Task", "Task description")
            {
                Id = 1
            };

            project.Users.Add(new User { Id = 1 });
            project.Tasks.Add(task);

            // Act
            project.DeleteTask(1, 1);

            // Assert
            Assert.DoesNotContain(project.Tasks, t => t.Id == 1);
        }

        [Fact]
        public void UpdateTask_ShouldThrowException_WhenTaskNotFound()
        {
            // Arrange
            var project = new Project();
            project.Users.Add(new User { Id = 1 });

            // Act & Assert
            Assert.Throws<TaskNotFoundException>(() => project.UpdateTask(1, 1, "a", "aa"));
        }

        [Fact]
        public void UpdateTask_ShouldThrowException_WhenUserNotOnProject()
        {
            // Arrange
            var project = new Project();
            project.Tasks.Add(new Task("Task", "Task descritpion"));

            // Act & Assert
            Assert.Throws<UserNotOnProjectException>(() => project.UpdateTask(1, 1, "a", "aa"));
        }

        [Fact]
        public void UpdateTask_ShouldUpdateTask_WhenTaskFoundAndUserOnProject()
        {
            // Arrange
            var project = new Project();
            var task = new Task("Task", "Task description")
            {
                Id = 1
            };

            project.Users.Add(new User { Id = 1 });
            project.Tasks.Add(task);

            // Act
            project.UpdateTask(1, 1, "a", "aa");

            // Assert
            Assert.Equal("a", task.Title);
            Assert.Equal("aa", task.Description);

        }
    }
}
