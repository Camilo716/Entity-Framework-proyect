using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APITask.Migrations
{
    public partial class ColumnPesoCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "peso",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "peso",
                table: "Category");
        }
    }
}
