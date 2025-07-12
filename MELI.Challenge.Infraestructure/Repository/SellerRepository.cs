using MELI.Challenge.Domain.Models;
using MELI.Challenge.Domain.Repositories;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MELI.Challenge.Infraestructure.Repository
{
    public class SellerRepository : ISellerRepository
    {
        public async Task<SellerInfo?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var basePath = AppContext.BaseDirectory;
            var filePath = Path.Combine(basePath, "Data", "sellers.json");
            var jsonContent = await File.ReadAllTextAsync(filePath, cancellationToken);
            var sellers = JsonSerializer.Deserialize<List<SellerInfo>>(jsonContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            });

            return sellers?.FirstOrDefault(s => s.Id == id);
        }
    }
}
