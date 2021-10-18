using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class FKCountryCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Countries_CountryCode1",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CountryCode1",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CountryCode1",
                table: "Departments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryCode1",
                table: "Departments",
                type: "nvarchar(2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CountryCode1",
                table: "Departments",
                column: "CountryCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Countries_CountryCode1",
                table: "Departments",
                column: "CountryCode1",
                principalTable: "Countries",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
