using MELI.Challenge.Domain.Enums;
using MELI.Challenge.Domain.Models;
using MELI.Challenge.Domain.Repositories;
using MELI.Challenge.Infraestructure.DTOs;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MELI.Challenge.Infraestructure.Repository
{
    public class ItemRepository : IItemRepository
    {
        public async Task<Item> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Este es el ID que ingresa por parametro: {id}");
            var basePath = AppContext.BaseDirectory;
            Console.WriteLine($"[DEBUG] Ruta base del archivo: {basePath}");
            var filePath = Path.Combine(basePath, "Data", "items.json");
            Console.WriteLine($"[DEBUG] Ruta completa del archivo: {filePath}");
            var jsonContent = await File.ReadAllTextAsync(filePath, cancellationToken);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            };

            var itemsData = JsonSerializer.Deserialize<List<ItemData>>(jsonContent, options);
            Console.WriteLine($"ItemsData: {JsonSerializer.Serialize<List<ItemData>>(itemsData)}");
            var itemData = itemsData?.FirstOrDefault(i => i.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"ItemData: {JsonSerializer.Serialize<ItemData>(itemData)}");
            if (itemData is null)
                return null;

            var (item, errorMessage) = Item.TryCreate(
                itemData.Id,
                itemData.SellerId,
                itemData.Title,
                itemData.Price,
                itemData.Pictures,
                Enum.Parse<Condition>(itemData.Condition, true),
                itemData.FreeShipping,
                itemData.Description,
                itemData.Attributes
            );

            if (!string.IsNullOrEmpty(errorMessage))
            {
                Console.WriteLine(errorMessage);
                return null;
            }

            Console.WriteLine($"Item: {JsonSerializer.Serialize<Item>(item)}");

            return item;
        }
    }
}
