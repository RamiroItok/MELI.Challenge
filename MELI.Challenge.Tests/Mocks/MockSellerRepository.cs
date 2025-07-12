using MELI.Challenge.Domain.Enums;
using MELI.Challenge.Domain.Models;
using MELI.Challenge.Domain.Repositories;

namespace MELI.Challenge.Tests.Mocks
{
    public class MockSellerRepository : ISellerRepository
    {
        public Task<SellerInfo?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id != 1001)
                return Task.FromResult<SellerInfo?>(null);

            var seller = new SellerInfo(
                id: 1001,
                nickname: "VENDEDOR_DE_PRUEBA",
                reputation: Reputation.MercadoLiderPlatinum,
                sellingSince: 2019
            );

            return Task.FromResult<SellerInfo?>(seller);
        }
    }
}
