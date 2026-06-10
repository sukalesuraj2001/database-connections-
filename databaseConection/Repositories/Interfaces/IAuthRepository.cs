using databaseConection.Models.Entity;

namespace databaseConection.Repositories.Interfaces
{
    public interface IAuthRepository
    {

        public Task<List<User>> GetAllUsers();
        public Task<User> AddUser(User user);
        public Task<User> FindUserByID(Guid id);
        public Task<User> UpdateUser(Guid id, User user);
        public Task<User> DeleteUser(Guid id);
    }
}
