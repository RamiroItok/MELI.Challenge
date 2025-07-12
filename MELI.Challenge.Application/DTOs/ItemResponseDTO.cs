namespace MELI.Challenge.Application.DTOs
{
    public class ItemResponseDTO
    {
        public string Id { get; set; }
        public SellerInfoResponseDTO Seller { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public List<string> Pictures { get; set; }
        public string Condition { get; set; }
        public bool FreeShipping { get; set; }
        public string Description { get; set; }
        public List<ReviewResponseDTO> Reviews { get; set; }
    }
}
