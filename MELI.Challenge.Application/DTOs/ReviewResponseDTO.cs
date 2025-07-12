namespace MELI.Challenge.Application.DTOs
{
    public class ReviewResponseDTO
    {
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
