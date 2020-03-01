using System;
using System.Threading.Tasks;
using Abp.TestBase;
using UserList.EntityFrameworkCore;
using UserList.Tests.TestDatas;

namespace UserList.Tests
{
    public class UserListTestBase : AbpIntegratedTestBase<UserListTestModule>
    {
        public UserListTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<UserListDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<UserListDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<UserListDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<UserListDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<UserListDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<UserListDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<UserListDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<UserListDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
