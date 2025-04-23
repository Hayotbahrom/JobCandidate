using JobCandidate.Domain.Entities;
using JobCandidate.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidate.Service.Interfaces
{
    public interface IIUserService
    {
        Task<User> AddOrUpdateUserAsync(UserDto userDto);
        Task<User> CreateAsync(UserDto userDto);
        Task<User> UpdateAsync(UserDto userDto);
        Task<User> DeleteAsync(int id);
        Task<bool> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
