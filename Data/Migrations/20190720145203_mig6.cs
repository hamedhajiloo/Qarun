using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount_Of_Punishment_For_Reserving_The_Book",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Amount_Of_Punishment_For_Returning_The_Book",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "BorrowDay",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ReservCount",
                table: "Settings");

            migrationBuilder.RenameColumn(
                name: "ReservDay",
                table: "Settings",
                newName: "UserCount4Report");

            migrationBuilder.CreateTable(
                name: "Baners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baners", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baners");

            migrationBuilder.RenameColumn(
                name: "UserCount4Report",
                table: "Settings",
                newName: "ReservDay");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount_Of_Punishment_For_Reserving_The_Book",
                table: "Settings",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount_Of_Punishment_For_Returning_The_Book",
                table: "Settings",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "BorrowDay",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservCount",
                table: "Settings",
                nullable: false,
                defaultValue: 0);
        }
    }
}
