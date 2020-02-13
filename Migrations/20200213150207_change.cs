using Microsoft.EntityFrameworkCore.Migrations;

namespace Terminarz.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Contacts",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Contacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Contacts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Contacts");
        }
    }
}
