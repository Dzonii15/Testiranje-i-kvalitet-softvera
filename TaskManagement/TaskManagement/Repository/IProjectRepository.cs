using TaskManagement.Model.Entities;

namespace TaskManagement.Repository
{
    public interface IProjectRepository : IBaseRepository
    {
        Task<Project?> GetProjectWithTasksAndUsers(int projectId);
    }
}
