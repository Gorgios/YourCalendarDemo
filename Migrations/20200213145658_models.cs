using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Terminarz.Migrations
{
    public partial class models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    ContactID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calls", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Calls_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Happenings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    City = table.Column<string>(maxLength: 20, nullable: false),
                    Address = table.Column<string>(maxLength: 30, nullable: false),
                    Suit = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ContactID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Happenings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Happenings_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calls_ContactID",
                table: "Calls",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Happenings_ContactID",
                table: "Happenings",
                column: "ContactID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calls");

            migrationBuilder.DropTable(
                name: "Happenings");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
