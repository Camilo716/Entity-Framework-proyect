using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APITask.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "taskID",
                table: "Task",
                newName: "TaskID");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Category",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "description", "name", "peso" },
                values: new object[] { new Guid("790eebd4-ed89-4366-8561-cce9488e5202"), null, "Personal activities", 50 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "description", "name", "peso" },
                values: new object[] { new Guid("790eebd4-ed89-4366-8561-cce9488e52fa"), null, "Pending activities", 20 });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskID", "CategoryID", "Deadline", "Priority", "creationDate", "description", "tittle" },
                values: new object[] { new Guid("790eebd4-ed89-4366-8561-cce9488e5210"), new Guid("790eebd4-ed89-4366-8561-cce9488e52fa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 2, 14, 14, 15, 25, 470, DateTimeKind.Local).AddTicks(8984), null, "Public services pay" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskID", "CategoryID", "Deadline", "Priority", "creationDate", "description", "tittle" },
                values: new object[] { new Guid("790eebd4-ed89-4366-8561-cce9488e5211"), new Guid("790eebd4-ed89-4366-8561-cce9488e5202"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2023, 2, 14, 14, 15, 25, 470, DateTimeKind.Local).AddTicks(9014), null, "Finish Netflix series" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskID",
                keyValue: new Guid("790eebd4-ed89-4366-8561-cce9488e5210"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskID",
                keyValue: new Guid("790eebd4-ed89-4366-8561-cce9488e5211"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryID",
                keyValue: new Guid("790eebd4-ed89-4366-8561-cce9488e5202"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryID",
                keyValue: new Guid("790eebd4-ed89-4366-8561-cce9488e52fa"));

            migrationBuilder.RenameColumn(
                name: "TaskID",
                table: "Task",
                newName: "taskID");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Category",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);
        }
    }
}
