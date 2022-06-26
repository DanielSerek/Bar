using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bar.Data.Migrations
{
    public partial class RemovedProductObjectFromOrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemViewModel_ProductViewModel_ProductId",
                table: "OrderItemViewModel");

            migrationBuilder.DropTable(
                name: "ProductViewModel");

            migrationBuilder.DropIndex(
                name: "IX_OrderItemViewModel_ProductId",
                table: "OrderItemViewModel");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemViewModel_ProductId",
                table: "OrderItemViewModel",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemViewModel_ProductViewModel_ProductId",
                table: "OrderItemViewModel",
                column: "ProductId",
                principalTable: "ProductViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
