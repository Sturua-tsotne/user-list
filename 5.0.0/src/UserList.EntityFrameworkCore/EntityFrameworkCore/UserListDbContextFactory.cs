using UserList.Configuration;
using UserList.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace UserList.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class UserListDbContextFactory : IDesignTimeDbContextFactory<UserListDbContext>
    {
        public UserListDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<UserListDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(UserListConsts.ConnectionStringName)
            );

            return new UserListDbContext(builder.Options);
        }
    }
}