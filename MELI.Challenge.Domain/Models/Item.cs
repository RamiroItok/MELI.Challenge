using MELI.Challenge.Domain.Enums;
using System.Text;

namespace MELI.Challenge.Domain.Models
{
    public class Item
    {
        public string Id { get; private set; }
        public int SellerId { get; private set; }
        public string Title { get; private set; }
        public Price Price { get; private set; }
        public string Description { get; private set; }
        public List<string> Pictures { get; private set; }
        public Condition Condition { get; private set; }
        public bool FreeShipping { get; private set; }
        public List<Attribute> Attributes { get; private set; } = new List<Attribute>();

        private Item() { }

        public static (Item? Item, string ErrorMessage) TryCreate(
            string id,
            int sellerId,
            string title,
            Price price,
            List<string> pictures,
            Condition condition,
            bool freeShipping,
            string description,
            List<Attribute> attributes)
        {
            var errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(id))
                errors.AppendLine("Item ID cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(title))
                errors.AppendLine("Item Title cannot be null or empty.");

            if (price is null || price.Amount <= 0)
                errors.AppendLine("Price must be greater than zero.");

            if (pictures is null || pictures.Count == 0)
                errors.AppendLine("Item must have at least one picture.");

            if (errors.Length > 0)
                return (null, errors.ToString());

            var item = new Item
            {
                Id = id,
                SellerId = sellerId,
                Title = title,
                Price = price,
                Pictures = pictures,
                Condition = condition,
                FreeShipping = freeShipping,
                Description = description,
                Attributes = attributes
            };

            return (item, string.Empty);
        }
    }
}
