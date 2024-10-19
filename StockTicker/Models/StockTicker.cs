namespace StockTicker.Models
{
    public enum TickerType
    {
        Stock,
        Fund,
        Forex,
        Crypto,
    }

    public class StockTickerItem
    {
        public int? ID { get; set; }
        public required string Symbol { get; set; }
        public decimal Price {  get; set; } 

        public TickerType Type { get; set; }

        public ICollection<OverviewStockTickerItem>? OverviewStockTickerItems { get; }
    }
}
