using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLayer.Migrations
{
    public partial class waitercafes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cafes_CafeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CafeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CafeId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "WaiterCafes",
                columns: table => new
                {
                    WaiterId = table.Column<string>(nullable: false),
                    CafeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaiterCafes", x => new { x.WaiterId, x.CafeId });
                    table.ForeignKey(
                        name: "FK_WaiterCafes_Cafes_CafeId",
                        column: x => x.CafeId,
                        principalTable: "Cafes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaiterCafes_AspNetUsers_WaiterId",
                        column: x => x.WaiterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaiterCafes_CafeId",
                table: "WaiterCafes",
                column: "CafeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaiterCafes");

            migrationBuilder.AddColumn<long>(
                name: "CafeId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CafeId",
                table: "AspNetUsers",
                column: "CafeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cafes_CafeId",
                table: "AspNetUsers",
                column: "CafeId",
                principalTable: "Cafes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
