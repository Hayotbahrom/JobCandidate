using JobCandidate.Data.IRepository;
using JobCandidate.Domain.Entities;
using JobCandidate.Service.DTOs;
using JobCandidate.Service.Interfaces;

namespace JobCandidate.Service.Services
{
    public class UserService : IIUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<User> AddOrUpdateUserAsync(UserDto userDto)
        {
            throw new NotImplementedException();
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
