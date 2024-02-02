using BolsaEmpleo.DTOs;
using BolsaEmpleo.Models;
using BolsaEmpleo.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BolsaEmpleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        private IValidator<UserInsertDto> _validator;
        private ICommonServices<UsersDto, UserInsertDto, UserUpdateDto> _userServices;

        public UsersController(IValidator<UserInsertDto> userInsertValidator,
            [FromKeyedServices("userService")] ICommonServices<UsersDto, UserInsertDto, UserUpdateDto> userServices) 
        {            
            _validator = userInsertValidator;
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<IEnumerable<UsersDto>> Get() =>
            await _userServices.Get();


        [HttpGet("{id}")]
        public async Task<ActionResult<UsersDto>> GetById(int id) 
        {
            var userDto = await _userServices.GetById(id);
            return userDto == null ? NotFound() : Ok(userDto);
        }


        [HttpPost]
        public async Task<ActionResult<UsersDto>> Add(UserInsertDto userInsertDto) 
        {
            var validateResult = await _validator.ValidateAsync(userInsertDto);

            if (!validateResult.IsValid) 
            {
                return BadRequest(validateResult.Errors);
            }

            var userDto = await _userServices.Add(userInsertDto);

            return CreatedAtAction(nameof(GetById), new { id = userDto.userId }, userDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsersDto>> Update(int id, UserUpdateDto userUpdateDto)
        {            
            var userDto = await _userServices.Update(id, userUpdateDto);
            return userDto == null ? NotFound() : Ok(userDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsersDto>> Delete(int id) 
        {
            var userDto = await _userServices.Delete(id);
            return userDto == null ? NotFound() : Ok(userDto);
        }
    }


    

}
