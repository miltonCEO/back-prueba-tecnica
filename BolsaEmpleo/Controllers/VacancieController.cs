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
    public class VacancieController : ControllerBase
    {
        private IVacancieServices<VacanciesDto> _services;
        private BolsaEmpleoDBContext _context;

        public VacancieController(BolsaEmpleoDBContext context,
            [FromKeyedServices("userService")] IVacancieServices<VacanciesDto> vacancieServices)
        {
            _context = context;
            _services = vacancieServices;
        }

        [HttpGet]
        public async Task<IEnumerable<VacanciesDto>> Get()
            => await _services.Get();
        

        [HttpGet("{id}")]
        public async Task<ActionResult<VacanciesDto>> GetById(int id) 
        {
            var vacancieDto = await _services.GetById(id);            
            return vacancieDto == null ? NotFound() : Ok(vacancieDto);
        }


    }
}
