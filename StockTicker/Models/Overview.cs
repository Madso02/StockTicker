using StockTicker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace StockTicker.Models
{
    public class Overview
    {
        public int? ID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<OverviewStockTickerItem>? Items { get; set; }

    }
}
