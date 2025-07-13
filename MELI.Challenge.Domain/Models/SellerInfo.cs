using MELI.Challenge.Domain.Enums;
using MELI.Challenge.Domain.Shared;
using System.Text;

namespace MELI.Challenge.Domain.Models
{
    public class SellerInfo
    {
        public int Id { get; private set; }
        public string Nickname { get; private set; }
        public Reputation Reputation { get; private set; }
        public int SellingSince { get; private set; }

        private SellerInfo() { }
        public static (SellerInfo? seller, string ErrorMessage) TryCreate(
            int id, string nickname, Reputation reputation, int sellingSince)
        {
            var errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(nickname))
                errors.AppendLine(SellersErrors.NicknameCannotBeNull);

            if (errors.Length > 0)
                return (null, errors.ToString());

            var sellerInfo = new SellerInfo
            {
                Id = id,
                Nickname = nickname,
                Reputation = reputation,
                SellingSince = sellingSince
            };

            return (sellerInfo, string.Empty);
        }
    }
}
