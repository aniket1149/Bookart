namespace Core.Entities
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string BookNameBasket { get; set; }
        public decimal PriceBasketBook { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }

    }
}