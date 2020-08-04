using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchaseC.Migrations
{
    public partial class userID_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Computer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Computer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Computer");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Computer");
        }
    }
}
