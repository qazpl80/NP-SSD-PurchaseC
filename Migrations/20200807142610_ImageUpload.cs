using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchaseC.Migrations
{
    public partial class ImageUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Computer");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Computer");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Computer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Computer");

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Computer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Computer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
