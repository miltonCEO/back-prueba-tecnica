namespace BolsaEmpleo.Services
{
    public interface IVacantApplicationServices<T, TI>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Add(TI vacantApplicationInsertDto);
    }
}
