namespace StockTicker.Models
{
    public class OverviewStockTickerItem
    {
        public int ID { get; set; }
        public int Count { get; set; }

        public required Overview Overview { get; set; }
        public required StockTickerItem StockTickerItem { get; set; }
    }
}
