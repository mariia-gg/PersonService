namespace PesonService.DAL.Contract
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity?> GetAsync(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);

        Task InsertAsync(TEntity entity, CancellationToken cancellationToken);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
