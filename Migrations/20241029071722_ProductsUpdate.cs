using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginPage.Migrations
{
    /// <inheritdoc />
    public partial class ProductsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isActive",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "products");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "products");
        }
    }
}
