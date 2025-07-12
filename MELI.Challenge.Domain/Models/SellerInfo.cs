using MELI.Challenge.Domain.Enums;

namespace MELI.Challenge.Domain.Models
{
    public class SellerInfo
    {
        public int Id { get; }
        public string Nickname { get; }
        public Reputation Reputation { get; }
        public int SellingSince { get; }

        public SellerInfo(int id, string nickname, Reputation reputation, int sellingSince)
        {
            Id = id;
            Nickname = nickname;
            Reputation = reputation;
            SellingSince = sellingSince;
        }
    }
}
