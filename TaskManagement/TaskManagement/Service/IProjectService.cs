namespace TaskManagement.Service
{
    public interface IProjectService
    {
        public Task AddTaskToProject(int projectId, int userId, string title, string? description);
        public Task DeleteTaskFromProject(int projectId, int userId, int taskId);
        public Task UpdateTaskFromProject(int projectId, int userId, int taskId, string title, string? description);
    }
}
