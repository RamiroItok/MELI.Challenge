using MELI.Challenge.Domain.Models;

namespace MELI.Challenge.Domain.Repositories
{
    public interface ISellerRepository
    {
        Task<SellerInfo?> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
