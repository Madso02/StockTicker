using System.ComponentModel.DataAnnotations;

namespace StockTicker.Models
{
    public class OverviewStockTickerItem
    {
        public long ID { get; set; }
        public int Count { get; set; }
        public string? Alias { get; set; }
        public string? Uri { get; set; }
        [Required]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Overview Overview { get; init; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }

    public class OverviewStockTickerItemDTO
    {
        public long ID { get; set; }
        public int Count { get; set; }
        public string? Alias { get; set; }
        public string? Uri { get; set; }
        public long? OverviewID { get; set; }
    }
}
