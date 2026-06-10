using databaseConection.Data;
using databaseConection.Models.Entity;
using databaseConection.Repositories.Interfaces;
using databaseConection.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace databaseConection.Services
{
    public class Authservice:IAuthservice
    {
        private readonly IAuthRepository _authRepository_;
        public Authservice( IAuthRepository authRepository_)
        {
            _authRepository_ = authRepository_; 
        }


        public async Task<List<User>> getAllUsers()
        {
            var resp = await _authRepository_.GetAllUsers(); ;
            return resp;
        }

        public async Task<User> AddUser(User user)
        {
            await _authRepository_.AddUser(user);

            return user;
        }

        public async Task<User> FineUserById(Guid id)
        {
            var resp = await _authRepository_.FindUserByID(id);
            if(resp== null )
            {
                throw new Exception("User not found");
            }
            return resp;
        }

        public async Task<User> UpdateUser(Guid id , User user)
        {
            var userExist = await _authRepository_.UpdateUser(id, user);
            return userExist;
        }

        public async Task <User> deleteUser(Guid id)
        {
            var UserExist = await _authRepository_.DeleteUser(id);
            return UserExist;
        }

    }
}
