using MELI.Challenge.Domain.Models;
using MELI.Challenge.Domain.Repositories;
using MELI.Challenge.Infraestructure.DTOs;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MELI.Challenge.Infraestructure.Repository
{
    public class SellerRepository : ISellerRepository
    {
        public async Task<SellerInfo?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var basePath = AppContext.BaseDirectory;
            Console.WriteLine($"[DEBUG] Ruta base del archivo: {basePath}");
            var filePath = Path.Combine(basePath, "Data", "sellers.json");
            Console.WriteLine($"[DEBUG] Ruta completa del archivo: {filePath}");
            var jsonContent = await File.ReadAllTextAsync(filePath, cancellationToken);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            };

            var sellersData = JsonSerializer.Deserialize<List<SellerData>>(jsonContent, options);

            Console.WriteLine($"SellersData: {JsonSerializer.Serialize<List<SellerData>>(sellersData)}");
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
