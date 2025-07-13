using MELI.Challenge.Domain.Enums;

namespace MELI.Challenge.Infraestructure.DTOs
{
    internal class SellerData
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public Reputation Reputation { get; set; }
        public int SellingSince { get; set; }
    }
}
