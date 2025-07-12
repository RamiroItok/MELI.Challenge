using MELI.Challenge.Domain.Models;
using MELI.Challenge.Domain.Repositories;

namespace MELI.Challenge.Tests.Mocks
{
    public class MockReviewRepository : IReviewRepository
    {
        public Task<IEnumerable<Review>> GetByItemIdAsync(string itemId, CancellationToken cancellationToken)
        {
            if (itemId != "MLA123_SUCCESS")
                return Task.FromResult(Enumerable.Empty<Review>());

            var (review1, _) = Review.TryCreate(501, itemId, 5, "Excelente!", "Muy buen producto.", DateTime.UtcNow.AddDays(-10));
            var (review2, _) = Review.TryCreate(502, itemId, 4, "Cumple", "Es lo que esperaba.", DateTime.UtcNow.AddDays(-5));

            var reviews = new List<Review> { review1, review2 };

            return Task.FromResult<IEnumerable<Review>>(reviews);
        }
    }
}
