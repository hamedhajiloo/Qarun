using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Relations_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BarCode",
                table: "AspNetUsers",
                newName: "QRCode");

            migrationBuilder.AddColumn<long>(
                name: "IncomeId",
                table: "Orders",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "QarunAmount",
                table: "OrderChildren",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountOfDebt",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Followers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Followers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Followings",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Followings_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Percentage = table.Column<int>(nullable: false),
                    SaleAmount = table.Column<decimal>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_Orders_Id",
                        column: x => x.Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IncomeId",
                table: "Orders",
                column: "IncomeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Incomes_IncomeId",
                table: "Orders",
                column: "IncomeId",
                principalTable: "Incomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Incomes_IncomeId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Followers");

            migrationBuilder.DropTable(
                name: "Followings");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IncomeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IncomeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "QarunAmount",
                table: "OrderChildren");

            migrationBuilder.DropColumn(
                name: "AmountOfDebt",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "QRCode",
                table: "AspNetUsers",
                newName: "BarCode");
        }
    }
}
