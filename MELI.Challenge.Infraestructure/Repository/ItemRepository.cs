using MELI.Challenge.Domain.Enums;
using MELI.Challenge.Domain.Models;
using MELI.Challenge.Domain.Repositories;
using MELI.Challenge.Infraestructure.DTOs;
using System.Text.Json;

namespace MELI.Challenge.Infraestructure.Repository
{
    public class ItemRepository : BaseRepository, IItemRepository
    {
        public async Task<Item> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var jsonContent = await ReadJsonFileAsync("items.json", cancellationToken);
            var itemsData = JsonSerializer.Deserialize<List<ItemData>>(jsonContent, DefaultJsonOptions);
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

            return item;
        }
    }
}
