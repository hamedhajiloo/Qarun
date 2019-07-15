using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Add_Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Claim = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sellers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Transactions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<long>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    ReservationCode = table.Column<string>(nullable: true),
                    ReferenceNumber = table.Column<string>(nullable: true),
                    PaymentState = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    PaidDate = table.Column<DateTime>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false),
                    TRACENO = table.Column<string>(nullable: true),
                    RRN = table.Column<string>(nullable: true),
                    CID = table.Column<string>(nullable: true),
                    SecurePan = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Transactions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    OrderPaymentType = table.Column<int>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TotalAmount = table.Column<int>(nullable: false),
                    TotalDiscount = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    UserAddress = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    UserIPAddress = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    TotalShippingCost = table.Column<int>(nullable: false),
                    UniqueCode = table.Column<long>(nullable: true),
                    RedirectedToBank = table.Column<bool>(nullable: false),
                    PaySucceeded = table.Column<bool>(nullable: true),
                    InCityShippingCost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    OrderId = table.Column<long>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerOrders_User_Transactions_Id",
                        column: x => x.Id,
                        principalTable: "User_Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderSellers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<long>(nullable: false),
                    SendDate = table.Column<DateTime>(nullable: true),
                    SellerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderSellers_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderSellers_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatusLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<long>(nullable: false),
                    DateChange = table.Column<DateTime>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatusLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderStatusLogs_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WalletLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<long>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    ChargeOperation = table.Column<int>(nullable: false),
                    ChargeType = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    OrderId = table.Column<long>(nullable: true),
                    UserTransactionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletLogs_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WalletLogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WalletLogs_User_Transactions_UserTransactionId",
                        column: x => x.UserTransactionId,
                        principalTable: "User_Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderShopDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderShopId = table.Column<long>(nullable: false),
                    SellerId = table.Column<string>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    UnitDiscount = table.Column<int>(nullable: false),
                    Tax = table.Column<float>(nullable: false),
                    UnitAmount = table.Column<int>(nullable: false),
                    TotalDiscount = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    TotalWeight = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderShopDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderShopDetails_OrderSellers_OrderShopId",
                        column: x => x.OrderShopId,
                        principalTable: "OrderSellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderShopDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderShopDetails_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_CustomerId",
                table: "CustomerOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_OrderId",
                table: "CustomerOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSellers_OrderId",
                table: "OrderSellers",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSellers_SellerId",
                table: "OrderSellers",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "Group1",
                table: "OrderShopDetails",
                column: "OrderShopId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderShopDetails_ProductId",
                table: "OrderShopDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderShopDetails_SellerId",
                table: "OrderShopDetails",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatusLogs_OrderId",
                table: "OrderStatusLogs",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Transactions_UserId",
                table: "User_Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletLogs_OrderId",
                table: "WalletLogs",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletLogs_UserId",
                table: "WalletLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletLogs_UserTransactionId",
                table: "WalletLogs",
                column: "UserTransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrders");

            migrationBuilder.DropTable(
                name: "OrderShopDetails");

            migrationBuilder.DropTable(
                name: "OrderStatusLogs");

            migrationBuilder.DropTable(
                name: "WalletLogs");

            migrationBuilder.DropTable(
                name: "OrderSellers");

            migrationBuilder.DropTable(
                name: "User_Transactions");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
