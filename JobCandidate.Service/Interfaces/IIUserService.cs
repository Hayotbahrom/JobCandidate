using JobCandidate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidate.Service.Interfaces
{
    public interface IIUserService
    {
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User> DeleteAsync(int id);
        Task<bool> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
