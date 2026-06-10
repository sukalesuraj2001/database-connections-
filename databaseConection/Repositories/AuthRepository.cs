using databaseConection.Data;
using databaseConection.Models.Entity;
using databaseConection.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace databaseConection.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;
        public AuthRepository(AppDbContext context)
        {
            _context = context;

        }



        public async Task<List<User>> GetAllUsers()
        {
            var resp = await _context.Users.ToListAsync();
            return resp;
        }

        public async Task<User> AddUser(User user)
        {
            var resp = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
        public async Task<User> FindUserByID(Guid id)
        {
            var resp = await _context.Users.FindAsync(id);
            if (resp == null)
            {
                throw new Exception("User not found");
            }
            return resp;
        }

        public async Task<User> UpdateUser(Guid id , User user)
        {
            var existUser = await _context.Users.FindAsync(id);

            if (existUser == null)
            {
                throw new Exception("User not found");
            }

            existUser.Name = user.Name;

            await _context.SaveChangesAsync();

            return existUser;
        }



        public async Task<User> DeleteUser(Guid id)
        {
            var userExist = await _context.Users.FindAsync(id);
            if(userExist == null)
            {
                throw new Exception("User not found");
            }

            _context.Users.Remove(userExist);
            await _context.SaveChangesAsync();

            return userExist;
        }

    }
}
