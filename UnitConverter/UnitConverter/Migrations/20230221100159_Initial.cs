using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UnitConverter.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConversionRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UnitFrom = table.Column<string>(type: "text", nullable: false),
                    UnitTo = table.Column<string>(type: "text", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversionRates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ConversionRates",
                columns: new[] { "Id", "Rate", "UnitFrom", "UnitTo" },
                values: new object[,]
                {
                    { 1, 1.8m, "Celsius", "Fahrenheit" },
                    { 2, 0.621371m, "Kilometers", "Miles" },
                    { 3, 2.20462m, "Kilograms", "Pounds" },
                    { 4, 0.264172m, "Liters", "Gallons" },
                    { 5, 3.28084m, "Meters", "Feet" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConversionRates");
        }
    }
}
