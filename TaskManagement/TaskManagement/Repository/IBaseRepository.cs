namespace TaskManagement.Repository
{
    public interface IBaseRepository
    {
        Task SaveChanges();
        void AddEntity(object entity);
    }
}
