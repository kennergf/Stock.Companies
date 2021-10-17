using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stock.Companies.Data.Migrations
{
    public partial class CreatedCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Exchange = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Ticker = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    ISIN = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    WebSite = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_ISIN",
                table: "Company",
                column: "ISIN",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
