namespace BolsaEmpleo.Services
{
    public interface IVacancieServices<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
    }
}
