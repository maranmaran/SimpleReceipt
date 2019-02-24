using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLayer.Migrations
{
    public partial class config : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cafes_PriceTables_PriceTableId",
                table: "Cafes");

            migrationBuilder.DropIndex(
                name: "IX_Cafes_PriceTableId",
                table: "Cafes");

            migrationBuilder.DropColumn(
                name: "PriceTableId",
                table: "Cafes");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTables_CafeId",
                table: "PriceTables",
                column: "CafeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceTables_Cafes_CafeId",
                table: "PriceTables",
                column: "CafeId",
                principalTable: "Cafes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceTables_Cafes_CafeId",
                table: "PriceTables");

            migrationBuilder.DropIndex(
                name: "IX_PriceTables_CafeId",
                table: "PriceTables");

            migrationBuilder.AddColumn<long>(
                name: "PriceTableId",
                table: "Cafes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Cafes_PriceTableId",
                table: "Cafes",
                column: "PriceTableId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cafes_PriceTables_PriceTableId",
                table: "Cafes",
                column: "PriceTableId",
                principalTable: "PriceTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
