namespace MELI.Challenge.Infraestructure.DTOs
{
    public class ReviewData
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
