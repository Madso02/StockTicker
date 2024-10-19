namespace StockTicker.Models
{
    public class StockTickerItem
    {
        public int? ID { get; set; }
        public required string Symbol { get; set; }
        public decimal Price {  get; set; } 
    }
}
