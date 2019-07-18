using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Change_OrderLimitation_State : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderLimitation",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderLimitation",
                table: "AspNetUsers");
        }
    }
}
