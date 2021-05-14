using Microsoft.EntityFrameworkCore.Migrations;

namespace Challenge1.Repository.Migrations
{
    public partial class UpdateCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThreeCharCountryCode",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwoCharCountryCode",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThreeCharCountryCode",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "TwoCharCountryCode",
                table: "Countries");
        }
    }
}
