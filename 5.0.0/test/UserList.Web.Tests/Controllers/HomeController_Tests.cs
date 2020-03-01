using System.Threading.Tasks;
using UserList.Web.Controllers;
using Shouldly;
using Xunit;

namespace UserList.Web.Tests.Controllers
{
    public class HomeController_Tests: UserListWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
