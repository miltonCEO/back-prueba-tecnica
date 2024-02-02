using BolsaEmpleo.DTOs;
using BolsaEmpleo.Models;
using BolsaEmpleo.Repository;

namespace BolsaEmpleo.Services
{
    public class VacantApplicationService : IVacantApplicationServices<VacantApplicationDto, VacantApplicationInsertDto>
    {
        private IVacantApplicationRepository<VacantApplication> _vacantApplication;
        public VacantApplicationService(IVacantApplicationRepository<VacantApplication> vacantApplication) 
        {
            _vacantApplication = vacantApplication;
        }

        public async Task<IEnumerable<VacantApplicationDto>> Get()
        {
            var vacant = await _vacantApplication.Get();
            return vacant.Select(x => new VacantApplicationDto {
                vacantApplicationID = x.vacantApplicationID,
                vacantId = x.vacantId,
                userId = x.userId
            });
        }

        public async Task<VacantApplicationDto> GetById(int id)
        {
            var vacant = await _vacantApplication.GetById(id);

            if (vacant != null) 
            {
                var vacantAppDto = new VacantApplicationDto
                {
                    vacantApplicationID = vacant.vacantApplicationID,
                    vacantId = vacant.vacantId,
                    userId = vacant.userId
                };

                return vacantAppDto;
            }

            return null;
        }

        public async Task<VacantApplicationDto> Add(VacantApplicationInsertDto vacantApplicationInsertDto)
        {
            var vacancie = new VacantApplication()
            {
                vacantId = vacantApplicationInsertDto.vacantId,
                userId = vacantApplicationInsertDto.userId
            };

            await _vacantApplication.Add(vacancie);
            await _vacantApplication.Save();

            var vacantApplicationDto = new VacantApplicationDto
            {
                vacantApplicationID = vacancie.vacantApplicationID,
                vacantId = vacancie.vacantId,
                userId = vacancie.userId,
            };

            return vacantApplicationDto;
        }
    }
}
