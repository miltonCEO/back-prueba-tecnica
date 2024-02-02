using BolsaEmpleo.Models;
using Microsoft.EntityFrameworkCore;

namespace BolsaEmpleo.Repository
{
    public class VacantApplicationRepository : IVacantApplicationRepository<VacantApplication>
    {
        private BolsaEmpleoDBContext _context;

        public VacantApplicationRepository(BolsaEmpleoDBContext context)
        {
            _context = context;
        }       

        public async Task<IEnumerable<VacantApplication>> Get()
            => await _context.VacantApplications.ToListAsync();

        public async Task<VacantApplication> GetById(int id)
            => await _context.VacantApplications.FindAsync(id);

        public async Task Add(VacantApplication vacantApplication)
            => await _context.VacantApplications.AddAsync(vacantApplication);

        public async Task Save()
            => await _context.SaveChangesAsync();
    }
}
