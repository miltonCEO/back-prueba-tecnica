namespace BolsaEmpleo.Repository
{
    public interface IVacantApplicationRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetById(int id);
        Task Add(TEntity entity);
        Task Save();
    }
}
