using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace CI_CD_WebApp_tests
{
    public class HomeControllerTest
    {
        [Fact]
        public void About_Test()
        {
            // 1. Arrange
            var homeController = new CI_CD_WebApp.Controllers.HomeController();

            // 2. Act 
            var result = homeController.About();

            // 3. Assert 
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.True(String.Equals(viewResult.ViewData["Message"], "Your application description page."));
        }
    }
}
