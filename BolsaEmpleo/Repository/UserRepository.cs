﻿using BolsaEmpleo.Models;
using Microsoft.EntityFrameworkCore;

namespace BolsaEmpleo.Repository
{
    public class UserRepository : IRepository<User>
    {
        private BolsaEmpleoDBContext _context;

        public UserRepository(BolsaEmpleoDBContext context) 
        {
            _context = context;    
        }

        public async Task<IEnumerable<User>> Get()
            => await _context.Users.ToListAsync();

        public async Task<User> GetById(int id)
            => await _context.Users.FindAsync(id);

        public async Task Add(User user)
            => await _context.Users.AddAsync(user);

        public void Update(User user)
        {
            _context.Users.Attach(user);
            _context.Users.Entry(user).State = EntityState.Modified;
        }

        public void Delete(User user)
            => _context.Users.Remove(user);
        

        public async Task Save()
            => await _context.SaveChangesAsync();

        
    }
}
