using BolsaEmpleo.DTOs;
using BolsaEmpleo.Models;
using BolsaEmpleo.Repository;

namespace BolsaEmpleo.Services
{
    public class VacancieServices : IVacancieServices<VacanciesDto>
    {

        private IVacancieRepository <Vacancies> _repository;

        public VacancieServices(IVacancieRepository<Vacancies> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<VacanciesDto>> Get()
        {
            var vacancie = await _repository.Get();
            return vacancie.Select(x => new VacanciesDto()
            {
                vacantId = x.vacantId,
                vacantCode = x.vacantCode,
                vacantJobTitle = x.vacantJobTitle,
                vacantDescription = x.vacantDescription,
                vacantCompany = x.vacantCompany,
                vacantSalary = x.vacantSalary
            });
        }

        public async Task<VacanciesDto> GetById(int id)
        {
            var vacancie = await _repository.GetById(id);

            if (vacancie != null)  
            {
                var vacancieDto = new VacanciesDto
                {
                    vacantId = vacancie.vacantId,
                    vacantCode = vacancie.vacantCode,
                    vacantJobTitle = vacancie.vacantJobTitle,
                    vacantDescription = vacancie.vacantDescription,
                    vacantCompany = vacancie.vacantCompany,
                    vacantSalary = vacancie.vacantSalary
                };

                return vacancieDto;
            }

            return null;
        }
    }
}
