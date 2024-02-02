using BolsaEmpleo.DTOs;
using BolsaEmpleo.Models;
using BolsaEmpleo.Repository;
using Microsoft.EntityFrameworkCore;

namespace BolsaEmpleo.Services
{
    public class UserServices : ICommonServices<UsersDto, UserInsertDto, UserUpdateDto>
    {

        
        private IRepository<User> _userRepository;
        public UserServices(IRepository<User> userRepository) 
        {
            
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UsersDto>> Get()
        {
            var users = await _userRepository.Get();
            return users.Select(x => new UsersDto()
            {
                userId = x.userId,
                typeId = x.userId,
                userIdentification = x.userIdentification,
                userName = x.userName,
                userLastName = x.userLastName,
                userBirthday = x.userBirthday,
                userProfession = x.userProfession,
                userSalary = x.userSalary,
                userEmail = x.userEmail
            });
        }

        public async Task<UsersDto> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user != null) 
            {
                var userDto = new UsersDto
                {
                    userId = user.userId,
                    typeId = user.typeId,
                    userIdentification = user.userIdentification,
                    userName = user.userName,
                    userLastName = user.userLastName,
                    userBirthday = user.userBirthday,
                    userProfession = user.userProfession,
                    userSalary = user.userSalary,
                    userEmail = user.userEmail
                };

                return userDto;
            }

            return null;
        }

        public async Task<UsersDto> Add(UserInsertDto userInsertDto)
        {
            var user = new User()
            {
                typeId = userInsertDto.typeId,
                userIdentification = userInsertDto.userIdentification,
                userName = userInsertDto.userName,
                userLastName = userInsertDto.userLastName,
                userBirthday = userInsertDto.userBirthday,
                userProfession = userInsertDto.userProfession,
                userSalary = userInsertDto.userSalary,
                userEmail = userInsertDto.userEmail
            };

            await _userRepository.Add(user);
            await _userRepository.Save();

            var userDto = new UsersDto
            {
                userId = user.userId,
                typeId = user.typeId,
                userIdentification = user.userIdentification,
                userName = user.userName,
                userLastName = user.userLastName,
                userBirthday = user.userBirthday,
                userProfession = user.userProfession,
                userSalary = user.userSalary,
                userEmail = user.userEmail
            };

            return userDto;
        }

        public async Task<UsersDto> Update(int id, UserUpdateDto userUpdateDto)
        {
            var user = await _userRepository.GetById(id);

            if (user != null) 
            {
                user.typeId = userUpdateDto.typeId;
                user.userIdentification = userUpdateDto.userIdentification;
                user.userName = userUpdateDto.userName;
                user.userLastName = userUpdateDto.userLastName;
                user.userBirthday = userUpdateDto.userBirthday;
                user.userProfession = userUpdateDto.userProfession;
                user.userSalary = userUpdateDto.userSalary;
                user.userEmail = userUpdateDto.userEmail;

                _userRepository.Update(user);
                await _userRepository.Save();

                var userDto = new UsersDto
                {
                    userId = user.userId,
                    typeId = user.typeId,
                    userIdentification = user.userIdentification,
                    userName = user.userName,
                    userLastName = user.userLastName,
                    userBirthday = user.userBirthday,
                    userProfession = user.userProfession,
                    userSalary = user.userSalary,
                    userEmail = user.userEmail
                };

                return userDto;
            }

            return null;
        }

        public async Task<UsersDto> Delete(int id)
        {
            var user = await _userRepository.GetById(id);

            if (user != null)
            {
                var userDto = new UsersDto
                {
                    userId = user.userId,
                    typeId = user.typeId,
                    userIdentification = user.userIdentification,
                    userName = user.userName,
                    userLastName = user.userLastName,
                    userBirthday = user.userBirthday,
                    userProfession = user.userProfession,
                    userSalary = user.userSalary,
                    userEmail = user.userEmail
                };

                _userRepository.Delete(user);
                await _userRepository.Save();

                return userDto;
            }

            return null;
        }
        
    }
}
