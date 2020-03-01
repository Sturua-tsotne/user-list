using Microsoft.EntityFrameworkCore;

namespace UserList.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<UserListDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for UserListDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
