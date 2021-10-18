using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class NumbersDepartmentFake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number1",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number2",
                table: "Departments",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number1",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Number2",
                table: "Departments");
        }
    }
}
