namespace MELI.Challenge.Domain.Shared
{
    public static class ItemsErrors
    {
        public const string IdCannotBeNull = "Item ID cannot be null or empty.";
        public const string TitleCannotBeNull = "Item Title cannot be null or empty.";
        public const string PriceIsInvalid = "Price must be greater than zero.";
        public const string PicturesAreEmpty = "Item must have at least one picture.";
        public const string ProductDoNotExist = "Product do not exist";
    }
}
