using databaseConection.Models.Entity;

namespace databaseConection.Services.Interfaces
{
    public interface IAuthservice
    {
        Task<List<User>> getAllUsers();
        Task<User> AddUser(User user);
        Task<User> FineUserById(Guid id);
        Task<User> UpdateUser(Guid id, User user);
        Task<User> deleteUser(Guid id);
    }
}