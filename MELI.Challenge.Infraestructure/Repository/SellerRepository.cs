using MELI.Challenge.Domain.Models;
using MELI.Challenge.Domain.Repositories;
using MELI.Challenge.Infraestructure.DTOs;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MELI.Challenge.Infraestructure.Repository
{
    public class SellerRepository : BaseRepository, ISellerRepository
    {
        public async Task<SellerInfo?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var jsonContent = await ReadJsonFileAsync("sellers.json", cancellationToken);
            var sellersData = JsonSerializer.Deserialize<List<SellerData>>(jsonContent, DefaultJsonOptions);
            var sellerData = sellersData?.FirstOrDefault(s => s.Id == id);

            if (sellerData is null)
                return null;

            var (seller, errorMessage) = SellerInfo.TryCreate(
                sellerData.Id,
                sellerData.Nickname,
                sellerData.Reputation,
                sellerData.SellingSince
            );

            if (!string.IsNullOrEmpty(errorMessage))
            {
                Console.WriteLine($"Error al validar el vendedor {sellerData.Id}: {errorMessage}");
                return null;
            }

            return seller;
        }
    }
}
