using TaskManagement.Exceptions.Http;
using TaskManagement.Repository;

namespace TaskManagement.Service.Implementations
{
    public class ProjectService(IProjectRepository projectRepository) : IProjectService
    {
        public async Task AddTaskToProject(int projectId, int userId, string title, string? description)
        {
            var project = await projectRepository.GetProjectWithTasksAndUsers(projectId) ?? throw new NotFoundException();

            project.AddTask(userId, title, description);

            await projectRepository.SaveChanges();
        }

        public async Task DeleteTaskFromProject(int projectId, int userId, int taskId)
        {
            var project = await projectRepository.GetProjectWithTasksAndUsers(projectId) ?? throw new NotFoundException();

            project.DeleteTask(userId, taskId);

            await projectRepository.SaveChanges();
        }

        public async Task UpdateTaskFromProject(int projectId, int userId, int taskId, string title, string? description)
        {
            var project = await projectRepository.GetProjectWithTasksAndUsers(projectId) ?? throw new NotFoundException();

            project.UpdateTask(userId, taskId, title, description);

            await projectRepository.SaveChanges();
        }
    }
}
