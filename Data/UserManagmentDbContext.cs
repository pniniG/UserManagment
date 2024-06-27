using Microsoft.EntityFrameworkCore;
using netCorev2Consist.Models;


namespace netCorev2Consist.Data
{
    public class UserManagmentDbContext:DbContext
    {
        public UserManagmentDbContext(DbContextOptions<UserManagmentDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } // Assuming User is your entity
    }
    
}
