using netCorev2Consist.Models;

namespace netCorev2Consist.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task DeleteUserAsync(int userId);
    }

}
