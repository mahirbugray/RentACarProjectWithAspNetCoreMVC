using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAU_Project_RentACarPortal.App.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DevirTeslimEdit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devirler_KiralamaDetaylar_KiralamaDetayId",
                table: "Devirler");

            migrationBuilder.DropForeignKey(
                name: "FK_Teslimler_KiralamaDetaylar_KiralamaDetayId",
                table: "Teslimler");

            migrationBuilder.DropColumn(
                name: "EkFatura",
                table: "KiralamaDetaylar");

            migrationBuilder.RenameColumn(
                name: "KiralamaDetayId",
                table: "Teslimler",
                newName: "FaturaNo");

            migrationBuilder.RenameIndex(
                name: "IX_Teslimler_KiralamaDetayId",
                table: "Teslimler",
                newName: "IX_Teslimler_FaturaNo");

            migrationBuilder.RenameColumn(
                name: "KiralamaDetayId",
                table: "Devirler",
                newName: "FaturaNo");

            migrationBuilder.RenameIndex(
                name: "IX_Devirler_KiralamaDetayId",
                table: "Devirler",
                newName: "IX_Devirler_FaturaNo");

            migrationBuilder.AddColumn<int>(
                name: "FaturaNo",
                table: "KiralamaDetaylar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Devirler_KiralamaDetaylar_FaturaNo",
                table: "Devirler",
                column: "FaturaNo",
                principalTable: "KiralamaDetaylar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teslimler_KiralamaDetaylar_FaturaNo",
                table: "Teslimler",
                column: "FaturaNo",
                principalTable: "KiralamaDetaylar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devirler_KiralamaDetaylar_FaturaNo",
                table: "Devirler");

            migrationBuilder.DropForeignKey(
                name: "FK_Teslimler_KiralamaDetaylar_FaturaNo",
                table: "Teslimler");

            migrationBuilder.DropColumn(
                name: "FaturaNo",
                table: "KiralamaDetaylar");

            migrationBuilder.RenameColumn(
                name: "FaturaNo",
                table: "Teslimler",
                newName: "KiralamaDetayId");

            migrationBuilder.RenameIndex(
                name: "IX_Teslimler_FaturaNo",
                table: "Teslimler",
                newName: "IX_Teslimler_KiralamaDetayId");

            migrationBuilder.RenameColumn(
                name: "FaturaNo",
                table: "Devirler",
                newName: "KiralamaDetayId");

            migrationBuilder.RenameIndex(
                name: "IX_Devirler_FaturaNo",
                table: "Devirler",
                newName: "IX_Devirler_KiralamaDetayId");

            migrationBuilder.AddColumn<decimal>(
                name: "EkFatura",
                table: "KiralamaDetaylar",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Devirler_KiralamaDetaylar_KiralamaDetayId",
                table: "Devirler",
                column: "KiralamaDetayId",
                principalTable: "KiralamaDetaylar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teslimler_KiralamaDetaylar_KiralamaDetayId",
                table: "Teslimler",
                column: "KiralamaDetayId",
                principalTable: "KiralamaDetaylar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
