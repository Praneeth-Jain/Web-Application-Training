using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginPage.Migrations
{
    /// <inheritdoc />
    public partial class ProdImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImgPath",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImgPath",
                table: "products");
        }
    }
}
