using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitsAndBobs.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomersDB",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustFirstName = table.Column<string>(nullable: false),
                    CustLastName = table.Column<string>(nullable: false),
                    CustUsername = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersDB", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "LocationsDB",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationCity = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationsDB", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "ProductsDB",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsDB", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "OrdersDB",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderCustomerCustomerID = table.Column<int>(nullable: false),
                    OrderLocationLocationID = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDB", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_OrdersDB_CustomersDB_OrderCustomerCustomerID",
                        column: x => x.OrderCustomerCustomerID,
                        principalTable: "CustomersDB",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersDB_LocationsDB_OrderLocationLocationID",
                        column: x => x.OrderLocationLocationID,
                        principalTable: "LocationsDB",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryDB",
                columns: table => new
                {
                    InventoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryLocationLocationID = table.Column<int>(nullable: false),
                    InventoryProductProductID = table.Column<int>(nullable: false),
                    QuantityAvailable = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryDB", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK_InventoryDB_LocationsDB_InventoryLocationLocationID",
                        column: x => x.InventoryLocationLocationID,
                        principalTable: "LocationsDB",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryDB_ProductsDB_InventoryProductProductID",
                        column: x => x.InventoryProductProductID,
                        principalTable: "ProductsDB",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLineItemsDB",
                columns: table => new
                {
                    OrderLineItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineItemProductProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    LinePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLineItemsDB", x => x.OrderLineItemID);
                    table.ForeignKey(
                        name: "FK_OrderLineItemsDB_ProductsDB_LineItemProductProductID",
                        column: x => x.LineItemProductProductID,
                        principalTable: "ProductsDB",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLineItemsDB_OrdersDB_OrderID",
                        column: x => x.OrderID,
                        principalTable: "OrdersDB",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDB_InventoryLocationLocationID",
                table: "InventoryDB",
                column: "InventoryLocationLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDB_InventoryProductProductID",
                table: "InventoryDB",
                column: "InventoryProductProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineItemsDB_LineItemProductProductID",
                table: "OrderLineItemsDB",
                column: "LineItemProductProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineItemsDB_OrderID",
                table: "OrderLineItemsDB",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDB_OrderCustomerCustomerID",
                table: "OrdersDB",
                column: "OrderCustomerCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDB_OrderLocationLocationID",
                table: "OrdersDB",
                column: "OrderLocationLocationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryDB");

            migrationBuilder.DropTable(
                name: "OrderLineItemsDB");

            migrationBuilder.DropTable(
                name: "ProductsDB");

            migrationBuilder.DropTable(
                name: "OrdersDB");

            migrationBuilder.DropTable(
                name: "CustomersDB");

            migrationBuilder.DropTable(
                name: "LocationsDB");
        }
    }
}
