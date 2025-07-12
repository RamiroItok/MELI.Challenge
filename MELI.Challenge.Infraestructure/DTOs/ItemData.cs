using MELI.Challenge.Domain.Models;

namespace MELI.Challenge.Infraestructure.DTOs
{
    public class ItemData
    {
        public string Id { get; set; }
        public int SellerId { get; set; }
        public string Title { get; set; }
        public Price Price { get; set; }
        public List<string> Pictures { get; set; }
        public string Condition { get; set; }
        public bool FreeShipping { get; set; }
        public string Description { get; set; }
        public List<Domain.Models.Attribute> Attributes { get; set; }
    }
}
