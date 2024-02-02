using BolsaEmpleo.Models;
using Microsoft.EntityFrameworkCore;

namespace BolsaEmpleo.Repository
{
    public class VacancieRepository : IVacancieRepository<Vacancies>
    {
        private BolsaEmpleoDBContext _context;

        public VacancieRepository(BolsaEmpleoDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vacancies>> Get()
            => await _context.Vacancies.ToListAsync();

        public async Task<Vacancies> GetById(int id)
            => await _context.Vacancies.FindAsync(id);
    }
}
