using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume_Project.Migrations
{
    /// <inheritdoc />
    public partial class initialAddUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WebsiteUrl",
                table: "Portfolio",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WebsiteUrl",
                table: "Portfolio");
        }
    }
}
