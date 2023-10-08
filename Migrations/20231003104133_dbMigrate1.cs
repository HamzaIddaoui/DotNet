using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductWebapp.Migrations
{
    /// <inheritdoc />
    public partial class dbMigrate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imagePath",
                table: "Product",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagePath",
                table: "Product");
        }
    }
}
