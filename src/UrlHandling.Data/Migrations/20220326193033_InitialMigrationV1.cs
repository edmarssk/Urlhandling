using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlHandling.Data.Migrations
{
    public partial class InitialMigrationV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UrlLink",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ShortUrl = table.Column<string>(type: "varchar(100)", nullable: false),
                    OriginalUrl = table.Column<string>(type: "varchar(500)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrlLink", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UrlLink");
        }
    }
}
