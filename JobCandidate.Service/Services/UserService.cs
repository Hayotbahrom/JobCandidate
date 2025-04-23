using AutoMapper;
using JobCandidate.Data.IRepository;
using JobCandidate.Domain.Entities;
using JobCandidate.Service.DTOs;
using JobCandidate.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobCandidate.Service.Services
{
    public class UserService : IIUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<User> AddOrUpdateUserAsync(UserDto userDto)
        {
            var existingUser = await userRepository.SelectAll()
                .Where(u => u.Email == userDto.Email)
                .FirstOrDefaultAsync();

            var mappedUser = mapper.Map(userDto, existingUser);

            if (existingUser == null)
                return await userRepository.CreateAsync(mappedUser);
            else
            {
                mappedUser.UpdatedAt = DateTime.UtcNow;

                return await userRepository.UpdateAsync(mappedUser);
            }
        }

        public Task<User> CreateAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
