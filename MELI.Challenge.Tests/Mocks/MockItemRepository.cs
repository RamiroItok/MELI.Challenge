using MELI.Challenge.Domain.Enums;
using MELI.Challenge.Domain.Models;
using MELI.Challenge.Domain.Repositories;

namespace MELI.Challenge.Tests.Mocks
{
    public class MockItemRepository : IItemRepository
    {
        public Task<Item?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            if (id != "MLA123_SUCCESS")
                return Task.FromResult<Item?>(null);

            var (item, errorMessage) = Item.TryCreate(
                id: "MLA123_SUCCESS",
                sellerId: 1001,
                title: "Producto de Prueba",
                price: new Price(199.99m, Currency.USD),
                pictures: new List<string> { "http://example.com/pic1.jpg" },
                condition: Condition.New,
                freeShipping: true,
                description: "Esta es una descripción de prueba.",
                attributes: new List<Challenge.Domain.Models.Attribute>
                {
                    new("Color", "Negro")
                }
            );

            return Task.FromResult(item);
        }
    }
}
