using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAU_Project_RentACarPortal.App.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DevirTeslimEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KiralamaDetaylar_Devirler_DevirId",
                table: "KiralamaDetaylar");

            migrationBuilder.DropForeignKey(
                name: "FK_KiralamaDetaylar_Teslimler_TeslimId",
                table: "KiralamaDetaylar");

            migrationBuilder.DropForeignKey(
                name: "FK_Teslimler_Devirler_DevirId",
                table: "Teslimler");

            migrationBuilder.DropIndex(
                name: "IX_Teslimler_DevirId",
                table: "Teslimler");

            migrationBuilder.DropIndex(
                name: "IX_KiralamaDetaylar_DevirId",
                table: "KiralamaDetaylar");

            migrationBuilder.DropIndex(
                name: "IX_KiralamaDetaylar_TeslimId",
                table: "KiralamaDetaylar");

            migrationBuilder.DropColumn(
                name: "Cvv",
                table: "Kiralamalar");

            migrationBuilder.DropColumn(
                name: "Fatura",
                table: "Kiralamalar");

            migrationBuilder.DropColumn(
                name: "KartNumarası",
                table: "Kiralamalar");

            migrationBuilder.DropColumn(
                name: "KartSahibi",
                table: "Kiralamalar");

            migrationBuilder.DropColumn(
                name: "SonKullanımAyı",
                table: "Kiralamalar");

            migrationBuilder.DropColumn(
                name: "SonKullanımYılı",
                table: "Kiralamalar");

            migrationBuilder.DropColumn(
                name: "DevirId",
                table: "KiralamaDetaylar");

            migrationBuilder.DropColumn(
                name: "TeslimId",
                table: "KiralamaDetaylar");

            migrationBuilder.AddColumn<int>(
                name: "KiralamaDetayId",
                table: "Teslimler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FaturaNo",
                table: "Kiralamalar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "KiralamaTarihi",
                table: "Kiralamalar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "ToplamTutar",
                table: "Kiralamalar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "BaslangicTarihi",
                table: "KiralamaDetaylar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BitisTarihi",
                table: "KiralamaDetaylar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GunlukUcret",
                table: "KiralamaDetaylar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ToplamAdet",
                table: "KiralamaDetaylar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KiralamaDetayId",
                table: "Devirler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teslimler_KiralamaDetayId",
                table: "Teslimler",
                column: "KiralamaDetayId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devirler_KiralamaDetayId",
                table: "Devirler",
                column: "KiralamaDetayId",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devirler_KiralamaDetaylar_KiralamaDetayId",
                table: "Devirler");

            migrationBuilder.DropForeignKey(
                name: "FK_Teslimler_KiralamaDetaylar_KiralamaDetayId",
                table: "Teslimler");

            migrationBuilder.DropIndex(
                name: "IX_Teslimler_KiralamaDetayId",
                table: "Teslimler");

            migrationBuilder.DropIndex(
                name: "IX_Devirler_KiralamaDetayId",
                table: "Devirler");

            migrationBuilder.DropColumn(
                name: "KiralamaDetayId",
                table: "Teslimler");

            migrationBuilder.DropColumn(
                name: "FaturaNo",
                table: "Kiralamalar");

            migrationBuilder.DropColumn(
                name: "KiralamaTarihi",
                table: "Kiralamalar");

            migrationBuilder.DropColumn(
                name: "ToplamTutar",
                table: "Kiralamalar");

            migrationBuilder.DropColumn(
                name: "BaslangicTarihi",
                table: "KiralamaDetaylar");

            migrationBuilder.DropColumn(
                name: "BitisTarihi",
                table: "KiralamaDetaylar");

            migrationBuilder.DropColumn(
                name: "GunlukUcret",
                table: "KiralamaDetaylar");

            migrationBuilder.DropColumn(
                name: "ToplamAdet",
                table: "KiralamaDetaylar");

            migrationBuilder.DropColumn(
                name: "KiralamaDetayId",
                table: "Devirler");

            migrationBuilder.AddColumn<string>(
                name: "Cvv",
                table: "Kiralamalar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Fatura",
                table: "Kiralamalar",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KartNumarası",
                table: "Kiralamalar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KartSahibi",
                table: "Kiralamalar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SonKullanımAyı",
                table: "Kiralamalar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SonKullanımYılı",
                table: "Kiralamalar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DevirId",
                table: "KiralamaDetaylar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeslimId",
                table: "KiralamaDetaylar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teslimler_DevirId",
                table: "Teslimler",
                column: "DevirId",
                unique: true,
                filter: "[DevirId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KiralamaDetaylar_DevirId",
                table: "KiralamaDetaylar",
                column: "DevirId");

            migrationBuilder.CreateIndex(
                name: "IX_KiralamaDetaylar_TeslimId",
                table: "KiralamaDetaylar",
                column: "TeslimId");

            migrationBuilder.AddForeignKey(
                name: "FK_KiralamaDetaylar_Devirler_DevirId",
                table: "KiralamaDetaylar",
                column: "DevirId",
                principalTable: "Devirler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KiralamaDetaylar_Teslimler_TeslimId",
                table: "KiralamaDetaylar",
                column: "TeslimId",
                principalTable: "Teslimler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teslimler_Devirler_DevirId",
                table: "Teslimler",
                column: "DevirId",
                principalTable: "Devirler",
                principalColumn: "Id");
        }
    }
}
