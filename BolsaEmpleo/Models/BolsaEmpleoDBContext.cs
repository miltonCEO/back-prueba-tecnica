using Microsoft.EntityFrameworkCore;

namespace BolsaEmpleo.Models
{
    public class BolsaEmpleoDBContext : DbContext
    {
        public BolsaEmpleoDBContext(DbContextOptions<BolsaEmpleoDBContext> options)
            : base(options) 
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Vacancies> Vacancies { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<VacantApplication> VacantApplications { get; set; }
    }
}
