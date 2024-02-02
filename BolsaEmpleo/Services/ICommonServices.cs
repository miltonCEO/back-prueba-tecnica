using BolsaEmpleo.DTOs;

namespace BolsaEmpleo.Services
{
    public interface ICommonServices<T, TI, TU>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Add(TI userInsertDto);
        Task<T> Update(int id, TU userUpdateDto);
        Task<T> Delete(int id);
    }
}
