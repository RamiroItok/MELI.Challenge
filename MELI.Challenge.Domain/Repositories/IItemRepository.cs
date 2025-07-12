using MELI.Challenge.Domain.Models;

namespace MELI.Challenge.Domain.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetByIdAsync(string id, CancellationToken cancellationToken);
    }
}
