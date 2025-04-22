using JobCandidate.Domain.Entities;

namespace JobCandidate.Data.IRepository
{
    public  interface IUserRepository
    {
        public Task<User> CreateAsync(User user);
        public Task<User> UpdateAsync(User user);
        public Task<User> SelectByIdAsync(int id);
        public IQueryable<User> SelectAll();
        public Task<bool> DeleteByIdAsync(int id);
    }
}
