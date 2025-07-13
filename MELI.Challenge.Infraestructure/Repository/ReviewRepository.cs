using MELI.Challenge.Domain.Models;
using MELI.Challenge.Domain.Repositories;
using MELI.Challenge.Infraestructure.DTOs;
using System.Text.Json;

namespace MELI.Challenge.Infraestructure.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        public async Task<IEnumerable<Review>> GetByItemIdAsync(string itemId, CancellationToken cancellationToken)
        {
            var basePath = AppContext.BaseDirectory;
            var filePath = Path.Combine(basePath, "Data", "Reviews.json");
            var jsonContent = await File.ReadAllTextAsync(filePath, cancellationToken);

            var reviewsData = JsonSerializer.Deserialize<List<ReviewData>>(jsonContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (reviewsData is null)
                return Enumerable.Empty<Review>();

            var filteredReviewsData = reviewsData.Where(r => r.ItemId.Equals(itemId, StringComparison.OrdinalIgnoreCase));

            var validReviews = new List<Review>();
            foreach (var reviewData in filteredReviewsData)
            {
                var (review, errorMessage) = Review.TryCreate(
                    reviewData.Id,
                    reviewData.ItemId,
                    reviewData.Rating,
                    reviewData.Title,
                    reviewData.Content,
                    reviewData.DateCreated
                );

                if (review is not null)
                    validReviews.Add(review);
                else
                    Console.WriteLine($"Error al validar la review {reviewData.Id}: {errorMessage}");
            }

            return validReviews;
        }
    }
}
