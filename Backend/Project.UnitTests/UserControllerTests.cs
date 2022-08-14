using system;
using Moq;
using Project.Api.DAL;
using Project.Api.DAL.Entities

namespace Project.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void GetSpecificUser_WithUnexistingItem_ReturnsNotFoud()
        {
            var repositoryStub = new Mock<AppDbContext>();

            repositoryStub.Setup(repo => repo.FirstAsync(It.IsAny<Guid>())).ReturnsAsync((User)null);
        }
    }
}
