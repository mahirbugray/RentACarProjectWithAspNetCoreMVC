using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAU_Project_RentACarPortal.App.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removeMusteriTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Degerlendirmeler_Musteriler_MusteriId",
                table: "Degerlendirmeler");

            migrationBuilder.DropForeignKey(
                name: "FK_Kiralamalar_Musteriler_MusteriId",
                table: "Kiralamalar");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropIndex(
                name: "IX_Kiralamalar_MusteriId",
                table: "Kiralamalar");

            migrationBuilder.DropIndex(
                name: "IX_Degerlendirmeler_MusteriId",
                table: "Degerlendirmeler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    DogumYili = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kiralamalar_MusteriId",
                table: "Kiralamalar",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Degerlendirmeler_MusteriId",
                table: "Degerlendirmeler",
                column: "MusteriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Degerlendirmeler_Musteriler_MusteriId",
                table: "Degerlendirmeler",
                column: "MusteriId",
                principalTable: "Musteriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kiralamalar_Musteriler_MusteriId",
                table: "Kiralamalar",
                column: "MusteriId",
                principalTable: "Musteriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
