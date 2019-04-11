using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiMicroservice.Migrations
{
    public partial class locationchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Locations",
                newName: "Longtitude");

            migrationBuilder.AddColumn<float>(
                name: "Altitude",
                table: "Locations",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Altitude",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "Longtitude",
                table: "Locations",
                newName: "Longitude");
        }
    }
}
