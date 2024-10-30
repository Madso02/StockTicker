using StockTicker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json.Serialization;
namespace StockTicker.Models
{
    public class Overview
    {
        public long ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<OverviewStockTickerItem>? OverviewStockTickerItems { get; set; } = new List<OverviewStockTickerItem>();

    }

    public class OverviewDTO
    {
        public long? ID { get; set; } = null;
        public string? Name { get; set; } = null;
        public string? Description { get; set; } = null;
        public IEnumerable<OverviewStockTickerItem>? OverviewStockTickerItems { get; set; } = null;

    }
}
