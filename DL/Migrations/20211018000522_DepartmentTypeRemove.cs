using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class DepartmentTypeRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentType",
                table: "Departments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepartmentType",
                table: "Departments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
