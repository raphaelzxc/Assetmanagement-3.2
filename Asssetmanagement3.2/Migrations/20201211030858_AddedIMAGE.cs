using Microsoft.EntityFrameworkCore.Migrations;

namespace Asssetmanagement3._2.Migrations
{
    public partial class AddedIMAGE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imgname",
                table: "Desktop",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imgpath",
                table: "Desktop",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imgname",
                table: "Desktop");

            migrationBuilder.DropColumn(
                name: "Imgpath",
                table: "Desktop");
        }
    }
}
