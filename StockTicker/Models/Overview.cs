namespace StockTicker.Models
{
    public class Overview
    {
        public int? ID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<OverviewStockTickerItem> Items { get; set; }

    }
}
