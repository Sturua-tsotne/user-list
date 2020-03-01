using UserList.EntityFrameworkCore;

namespace UserList.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly UserListDbContext _context;

        public TestDataBuilder(UserListDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}