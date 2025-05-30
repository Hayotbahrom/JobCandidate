﻿using JobCandidate.Data.DbContexts;
using JobCandidate.Data.IRepository;
using JobCandidate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobCandidate.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        AppDbContext _appDbContext;
        DbSet<User> _users;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _users = appDbContext.Users;
        }
        public async Task<User> CreateAsync(User user)
        {
            var result = (await _appDbContext.AddAsync(user)).Entity;
            await _appDbContext.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var userToDelete = await _users.Where(u => u.Id == id && u.IsDeleted == false).FirstOrDefaultAsync();

            userToDelete.IsDeleted = true;

            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public IQueryable<User> SelectAll()
        {
            return _users;
        }

        public async Task<User> SelectByIdAsync(int id)
        {
            var user = await _users.Where(u => u.Id == id && u.IsDeleted == false).FirstOrDefaultAsync();

            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var result = (_appDbContext.Update(user)).Entity;
            await _appDbContext.SaveChangesAsync();

            return result;
        }
    }
}
