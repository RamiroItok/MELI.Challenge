﻿using MELI.Challenge.Domain.Models;
using MELI.Challenge.Domain.Repositories;
using MELI.Challenge.Infraestructure.DTOs;
using System.Text.Json;

namespace MELI.Challenge.Infraestructure.Repository
{
    public class ReviewRepository : BaseRepository, IReviewRepository
    {
        public async Task<IEnumerable<Review>> GetByItemIdAsync(string itemId, CancellationToken cancellationToken)
        {
            var jsonContent = await ReadJsonFileAsync("reviews.json", cancellationToken);
            var reviewsData = JsonSerializer.Deserialize<List<ReviewData>>(jsonContent, DefaultJsonOptions);

            if (reviewsData is null)
                return Enumerable.Empty<Review>();

            Console.WriteLine($"ReviewsData: {JsonSerializer.Serialize<List<ReviewData>>(reviewsData)}");
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
