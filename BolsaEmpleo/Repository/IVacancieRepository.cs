namespace BolsaEmpleo.Repository
{
    public interface IVacancieRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetById(int id);
    }
}
