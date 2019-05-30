using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.API.Migrations
{
    public partial class PopulateCategoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Books",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Books",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
