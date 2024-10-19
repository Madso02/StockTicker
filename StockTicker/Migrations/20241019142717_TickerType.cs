using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockTicker.Migrations
{
    /// <inheritdoc />
    public partial class TickerType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "StockTickerItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "StockTickerItems");
        }
    }
}
