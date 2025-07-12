using MELI.Challenge.Application.Queries;
using MELI.Challenge.Tests.Mocks;

namespace MELI.Challenge.Tests
{
    public class GetItemByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_Should_ReturnSuccess_WhenItemExists()
        {
            // Arrange
            var itemRepoMock = new MockItemRepository();
            var sellerRepoMock = new MockSellerRepository();
            var reviewRepoMock = new MockReviewRepository();

            var handler = new GetItemByIdQueryHandler(itemRepoMock, sellerRepoMock, reviewRepoMock);
            var request = new GetItemByIdRequest("MLA123_SUCCESS");

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Data);
            Assert.Equal("MLA123_SUCCESS", response.Data.Id);
        }

        [Fact]
        public async Task Handle_Should_ReturnFailure_WhenItemDoesNotExist()
        {
            // Arrange
            var itemRepoMock = new MockItemRepository();
            var sellerRepoMock = new MockSellerRepository();
            var reviewRepoMock = new MockReviewRepository();

            var handler = new GetItemByIdQueryHandler(itemRepoMock, sellerRepoMock, reviewRepoMock);
            var request = new GetItemByIdRequest("ID_INEXISTENTE");

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(response.IsSuccess);
            Assert.Null(response.Data);
            Assert.Equal("Product do not exist", response.ErrorMessage);
        }
    }
}
