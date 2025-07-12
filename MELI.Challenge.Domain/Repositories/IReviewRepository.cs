using MELI.Challenge.Domain.Models;

namespace MELI.Challenge.Domain.Repositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetByItemIdAsync(string itemId, CancellationToken cancellationToken);
    }
}
