using MELI.Challenge.Domain.Enums;
using MELI.Challenge.Domain.Models;
using Attribute = MELI.Challenge.Domain.Models.Attribute;

namespace MELI.Challenge.Tests.Domain
{
    public class ItemTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void TryCreate_Should_ReturnFailure_WhenTitleIsInvalid(string invalidTitle)
        {
            // Arrange:
            var price = new Price(100m, Currency.USD);
            var pictures = new List<string> { "pic.jpg" };
            var attributes = new List<Attribute>();

            // Act:
            var (item, errorMessage) = Item.TryCreate(
                id: "MLA1",
                sellerId: 1,
                title: invalidTitle,
                price: price,
                pictures: pictures,
                condition: Condition.New,
                freeShipping: false,
                description: "A valid description",
                attributes: attributes
            );

            // Assert:
            Assert.Null(item);
            Assert.False(string.IsNullOrEmpty(errorMessage));
        }

        [Fact]
        public void TryCreate_Should_ReturnSuccess_WhenDataIsValid()
        {
            // Arrange
            var price = new Price(100m, Currency.USD);
            var pictures = new List<string> { "pic.jpg" };
            var attributes = new List<Attribute>();

            // Act
            var (item, errorMessage) = Item.TryCreate(
                id: "MLA1",
                sellerId: 1,
                title: "A valid title",
                price: price,
                pictures: pictures,
                condition: Condition.New,
                freeShipping: false,
                description: "A valid description",
                attributes: attributes
            );

            // Assert
            Assert.NotNull(item);
            Assert.True(string.IsNullOrEmpty(errorMessage));
            Assert.Equal("MLA1", item.Id);
        }

        [Fact]
        public void TryCreate_Should_ReturnFailure_WhenPriceIsNegative()
        {
            // Arrange:
            var invalidPrice = new Price(-50, Currency.USD);
            var pictures = new List<string> { "pic.jpg" };
            var attributes = new List<Attribute>();

            // Act:
            var (item, errorMessage) = Item.TryCreate(
                id: "MLA1",
                sellerId: 1,
                title: "Valid Title",
                price: invalidPrice,
                pictures: pictures,
                condition: Condition.New,
                freeShipping: false,
                description: "A valid description",
                attributes: attributes
            );

            // Assert:
            Assert.Null(item);
            Assert.False(string.IsNullOrEmpty(errorMessage));
        }
    }
}
