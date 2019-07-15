using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Add_OrderLimitation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderLimitation",
                table: "Sellers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderLimitation",
                table: "Sellers");
        }
    }
}
