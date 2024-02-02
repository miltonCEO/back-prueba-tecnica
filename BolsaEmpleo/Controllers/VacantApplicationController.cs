using BolsaEmpleo.DTOs;
using BolsaEmpleo.Models;
using BolsaEmpleo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BolsaEmpleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacantApplicationController : ControllerBase
    {
        private IVacantApplicationServices<VacantApplicationDto, VacantApplicationInsertDto> _vacantApplicationServices;    
        private BolsaEmpleoDBContext _context;

        public VacantApplicationController(BolsaEmpleoDBContext context,
            [FromKeyedServices("vacantApplicationService")] IVacantApplicationServices<VacantApplicationDto, VacantApplicationInsertDto> vacantApplicationServices)
        {
            _context = context;
            _vacantApplicationServices = vacantApplicationServices;
        }

        [HttpGet]
        public async Task<IEnumerable<VacantApplicationDto>> Get() 
            => await _vacantApplicationServices.Get();


        [HttpGet("{id}")]
        public async Task<ActionResult<VacantApplicationDto>> GetById(int id) 
        {
            var vacantAppDto = await _vacantApplicationServices.GetById(id);
            return vacantAppDto == null ? NotFound() : Ok(vacantAppDto);
        }
            
        [HttpPost]
        public async Task<ActionResult<VacantApplicationDto>> Add(VacantApplicationInsertDto vacantApplicationInsertDto) 
        {
            var vacantAppDto = await _vacantApplicationServices.Add(vacantApplicationInsertDto);
            return CreatedAtAction(nameof(GetById), new { id = vacantAppDto.vacantId }, vacantAppDto);
        }

    }
}
