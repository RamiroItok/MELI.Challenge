using MELI.Challenge.Application.Queries;
using MELI.Challenge.Domain.Shared;
using MELI.Challenge.Tests.Mocks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace MELI.Challenge.Tests
{
    public class GetItemByIdQueryHandlerTests
    {
        private readonly MockItemRepository _itemRepoMock;
        private readonly MockSellerRepository _sellerRepoMock;
        private readonly MockReviewRepository _reviewRepoMock;
        private readonly ILogger<GetItemByIdQueryHandler> _loggerMock;
        private readonly GetItemByIdQueryHandler _handler;

        public GetItemByIdQueryHandlerTests()
        {
            _itemRepoMock = new MockItemRepository();
            _sellerRepoMock = new MockSellerRepository();
            _reviewRepoMock = new MockReviewRepository();
            _loggerMock = NullLogger<GetItemByIdQueryHandler>.Instance;

            _handler = new GetItemByIdQueryHandler(_itemRepoMock, _sellerRepoMock, _reviewRepoMock, _loggerMock);
        }

        [Fact]
        public async Task Handle_Should_ReturnSuccess_WhenItemExists()
        {
            // Arrange
            var request = new GetItemByIdRequest()
            {
                Id = "MLA123_SUCCESS"
            };

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Data);
            Assert.Equal("MLA123_SUCCESS", response.Data.Id);
        }

        [Fact]
        public async Task Handle_Should_ReturnFailure_WhenItemDoesNotExist()
        {
            // Arrange
            var request = new GetItemByIdRequest()
            {
                Id = "ID_INEXISTENTE"
            };

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(response.IsSuccess);
            Assert.Null(response.Data);
            Assert.Equal(ItemsErrors.ProductDoNotExist, response.ErrorMessage);
        }
    }
}
