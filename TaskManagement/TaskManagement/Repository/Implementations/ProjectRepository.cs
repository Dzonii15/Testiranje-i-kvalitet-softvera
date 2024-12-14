using Microsoft.EntityFrameworkCore;
using TaskManagement.Model;
using TaskManagement.Model.Entities;

namespace TaskManagement.Repository.Implementations
{
    public class ProjectRepository(ApplicationDbContext dbContext) : IProjectRepository
    {
        public void AddEntity(object entity)
        {
            dbContext.Add(entity);
        }

        public async Task<Project?> GetProjectWithTasksAndUsers(int projectId)
        {
            return await dbContext.Projects.Include(p => p.Tasks).Include(p => p.Users).FirstOrDefaultAsync(p => p.Id == projectId);
        }

        public async System.Threading.Tasks.Task SaveChanges()
        {
            await dbContext.SaveChangesAsync();
        }

    }
}
