using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAU_Project_RentACarPortal.App.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class dbEdited : Migration
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

            migrationBuilder.DropTable(
                name: "FiltrelemeSecenekleri");

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
                name: "EkFatura",
                table: "KiralamaDetaylar");

            migrationBuilder.DropColumn(
                name: "TeslimId",
                table: "KiralamaDetaylar");

            migrationBuilder.RenameColumn(
                name: "MusteriId",
                table: "Kiralamalar",
                newName: "ToplamAdet");

            migrationBuilder.AddColumn<DateTime>(
                name: "BaslangicTarihi",
                table: "Kiralamalar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BitisTarihi",
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

            migrationBuilder.AddColumn<int>(
                name: "ArabaAdet",
                table: "KiralamaDetaylar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ArabaMarka",
                table: "KiralamaDetaylar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FaturaNo",
                table: "KiralamaDetaylar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "GunlukUcret",
                table: "KiralamaDetaylar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MusteriId",
                table: "KiralamaDetaylar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaslangicTarihi",
                table: "Kiralamalar");

            migrationBuilder.DropColumn(
                name: "BitisTarihi",
                table: "Kiralamalar");

            migrationBuilder.DropColumn(
                name: "ToplamTutar",
                table: "Kiralamalar");

            migrationBuilder.DropColumn(
                name: "ArabaAdet",
                table: "KiralamaDetaylar");

            migrationBuilder.DropColumn(
                name: "ArabaMarka",
                table: "KiralamaDetaylar");

            migrationBuilder.DropColumn(
                name: "FaturaNo",
                table: "KiralamaDetaylar");

            migrationBuilder.DropColumn(
                name: "GunlukUcret",
                table: "KiralamaDetaylar");

            migrationBuilder.DropColumn(
                name: "MusteriId",
                table: "KiralamaDetaylar");

            migrationBuilder.RenameColumn(
                name: "ToplamAdet",
                table: "Kiralamalar",
                newName: "MusteriId");

            migrationBuilder.AddColumn<string>(
                name: "Cvv",
                table: "Kiralamalar",
                type: "nvarchar(max)",
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

            migrationBuilder.AddColumn<decimal>(
                name: "EkFatura",
                table: "KiralamaDetaylar",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeslimId",
                table: "KiralamaDetaylar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FiltrelemeSecenekleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArabaId = table.Column<int>(type: "int", nullable: false),
                    Deger1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deger2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deger3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deger4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deger5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deger6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deger7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deger8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Ozellik = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiltrelemeSecenekleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiltrelemeSecenekleri_Arabalar_ArabaId",
                        column: x => x.ArabaId,
                        principalTable: "Arabalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_FiltrelemeSecenekleri_ArabaId",
                table: "FiltrelemeSecenekleri",
                column: "ArabaId");

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
