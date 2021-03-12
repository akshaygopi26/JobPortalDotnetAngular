using System.Threading.Tasks;
using JobPortal.Models.TokenAuth;
using JobPortal.Web.Controllers;
using Shouldly;
using Xunit;

namespace JobPortal.Web.Tests.Controllers
{
    public class HomeController_Tests: JobPortalWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}