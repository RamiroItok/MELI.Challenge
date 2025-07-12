namespace MELI.Challenge.Domain.Models
{
    public class Review
    {
        public int Id { get; private set; }
        public string ItemId { get; private set; }
        public int Rating { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime DateCreated { get; private set; }

        private Review() { }

        public static (Review? Review, string ErrorMessage) TryCreate(int id, string itemId, int rating, string title, string content, DateTime dateCreated)
        {
            if (rating < 1 || rating > 5)
                return (null, "Raiting must have between 1 y 5.");

            if (string.IsNullOrWhiteSpace(title))
                return (null, "The tittle of the review can not be empty");

            var review = new Review
            {
                Id = id,
                ItemId = itemId,
                Rating = rating,
                Title = title,
                Content = content,
                DateCreated = dateCreated
            };

            return (review, string.Empty);
        }
    }
}
