using System;
using Moq;
using Project.Api.DAL;
using Project.Api.DAL.Entities;
// using Microsoft.AspNetCore.Mvc.NotFoundResult;

namespace Project.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void GetSpecificUser_WithUnexistingItem_ReturnsNotFoud()
        {
            var repositoryStub = new Mock<AppDbContext>();

            repositoryStub.Setup(repo => repo.FirstAsync(It.IsAny<Guid>())).ReturnsAsync((User)null);

            var controller = new UserController(repositoryStub.Object);

            var result = await controller.FirstAsync(Guid.NewGuid());

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
