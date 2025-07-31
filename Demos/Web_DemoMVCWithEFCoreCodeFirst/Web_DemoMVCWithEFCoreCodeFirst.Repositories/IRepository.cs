namespace Web_DemoMVCWithEFCoreCodeFirst.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(long id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        Task DeleteAsync(long id);
    }
}
