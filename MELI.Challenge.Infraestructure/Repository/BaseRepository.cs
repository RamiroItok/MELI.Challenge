using System.Text.Json;
using System.Text.Json.Serialization;

namespace MELI.Challenge.Infraestructure.Repository
{
    public abstract class BaseRepository
    {
        protected JsonSerializerOptions DefaultJsonOptions => new()
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };

        protected async Task<string> ReadJsonFileAsync(string fileName, CancellationToken cancellationToken)
        {
            var basePath = AppContext.BaseDirectory;
            var filePath = Path.Combine(basePath, "Data", fileName);
            return await File.ReadAllTextAsync(filePath, cancellationToken);
        }
    }
}
