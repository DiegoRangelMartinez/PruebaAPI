using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class RemoveIndependent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIndependent",
                table: "Countries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsIndependent",
                table: "Countries",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
